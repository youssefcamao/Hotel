using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using System;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationItemViewModel : ViewModelBase
    {
        private IRoomCategory _roomCategory;
        private readonly UserManager _userManager;
        private HotelRoomsManager _hotelRoomsManager;
        private readonly ReservationManager _reservationManager;
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
                if (Reservation != null)
                {
                    _reservationManager.ChangeStatusOfReservation(Reservation, value);
                }
                OnPropertyChanged(nameof(Status));
                OnPropertyChanged(nameof(IsRespondToReservationVisible));
            }
        }
        public string IsRespondToReservationVisible => Reservation.ReservationStatus == Configuration.Enums.ReservationStatus.Pending ? "Visible" : "Collapsed";

        public AdminReservationItemViewModel(IHotelReservation reservation, UserManager userManager, 
            HotelRoomsManager hotelRoomsManager, ReservationManager reservationManager)
        {
            Reservation = reservation;
            _userManager = userManager;
            _hotelRoomsManager = hotelRoomsManager;
            _reservationManager = reservationManager;
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
