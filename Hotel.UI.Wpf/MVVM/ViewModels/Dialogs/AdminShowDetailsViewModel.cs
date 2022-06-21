using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.Ui_Helpers;
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
        public string FirstName => _hotelReservation.FirstName;
        public string LastName => _hotelReservation.LastName;
        public DateOnly StartDate => _hotelReservation.StartDate;
        public DateOnly EndDate => _hotelReservation.EndDate;
        public int RoomNumber => _hotelReservation.RoomNumber;
        public string RoomCategoryName => GetRoomCategoryNameFromRoomNumber(_hotelReservation.RoomNumber);
        public ReservationStatus ReservationStatus => _hotelReservation.ReservationStatus;
        public double TotalPriceForNights => _hotelReservation.TotalPriceForNights;
        public string Email => _hotelReservation.Email;

        //Advanced Info
        public DateTime ReservationCreationTime => _hotelReservation.ReservationCreationTime;
        public string CreationUser => GetUserNameFromUserId(_hotelReservation.CreationUserId);
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
