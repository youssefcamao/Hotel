using Hotel.Configuration.Exceptions;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using System;
using System.ComponentModel;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class AdminAddReservationCommand : CommandBase
    {
        private readonly IUser _connectedUser;
        private readonly AdminInsertReservationViewModel _adminInsertReservationViewModel;
        private readonly ReservationManager _reservationManager;
        private readonly AdminViewModel _adminViewModel;
        private readonly UserManager _userManager;
        private readonly HotelRoomsManager _roomsManager;
        private bool _isDialogOpen;

        public AdminAddReservationCommand(IUser connectedUser, AdminInsertReservationViewModel adminInsertReservationViewModel,
            ReservationManager reservationManager, AdminViewModel adminViewModel, UserManager userManager, HotelRoomsManager roomsManager, bool isDialogOpen)
        {
            _connectedUser = connectedUser;
            _adminInsertReservationViewModel = adminInsertReservationViewModel;
            _reservationManager = reservationManager;
            _adminViewModel = adminViewModel;
            _userManager = userManager;
            _roomsManager = roomsManager;
            _isDialogOpen = isDialogOpen;
            _adminInsertReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object? parameter)
        {
            var startDate = _adminInsertReservationViewModel.StartDate ?? throw new ArgumentNullException();
            var endDate = _adminInsertReservationViewModel.EndDate ?? throw new ArgumentNullException();
            try
            {
                _reservationManager.AddNewReservation(startDate, endDate,
                    _adminInsertReservationViewModel.ReservedRoomCategory.Id, _connectedUser.Id, _adminInsertReservationViewModel.FirstName
                    , _adminInsertReservationViewModel.LastName, _adminInsertReservationViewModel.Email, _adminInsertReservationViewModel.ReservationStatusType);

            }
            catch (Exception e)
            {
                _adminInsertReservationViewModel.Error = e.Message;
                return;
            }
            _adminViewModel.CurrentChildAdminViewModel = new AdminReservationManagerViewModel(_connectedUser, _adminViewModel, _userManager,
                _reservationManager, _roomsManager);
            _isDialogOpen = false;
        }
        public override bool CanExecute(object? parameter)
        {
            var areAllInputsFilledAndCorrect = _adminInsertReservationViewModel.StartDate != null && _adminInsertReservationViewModel.EndDate != null
                && !string.IsNullOrWhiteSpace(_adminInsertReservationViewModel.Email) && !string.IsNullOrWhiteSpace(_adminInsertReservationViewModel.FirstName)
                && !string.IsNullOrWhiteSpace(_adminInsertReservationViewModel.LastName) && _adminInsertReservationViewModel.ReservedRoomCategory != null
                && !_adminInsertReservationViewModel.EmailHasError;
            var canExecute = base.CanExecute(parameter) && areAllInputsFilledAndCorrect;
            return canExecute;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
