using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperReservation : IHotelReservation
    {
        public Guid Id { get; set; }

        public Guid CreationUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoomNumber { get; set; }

        public string Email { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateTime ReservationCreationTime { get; set; }

        public double TotalPriceForNights { get; set; }

        public ReservationStatus ReservationStatus { get; set; }
    }
}
