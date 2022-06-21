using Hotel.Configuration.Interfaces.Models;
using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    /// <summary>
    /// This command switches the view to <see cref="AdminReservationManagerViewModel"/>
    /// </summary>
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
