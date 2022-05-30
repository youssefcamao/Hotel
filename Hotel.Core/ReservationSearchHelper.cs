using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public class ReservationSearchHelper
    {
        private readonly HotelRoomsManager _hotelRoomsManager;

        public ReservationSearchHelper(HotelRoomsManager hotelRoomsManager)
        {
            _hotelRoomsManager = hotelRoomsManager;
        }
        public List<IHotelReservation> GetReservationsFromName(List<IHotelReservation> hotelReservations, string name)
        {
            return hotelReservations.Where(x=> x.FirstName.ToLower().Contains(name.ToLower()) || x.LastName.ToLower().Contains(name.ToLower())).ToList();
        }
        public List<IHotelReservation> GetReservationsFromDateRange(List<IHotelReservation> hotelReservations, DateOnly? startDate, DateOnly? endDate)
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
            return hotelReservations.Where(x=> x.StartDate >= (startDate ?? new DateOnly()) && isEndDateApplying(x.EndDate, endDate)).ToList();
        }
        public List<IHotelReservation> GetReservationFromRoomType(List<IHotelReservation> hotelReservations, IRoomCategory roomCategory)
        {
            return hotelReservations.Where(x=> GetIfReservationCategoryMatches(x, roomCategory)).ToList();
        }
        public List<IHotelReservation> GetReservationsFromStatus(List<IHotelReservation> hotelReservations, ReservationStatus status)
        {
            return hotelReservations.Where(x=> x.ReservationStatus == status).ToList();
        }
        public List<IHotelReservation> GetReservationsFromPriceRange(List<IHotelReservation> hotelReservations, double? minPrice, double? maxPrice)
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
                return room.CategoryId == Category.CategoryId;
            }
        }
    }
}
