using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Core
{
    public class ReservationSearchHelper
    {
        private readonly HotelRoomsManager _hotelRoomsManager;

        public ReservationSearchHelper(HotelRoomsManager hotelRoomsManager)
        {
            _hotelRoomsManager = hotelRoomsManager;
        }

        /// <summary>
        /// This method filters a list of IHotelReservation by the name with using LINQ's Where() to extract all reservations that contain the input first or last name.
        /// </summary>
        /// <param name="hotelReservations"></param>
        /// <param name="name"></param>
        /// <returns>A filtered list of IHotelReservation that is filtered by the name.</returns>
        public List<IHotelReservation> GetReservationsFromName(IList<IHotelReservation> hotelReservations, string name)
        {
            return hotelReservations.Where(x => x.FirstName.ToLower().Contains(name.ToLower()) || x.LastName.ToLower().Contains(name.ToLower())).ToList();
        }

        /// <summary>
        /// This method filters a list of IHotelReserveration by the date with using LINQ's Where() to extract all dates that are in the range of the start date to end date.
        /// </summary>
        /// <param name="hotelReservations"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>A filtered list of IHotelReservation where the reserverations are in the range of the start and end date.</returns>
        public List<IHotelReservation> GetReservationsFromDateRange(IList<IHotelReservation> hotelReservations, DateOnly? startDate, DateOnly? endDate)
        {
            Func<DateOnly, DateOnly?, bool> isEndDateApplying = (endDate, targetedEndDate) =>
            {
                if (targetedEndDate == null)
                {
                    return true;
                }
                else
                {
                    return endDate <= targetedEndDate;
                }
            };
            return hotelReservations.Where(x => x.StartDate >= (startDate ?? new DateOnly()) && isEndDateApplying(x.EndDate, endDate)).ToList();
        }

        /// <summary>
        /// This method filters a list of IHotelReservation by the IRoomCategory with using LINQ's Where() to extract all reservations that contain the chosen IRoomCategory.
        /// </summary>
        /// <param name="hotelReservations"></param>
        /// <param name="roomCategory"></param>
        /// <returns>A filtered list of IHotelReservation from a list IHotelReservation with IRoomCategory as filter.</returns>
        public List<IHotelReservation> GetReservationFromRoomType(IList<IHotelReservation> hotelReservations, IRoomCategory roomCategory)
        {
            return hotelReservations.Where(x => GetIfReservationCategoryMatches(x, roomCategory)).ToList();
        }

        /// <summary>
        /// This method filters a list of IHotelReservation by the status with using LINQ's Where() to extract all reservations that contain the chosen status.
        /// </summary>
        /// <param name="hotelReservations"></param>
        /// <param name="status"></param>
        /// <returns>A filtered list of IHotelReservation that is filtered by ReservationStatus.</returns>
        public List<IHotelReservation> GetReservationsFromStatus(IList<IHotelReservation> hotelReservations, ReservationStatus status)
        {
            return hotelReservations.Where(x => x.ReservationStatus == status).ToList();
        }

        /// <summary>
        /// This method filters a list of IHotelReserveration by the price with using LINQ's Where() to extract all prices that are in the range of the min and max price.
        /// </summary>
        /// <param name="hotelReservations"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns>A filtered list of IHotelReservation where the reserverations are in the range of the min and max price.</returns>
        public List<IHotelReservation> GetReservationsFromPriceRange(IList<IHotelReservation> hotelReservations, double? minPrice, double? maxPrice)
        {
            Func<double, double?, bool> isMaxPriceApplying = (maxPrice, targetedMaxPrice) =>
            {
                if (targetedMaxPrice == null)
                {
                    return true;
                }
                else
                {
                    return maxPrice <= targetedMaxPrice;
                }
            };
            return hotelReservations.Where(x => x.TotalPriceForNights >= (minPrice ?? 0) && isMaxPriceApplying(x.TotalPriceForNights, maxPrice)).ToList();
        }

        private bool GetIfReservationCategoryMatches(IHotelReservation reservation, IRoomCategory Category)
        {
            var room = _hotelRoomsManager.GetRoomFromNumber(reservation.RoomNumber);
            if (room == null)
            {
                return false;
            }
            else
            {
                return room.CategoryId == Category.Id;
            }
        }
    }
}
