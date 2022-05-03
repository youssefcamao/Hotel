using Hotel.Configuration;
using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public class ReservationManager
    {
        private readonly UserManager _userManager;
        private readonly HotelRoomsManager _hotelRoomsManager;

        public ReservationManager(UserManager userManager, HotelRoomsManager hotelRoomsManager)
        {
            _userManager = userManager;
            _hotelRoomsManager = hotelRoomsManager;
            InitiateTestComponents();
        }
        public List<IHotelReservation> HotelRerservations { get; } = new List<IHotelReservation>();

        private void InitiateTestComponents()
        {
            var singleRoomCategory = _hotelRoomsManager.RoomCategories[0];
            var doubleRoomCategory = _hotelRoomsManager.RoomCategories[1];
            var ramonAdmin = _userManager.GetUserFromEmailPass("ramon@admin.com", "ramon123") ?? throw new ArgumentNullException("ramonUser Not found!");
            var paul = _userManager.GetUserFromEmailPass("paul@gmail.com", "paul123") ?? throw new ArgumentNullException("paulUser Not found!");
            var yousef = _userManager.GetUserFromEmailPass("youssef@gmail.com", "youssef123") ?? throw new ArgumentNullException("youssefUser Not found!");
            AddNewReservation(new DateOnly(2022,5,26),new DateOnly(2022,5,27), singleRoomCategory.CategoryId, yousef.Id);
            AddNewReservation(new DateOnly(2022,5,1),new DateOnly(2022,5,17), doubleRoomCategory.CategoryId, ramonAdmin.Id);
            AddNewReservation(new DateOnly(2022,5,26),new DateOnly(2022,5,31), singleRoomCategory.CategoryId, paul.Id);
            var declinedReservation = HotelRerservations.First(x => x.UserId == paul.Id) ?? throw new ArgumentNullException();
            ChangeStatusOfReservation(ramonAdmin, declinedReservation, ReservationStatus.Declined);
        }
        public void AddNewReservation(DateOnly startDate, DateOnly endDate, Guid roomCategoryId, Guid userId)
        {
            var roomCategory = _hotelRoomsManager.GetCategoryFromId(roomCategoryId);
            if (roomCategory == null)
            {
                throw new ArgumentNullException(nameof(roomCategory));
            }
            var reservationRoom = GetFreeRoomFromRoomNumberOnTimePeriod(startDate, endDate, roomCategory);
            if (reservationRoom == null)
            {
                throw new ArgumentNullException(nameof(reservationRoom));
            }
            var reservationTotalPrice = CalculateResrervationPrice(startDate, endDate, roomCategory);
            var reservationStatus = GetReservationStatusDependingOnUser(userId);
            HotelRerservations.Add(new HotelReservation(userId, reservationRoom.RoomNumber, startDate, endDate,
                reservationStatus, reservationTotalPrice));
        }
        public void ChangeStatusOfReservation(IUser user, IHotelReservation reservation, ReservationStatus status)
        {
            if (user.UserRole == UserRole.Admin)
            {
                if (reservation == null)
                {
                    throw new ArgumentNullException(nameof(reservation));
                }
                reservation.ReservationStatus = status;
            }
        }
        private ReservationStatus GetReservationStatusDependingOnUser(Guid userId)
        {
            var user = _userManager.GetUserFromId(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            switch (user.UserRole)
            {
                case UserRole.Admin:
                    return ReservationStatus.Accepted;
                case UserRole.NormalUser:
                    return ReservationStatus.Pending;
                default:
                    throw new ArgumentException($"Invalid {user.UserRole}");
            }
        }

        public IRoom? GetFreeRoomFromRoomNumberOnTimePeriod(DateOnly startDate, DateOnly endDate, IRoomCategory category)
        {
            var roomListInCategory = _hotelRoomsManager.HotelRoomsList.Where(x=> x.CategoryId == category.CategoryId).ToList();
            return roomListInCategory.FirstOrDefault(x => !CheckIfReservationPeriodOverlap(startDate, endDate, x));
        }
        /// <summary>
        /// return false if the period dosen't overlap
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        private bool CheckIfReservationPeriodOverlap(DateOnly startDate, DateOnly endDate, IRoom room)
        {
            var overlapReservationsCount = HotelRerservations.Count(x => (x.StartDate < endDate && startDate < x.EndDate) 
            && x.RoomNumber == room.RoomNumber);
            if (overlapReservationsCount == 0)
            {
                return false;
            }
            return true;
        }

        private double CalculateResrervationPrice(DateOnly startDate, DateOnly endDate, IRoomCategory roomCategory)
        {
            int nightsCount = (endDate.ToDateTime(new TimeOnly()) - startDate.ToDateTime(new TimeOnly())).Days;
            return nightsCount * roomCategory.RoomPriceForNight;
        }
    }
}
