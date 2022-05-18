using Hotel.Configuration.Interfaces;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class AddReservationCommand : CommandBase
    {
        private readonly IUser _connectedUser;
        private readonly AdminInsertReservationViewModel _adminInsertReservationViewModel;
        private readonly ReservationManager _reservationManager;
        private readonly AdminViewModel _adminViewModel;
        private readonly UserManager _userManager;
        private readonly HotelRoomsManager _roomsManager;
        private AdminViewModel _parentViewModel;

        public AddReservationCommand(IUser connectedUser, AdminInsertReservationViewModel adminInsertReservationViewModel,
            ReservationManager reservationManager, AdminViewModel adminViewModel, UserManager userManager, HotelRoomsManager roomsManager)
        {
            _connectedUser = connectedUser;
            _adminInsertReservationViewModel = adminInsertReservationViewModel;
            _reservationManager = reservationManager;
            _adminViewModel = adminViewModel;
            _userManager = userManager;
            _roomsManager = roomsManager;
        }

        public override void Execute(object? parameter)
        {
            var startDate = _adminInsertReservationViewModel.StartDate ?? throw new ArgumentNullException();
            var endDate = _adminInsertReservationViewModel.EndDate ?? throw new ArgumentNullException();
            _reservationManager.AddNewReservation(startDate, endDate,
                _adminInsertReservationViewModel.ReservedRoomCategory.CategoryId, _connectedUser.Id, _adminInsertReservationViewModel.FirstName
                , _adminInsertReservationViewModel.LastName, _adminInsertReservationViewModel.Email);
            _adminViewModel.CurrentChildAdminViewModel = new AdminReservationManagerViewModel(_connectedUser, _adminViewModel, _userManager,
                _reservationManager, _roomsManager);
        }
    }
}
