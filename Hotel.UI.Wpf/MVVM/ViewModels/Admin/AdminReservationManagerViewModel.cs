using Hotel.Configuration.Interfaces;
using Hotel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationManagerViewModel : ViewModelBase
    {
        private readonly IUser _connectedUser;
        private readonly UserManager _userManager = new UserManager();
        private readonly HotelRoomsManager _hotelRoomsManager = new HotelRoomsManager();
        private readonly ReservationManager _reservationManager; 
        public AdminReservationManagerViewModel(IUser? connectedUser)
        {
            if (connectedUser == null)
            {
                throw new ArgumentNullException(nameof(connectedUser));
            }
            _connectedUser = connectedUser;
            _reservationManager = new ReservationManager(_userManager, _hotelRoomsManager);
            InitiateComponents();
        }
        public ObservableCollection<AdminReservationItemViewModel> Reservations { get; } = new ObservableCollection<AdminReservationItemViewModel>();
        private void InitiateComponents()
        {
            var reservations = _reservationManager.HotelRerservations;
            foreach (var reservation in reservations)
            {
                var user = _userManager.GetUserFromId(reservation.UserId) ?? throw new ArgumentNullException();
                var name = $"{user.FirstName} {user.LastName}";
                Reservations.Add(new AdminReservationItemViewModel(reservation, name));
            }
        }
    }
}
