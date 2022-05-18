using Hotel.Configuration.Interfaces;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class OpenReservationCommand : CommandBase
    {
        private AdminViewModel _adminViewModel;
        private IUser _connectedUser;
        private readonly UserManager _userManager;
        private readonly ReservationManager _reservationManager;
        private readonly HotelRoomsManager _roomsManager;

        public OpenReservationCommand(AdminViewModel adminViewModel, IUser connectedUser, UserManager userManager, 
            ReservationManager reservationManager, HotelRoomsManager roomsManager)
        {
            _adminViewModel = adminViewModel;
            _connectedUser = connectedUser;
            _userManager = userManager;
            _reservationManager = reservationManager;
            _roomsManager = roomsManager;
        }

        public override void Execute(object? parameter)
        {
            _adminViewModel.CurrentChildAdminViewModel = new AdminReservationManagerViewModel(_connectedUser, _adminViewModel, _userManager,
                _reservationManager, _roomsManager);
        }
    }
}
