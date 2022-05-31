using Hotel.Configuration.Interfaces;
using Hotel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Configuration.Interfaces;
using Hotel.Configuration;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationItemViewModel : ViewModelBase
    {
        private readonly IHotelReservation _reservation;
        private IRoomCategory _roomCategory;
        private readonly UserManager _userManager;
        private HotelRoomsManager _hotelRoomsManager;
        private IUser _creationUser;
        private IRoom _reservationRoom;

        public int RoomNumber => _reservation.RoomNumber;
        public string RoomType => _roomCategory.CategoryName;
        public string Name { get; private set; }
        public DateOnly StartDate => _reservation.StartDate;
        public DateOnly EndDate => _reservation.EndDate;
        public double TotalPrice => _reservation.TotalPriceForNights;
        public string Status => _reservation.ReservationStatus.ToString();

        public string IsRespondToReservationVisible => _reservation.ReservationStatus == Configuration.Enums.ReservationStatus.Pending ? "Visible" : "Collapsed";

        public AdminReservationItemViewModel(IHotelReservation reservation, UserManager userManager, HotelRoomsManager hotelRoomsManager)
        {
            _reservation = reservation;
            _userManager = userManager;
            _hotelRoomsManager = hotelRoomsManager;
            InitiateCompnents();
        }
        private void InitiateCompnents()
        {
            _creationUser = _userManager.GetUserFromId(_reservation.CreationUserId) ?? throw new ArgumentNullException();
            Name = $"{_reservation.FirstName} {_reservation.LastName}";
            _reservationRoom = _hotelRoomsManager.GetRoomFromNumber(_reservation.RoomNumber) ?? throw new ArgumentNullException();
            _roomCategory = _hotelRoomsManager.GetRoomCategoryFromId(_reservationRoom.CategoryId) ?? throw new ArgumentNullException();
        }
    }
}
