using Hotel.Configuration.Enums;
using Hotel.Configuration.Exceptions;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models;

namespace Hotel.Core
{
    public class ReservationManager
    {
        private readonly UserManager _userManager;
        private readonly HotelRoomsManager _hotelRoomsManager;
        private readonly IRepository<IHotelReservation> _reservationsRepo;

        public ReservationManager(UserManager userManager, HotelRoomsManager hotelRoomsManager, IRepository<IHotelReservation> reservationsRepo)
        {
            _userManager = userManager;
            _hotelRoomsManager = hotelRoomsManager;
            _reservationsRepo = reservationsRepo;
        }
        public IList<IHotelReservation> HotelRerservations => _reservationsRepo.GetAll();

        public void AddNewReservation(DateOnly startDate, DateOnly endDate, Guid roomCategoryId, Guid userId,
            string firstName, string lastName, string email, ReservationStatus? reservationStatus)
        {
            var roomCategory = _hotelRoomsManager.GetCategoryFromId(roomCategoryId);
            if (roomCategory == null)
            {
                throw new ArgumentNullException(nameof(roomCategory));
            }
            var reservationRoom = GetFreeRoomFromRoomNumberOnTimePeriod(startDate, endDate, roomCategory);
            if (reservationRoom == null)
            {
                throw new NoRoomFoundException();
            }
            var reservationTotalPrice = CalculateResrervationPrice(startDate, endDate, roomCategory);
            //Clean Naming
            firstName = NamingHelper.FixNameFormat(firstName);
            lastName = NamingHelper.FixNameFormat(lastName);

            var status = reservationStatus ?? ReservationStatus.Pending;
            var reservation = new HotelReservation(userId, reservationRoom.RoomNumber, startDate, endDate,
                    status, reservationTotalPrice, firstName, lastName, email);
            _reservationsRepo.CreateNewModel(reservation);
        }


        public void ChangeStatusOfReservation(IHotelReservation reservation, ReservationStatus status)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            reservation.ReservationStatus = status;
            _reservationsRepo.UpdateModel(reservation);
        }

        public IRoom? GetFreeRoomFromRoomNumberOnTimePeriod(DateOnly startDate, DateOnly endDate, IRoomCategory category)
        {
            var roomList = _hotelRoomsManager.HotelRoomsList;
            var roomListInCategory = roomList.Where(x => x.CategoryId == category.Id).ToList();
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
            && x.RoomNumber == room.RoomNumber && x.ReservationStatus != ReservationStatus.Declined);
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
        public void DeleteReservationFromId(Guid reservationId)
        {
            var reservation = HotelRerservations.FirstOrDefault(x => x.Id == reservationId);
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            _reservationsRepo.DeleteModel(reservation);
        }
    }
}
