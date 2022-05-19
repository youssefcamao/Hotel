using Hotel.Configuration.Interfaces;
using Hotel.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationManagerViewModel : ViewModelBase
    {
        private readonly IUser _connectedUser;
        private readonly AdminViewModel _parentViewModel;
        private readonly UserManager _userManager;
        private readonly HotelRoomsManager _hotelRoomsManager;
        private const string _dialogHostId = "RootDialogHostId";
        private readonly ReservationManager _reservationManager;
        public AdminReservationManagerViewModel(IUser? connectedUser, AdminViewModel _parentViewModel, UserManager userManager
            ,ReservationManager reservationManager, HotelRoomsManager hotelRoomsManager )
        {
            if (connectedUser == null)
            {
                throw new ArgumentNullException(nameof(connectedUser));
            }
            _connectedUser = connectedUser;
            this._parentViewModel = _parentViewModel;
            _userManager = userManager;
            _reservationManager = reservationManager;
            _hotelRoomsManager = hotelRoomsManager;
            InitiateComponents();
            OpenInsertReservationDialog = new DelegateCommand(OnShowInsertReservationDialog);
            
        }
        public ObservableCollection<AdminReservationItemViewModel> Reservations { get; } = new ObservableCollection<AdminReservationItemViewModel>();
        private void InitiateComponents()
        {
            var reservations = _reservationManager.HotelRerservations;
            foreach (var reservation in reservations)
            {
                Reservations.Add(new AdminReservationItemViewModel(reservation,_userManager,_hotelRoomsManager));
            }
        }
        private async void OnShowInsertReservationDialog(object _)
        {
            
            await DialogHost.Show(new AdminInsertReservationViewModel(_hotelRoomsManager, _reservationManager,
                _connectedUser, _parentViewModel, _userManager, IsDialogOpen), _dialogHostId);

        }
        private bool _isDialogOpen;
        public bool IsDialogOpen
        {
            get
            {
                return _isDialogOpen;
            }
            set
            {
                _isDialogOpen = value;
                OnPropertyChanged(nameof(IsDialogOpen));
            }
        }
        public ICommand OpenInsertReservationDialog { get; }
        public ICommand RemoveReservation { get; }
    }
}
