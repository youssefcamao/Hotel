using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using Hotel.UI.Wpf.MVVM.ViewModels.Popups;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

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
            , ReservationManager reservationManager, HotelRoomsManager hotelRoomsManager)
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
            Reservations.CollectionChanged += Reservations_CollectionChanged;
        }

        private void Reservations_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(NoDataAvailableMessageVisibility));
        }
        /// <summary>
        /// gets the collection of <see cref="AdminReservationItemViewModel"/> that represented in the ui
        /// </summary>
        public ObservableCollection<AdminReservationItemViewModel> Reservations { get; }
        /// <summary>
        /// gets the viewModel of the filter popup
        /// </summary>
        public AdminReservationsFilterPopupViewModel AdminReservationsFilterPopupViewModel { get; }
        /// <summary>
        /// represents the string of the visibility of the no data is available
        /// </summary>
        /// <remarks> the string can be either Visible or Collapsed</remarks>
        public string NoDataAvailableMessageVisibility => Reservations.Count == 0 ? "Visible" : "Collapsed";
        /// <summary>
        /// gets and sets the boolean that represents the state of the dialog (if open or closed)
        /// </summary>
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
        /// <summary>
        /// This Method loads reservations from the back end 
        /// </summary>
        /// <remarks> this method clears all reservations before loading the new ones from the backend</remarks>
        internal void GetReservationsFromCore()
        {
            if (Reservations.Count != 0)
            {
                Reservations.Clear();
            }
            var reservations = _reservationManager.HotelRerservations;
            foreach (var reservation in reservations)
            {
                Reservations.Add(new AdminReservationItemViewModel(reservation, _userManager, _hotelRoomsManager, _reservationManager));
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
            await DialogHost.Show(new ConfirmationDialogViewModel("Are You Sure You Want To Delete this Reservation ?", new AdminDeleteReservationCommand(_reservationManager, paramater, this)), _dialogHostId);
        }
        private async void OnOpenShowDetailsDialog(object paramater)
        {
            await DialogHost.Show(new AdminShowDetailsViewModel(paramater, _reservationManager, _hotelRoomsManager, _userManager), _dialogHostId);
        }
        private bool _isDialogOpen;
        
        public ICommand OpenInsertReservationDialog { get; }
        public ICommand OpenDeleteReservationConfirmationCommand { get; }
        public ICommand AcceptReservationCommand { get; }
        public ICommand DeclineReservationCommand { get; }
        public ICommand OpenShowDetailsCommand { get; }
    }
}
