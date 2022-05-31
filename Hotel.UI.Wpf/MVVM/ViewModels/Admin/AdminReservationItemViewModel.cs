using Hotel.Configuration.Interfaces;
using Hotel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Configuration.Interfaces;
using Hotel.Configuration;
using System.Windows.Input;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.Configuration.Enums;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationItemViewModel : ViewModelBase
    {
        private IRoomCategory _roomCategory;
        private readonly UserManager _userManager;
        private HotelRoomsManager _hotelRoomsManager;
        private IUser _creationUser;
        private IRoom _reservationRoom;
        public IHotelReservation Reservation { get; }
        public int RoomNumber => Reservation.RoomNumber;
        public string RoomType => _roomCategory.CategoryName;
        public string Name { get; private set; }
        public DateOnly StartDate => Reservation.StartDate;
        public DateOnly EndDate => Reservation.EndDate;
        public double TotalPrice => Reservation.TotalPriceForNights;
        public ReservationStatus Status
        {
            get
            {
                return Reservation.ReservationStatus;
            }
            set
            {
                Reservation.ReservationStatus = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string IsRespondToReservationVisible => Reservation.ReservationStatus == Configuration.Enums.ReservationStatus.Pending ? "Visible" : "Collapsed";

        public AdminReservationItemViewModel(IHotelReservation reservation, UserManager userManager, HotelRoomsManager hotelRoomsManager)
        {
            Reservation = reservation;
            _userManager = userManager;
            _hotelRoomsManager = hotelRoomsManager;
            InitiateCompnents();
        }
        private void InitiateCompnents()
        {
            _creationUser = _userManager.GetUserFromId(Reservation.CreationUserId) ?? throw new ArgumentNullException();
            Name = $"{Reservation.FirstName} {Reservation.LastName}";
            _reservationRoom = _hotelRoomsManager.GetRoomFromNumber(Reservation.RoomNumber) ?? throw new ArgumentNullException();
            _roomCategory = _hotelRoomsManager.GetRoomCategoryFromId(_reservationRoom.CategoryId) ?? throw new ArgumentNullException();
        }
        
    }
}
