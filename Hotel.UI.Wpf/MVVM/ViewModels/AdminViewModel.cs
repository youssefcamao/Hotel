using Hotel.Configuration.Interfaces.DataAccess;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Repos;
using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using Hotel.UI.Wpf.Services;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildAdminViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly IUser _connectedUser;
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly ReservationManager _reservationManager;
        private readonly IRepository<IRoom> _roomsRepo;
        private readonly IRepository<IRoomCategory> _roomsCategoryRepo;
        private readonly IRepository<IHotelReservation> _reservationsRepo;
        private readonly HotelRoomsManager _hotelRoomsManager;
        private const string _dialogHostIdentifier = "LogoutDialog";

        public AdminViewModel(NavigationStore navigationStore, IUser connectedUser, UserManager userManager, ISqlDataAccess sqlDataAccess)
        {
            _navigationStore = navigationStore;
            _connectedUser = connectedUser;
            _sqlDataAccess = sqlDataAccess;
            _roomsRepo = new RoomsRepository(_sqlDataAccess);
            _roomsCategoryRepo = new CategoriesRepository(_sqlDataAccess);
            _hotelRoomsManager = new HotelRoomsManager(_roomsRepo, _roomsCategoryRepo);
            _reservationsRepo = new ReservationsRepository(_sqlDataAccess);
            _reservationManager = new ReservationManager(_hotelRoomsManager, _reservationsRepo);
            OpenReservationCommand = new OpenReservationCommand(this, connectedUser, userManager, _reservationManager, _hotelRoomsManager);
            OpenUserManagerCommand = new OpenUserManagerCommand(this, userManager,_connectedUser);
            OpenHotelRoomsManager = new OpenHotelRoomsManagerCommand(this);
            LogoutCommandWithConfirmation = new DelegateCommand(OnLogoutConfirmation);
            CurrentUserString = UserHelperService.GetUserNameFromUser(_connectedUser);
            _currentChildAdminViewModel = new AdminReservationManagerViewModel(_connectedUser, this, userManager, _reservationManager, _hotelRoomsManager);
        }
        /// <summary>
        /// gets and sets the string that represents the user on closing bar
        /// </summary>
        public string CurrentUserString { get; }
        private bool _isNavigationMenuExpanded = false;
        /// <summary>
        /// gets and sets expansion of the navaigation Menu
        /// </summary>
        public bool IsNavigationMenuExpanded
        {
            get
            {
                return _isNavigationMenuExpanded;
            }
            set
            {
                _isNavigationMenuExpanded = value;
                OnPropertyChanged(nameof(IsNavigationMenuExpanded));
            }
        }
        /// <summary>
        /// gets and sets the current child view model
        /// </summary>
        public ViewModelBase CurrentChildAdminViewModel
        {
            get
            {
                return _currentChildAdminViewModel;
            }
            set
            {
                _currentChildAdminViewModel = value;
                OnPropertyChanged(nameof(CurrentChildAdminViewModel));
            }
        }
        private async void OnLogoutConfirmation(object _)
        {
            await DialogHost.Show(new ConfirmationDialogViewModel("Are You Sure You Want To Logout ?", new LogoutCommand(_navigationStore)), _dialogHostIdentifier);
        }
        public ICommand OpenReservationCommand { get; }
        public ICommand OpenUserManagerCommand { get; }
        public ICommand OpenHotelRoomsManager { get; }
        public ICommand LogoutCommandWithConfirmation { get; }
    }
}
