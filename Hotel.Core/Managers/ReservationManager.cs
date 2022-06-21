using Hotel.Configuration.Enums;
using Hotel.Configuration.Exceptions;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models;

namespace Hotel.Core
{
    public class ReservationManager
    {
        private readonly HotelRoomsManager _hotelRoomsManager;
        private readonly IRepository<IHotelReservation> _reservationsRepo;

        public ReservationManager(HotelRoomsManager hotelRoomsManager, IRepository<IHotelReservation> reservationsRepo)
        {
            _hotelRoomsManager = hotelRoomsManager;
            _reservationsRepo = reservationsRepo;
        }
        /// <summary>
        /// gets all <see cref="IHotelReservation"/> from the repository
        /// </summary>
        public IList<IHotelReservation> HotelRerservations => _reservationsRepo.GetAll();
        /// <summary>
        /// This Method adds a new reservation
        /// <para>if roomCategory is null <see cref="ArgumentNullException"/> is thrown</para>
        /// <para>if available room is not found <see cref="NoRoomFoundException"/> is thrown</para>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="roomCategoryId"></param>
        /// <param name="userId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="reservationStatus"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NoRoomFoundException"></exception>
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
            firstName = NamingHelper.FixNameFormat(firstName);
            lastName = NamingHelper.FixNameFormat(lastName);
            var status = reservationStatus ?? ReservationStatus.Pending;
            var reservation = new HotelReservation(userId, reservationRoom.RoomNumber, startDate, endDate,
                    status, reservationTotalPrice, firstName, lastName, email);
            _reservationsRepo.CreateNewModel(reservation);
        }
        /// <summary>
        /// This Method Changes the status of a given <see cref="IHotelReservation"/>
        /// </summary>
        /// <remarks> if reservation not found <see cref="ArgumentNullException"/> is thrown</remarks>
        /// <param name="reservation"></param>
        /// <param name="status"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void ChangeStatusOfReservation(IHotelReservation reservation, ReservationStatus status)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            reservation.ReservationStatus = status;
            _reservationsRepo.UpdateModel(reservation);
        }
        /// <summary>
        /// This Method checks if a room is available from the given category on the given start and end date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="category"></param>
        /// <returns> <see cref="IRoom"/> if found and null if not</returns>
        public IRoom? GetFreeRoomFromRoomNumberOnTimePeriod(DateOnly startDate, DateOnly endDate, IRoomCategory category)
        {
            var roomList = _hotelRoomsManager.HotelRoomsList;
            var roomListInCategory = roomList.Where(x => x.CategoryId == category.Id).ToList();
            return roomListInCategory.FirstOrDefault(x => !CheckIfReservationPeriodOverlap(startDate, endDate, x));
        }

        /// <summary>
        /// This Method deletes a reservation from its id
        /// </summary>
        /// <remarks>if reservation is not found <see cref="ArgumentNullException"/> is thrown</remarks>
        /// <param name="reservationId"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteReservationFromId(Guid reservationId)
        {
            var reservation = HotelRerservations.FirstOrDefault(x => x.Id == reservationId);
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            _reservationsRepo.DeleteModel(reservation);
        }
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
    }
}
