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
using Hotel.UI.Wpf.MVVM.ViewModels.Popups;
using Hotel.Configuration.Enums;
using System.Reflection.Metadata;
using System.Collections.Specialized;
using Hotel.UI.Wpf.MVVM.Stores;
using System.Data.Common;

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
            Reservations = new ObservableCollection<AdminReservationItemViewModel>();
            GetReservationsFromCore();
            OpenInsertReservationDialog = new DelegateCommand(OnShowInsertReservationDialog);
            AdminReservationsFilterPopupViewModel = new AdminReservationsFilterPopupViewModel(_hotelRoomsManager, _reservationManager,
                _userManager, Reservations);
            AcceptReservationCommand = new DelegateCommand(OnAcceptReservation);
            DeclineReservationCommand = new DelegateCommand(OnDeclineReservation);
            OpenDeleteReservationConfirmationCommand = new DelegateCommand(OnOpenDeleteReservationConfiramtion);
            OpenShowDetailsCommand = new DelegateCommand(OnOpenShowDetailsDialog);
        }
        public ObservableCollection<AdminReservationItemViewModel> Reservations { get; } 
        public AdminReservationsFilterPopupViewModel AdminReservationsFilterPopupViewModel { get; }
        internal void GetReservationsFromCore()
        {
            if (Reservations.Count != 0)
            {
                Reservations.Clear();
            }
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
        private void OnAcceptReservation(object parameter)
        {
            if (parameter is AdminReservationItemViewModel itemViewModel)
            {
                itemViewModel.Status = ReservationStatus.Accepted;
            }
        }
        private void OnDeclineReservation(object parameter)
        {
            if (parameter is AdminReservationItemViewModel itemViewModel)
            {
                itemViewModel.Status = ReservationStatus.Declined;
            }
        }
        private async void OnOpenDeleteReservationConfiramtion(object paramater)
        {
            await DialogHost.Show(new ConfirmationDialogViewModel("Are You Sure You Want To Delete this Reservation ?",new DeleteReservationCommand(_reservationManager,paramater,this) ), _dialogHostId);
        }
        private async void OnOpenShowDetailsDialog(object paramater)
        {
            await DialogHost.Show(new AdminShowDetailsViewModel(), _dialogHostId);
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
        public ICommand OpenDeleteReservationConfirmationCommand { get; }
        public ICommand AcceptReservationCommand { get; }
        public ICommand DeclineReservationCommand { get; }
        public ICommand OpenShowDetailsCommand { get; }
    }
}
