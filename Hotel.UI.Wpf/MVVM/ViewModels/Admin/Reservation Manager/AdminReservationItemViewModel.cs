using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core.Managers;
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
        /// <summary>
        /// gets the reservation of the viewModel
        /// </summary>
        public IHotelReservation Reservation { get; }
        /// <summary>
        /// gets the roomNumber from the reservation of the viewModel
        /// </summary>
        public int RoomNumber => Reservation.RoomNumber;
        /// <summary>
        /// gets the room type from the reservation of the viewModel
        /// </summary>
        public string RoomType => _roomCategory.CategoryName;
        /// <summary>
        /// gets the name the full name of the registred person in the reservation
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// gets the start date of the reservation
        /// </summary>
        public DateOnly StartDate => Reservation.StartDate;
        /// <summary>
        /// gets the end date of the reservation
        /// </summary>
        /// <remarks> end date must be after the start date</remarks>
        public DateOnly EndDate => Reservation.EndDate;
        /// <summary>
        /// gets the totalPrice from the reservation of the viewModel
        /// </summary>
        public double TotalPrice => Reservation.TotalPriceForNights;
        /// <summary>
        /// gets the status from the reservation of the viewModel
        /// </summary>
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
        /// <summary>
        /// gets the string that represents the visibility of the the repond to reservation menu item
        /// </summary>
        /// <remarks> the string must be either Visible or Collapsed</remarks>
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
