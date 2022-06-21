using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.Services;
using System;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminShowDetailsViewModel : ViewModelBase
    {
        private readonly IHotelReservation _hotelReservation;
        private readonly ReservationManager _reservationManager;
        private readonly HotelRoomsManager _hotelRoomsManager;
        private readonly UserManager _userManager;

        public AdminShowDetailsViewModel(object paramater, ReservationManager reservationManager,
            HotelRoomsManager hotelRoomsManager, UserManager userManager)
        {
            if (paramater is AdminReservationItemViewModel param)
            {
                _hotelReservation = param.Reservation;
            }
            else
            {
                throw new ArgumentNullException(nameof(paramater));
            }
            _reservationManager = reservationManager;
            _hotelRoomsManager = hotelRoomsManager;
            _userManager = userManager;
        }
        //Main Info
        /// <summary>
        /// gets the first name from the <see cref="IHotelReservation"/> field
        /// </summary>
        public string FirstName => _hotelReservation.FirstName;
        /// <summary>
        /// gets the last name from the <see cref="IHotelReservation"/> field
        /// </summary>
        public string LastName => _hotelReservation.LastName;
        /// <summary>
        /// gets start date from the <see cref="IHotelReservation"/> field
        /// </summary>
        public DateOnly StartDate => _hotelReservation.StartDate;
        /// <summary>
        /// gets the end date from the <see cref="IHotelReservation"/> field
        /// </summary>
        public DateOnly EndDate => _hotelReservation.EndDate;
        /// <summary>
        /// gets the room number from the <see cref="IHotelReservation"/> field
        /// </summary>
        public int RoomNumber => _hotelReservation.RoomNumber;
        /// <summary>
        /// gets the room category name from <see cref="IHotelReservation"/> field
        /// </summary>
        public string RoomCategoryName => GetRoomCategoryNameFromRoomNumber(_hotelReservation.RoomNumber);
        /// <summary>
        /// gets the reservation status name from <see cref="IHotelReservation"/> field
        /// </summary>
        public ReservationStatus ReservationStatus => _hotelReservation.ReservationStatus;
        /// <summary>
        /// gets the total price from <see cref="IHotelReservation"/> field
        /// </summary>
        public double TotalPriceForNights => _hotelReservation.TotalPriceForNights;
        /// <summary>
        /// gets the email from <see cref="IHotelReservation"/> field
        /// </summary>
        public string Email => _hotelReservation.Email;

        //Advanced Info
        /// <summary>
        /// gets the reservation creation time and date <see cref="IHotelReservation"/> field
        /// </summary>
        public DateTime ReservationCreationTime => _hotelReservation.ReservationCreationTime;
        /// <summary>
        /// gets role/name of the creation user <see cref="IHotelReservation"/> field
        /// </summary>
        public string CreationUser => GetUserNameFromUserId(_hotelReservation.CreationUserId);
        /// gets id of the reservation <see cref="IHotelReservation"/> field
        public Guid ReservationId => _hotelReservation.Id;

        private string GetRoomCategoryNameFromRoomNumber(int roomNumber)
        {
            var room = _hotelRoomsManager.GetRoomFromNumber(roomNumber);
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }
            var category = _hotelRoomsManager.GetRoomCategoryFromId(room.CategoryId) ?? throw new ArgumentNullException();
            return category.CategoryName;
        }
        private string GetUserNameFromUserId(Guid userId)
        {
            var user = _userManager.GetUserFromId(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return UserHelperService.GetUserNameFromUser(user);
        }
    }
}
