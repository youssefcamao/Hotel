using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using Hotel.UI.Wpf.Ui_Helpers;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildAdminViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly IUser _connectedUser;
        private readonly ReservationManager _reservationManager;
        private readonly HotelRoomsManager _hotelRoomsManager = new HotelRoomsManager();
        private const string _dialogHostIdentifier = "LogoutDialog";

        public AdminViewModel(NavigationStore navigationStore, IUser connectedUser, UserManager userManager)
        {
            _navigationStore = navigationStore;
            _connectedUser = connectedUser;
            _reservationManager = new ReservationManager(userManager, _hotelRoomsManager);
            OpenReservationCommand = new OpenReservationCommand(this, connectedUser, userManager, _reservationManager, _hotelRoomsManager);
            OpenUserManagerCommand = new OpenUserManagerCommand(this);
            OpenHotelRoomsManager = new OpenHotelRoomsManagerCommand(this);
            LogoutCommandWithConfirmation = new DelegateCommand(OnLogoutConfirmation);
            CurrentUserString = UiStringHelpers.GetUserNameFromUser(_connectedUser);
            _currentChildAdminViewModel = new AdminReservationManagerViewModel(_connectedUser, this, userManager, _reservationManager, _hotelRoomsManager);
        }
        public string CurrentUserString { get; }
        private bool _isNavigationMenuExpanded = false;
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
