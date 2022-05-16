using Hotel.Configuration.Enums;

namespace Hotel.Configuration.Interfaces
{
    public interface IHotelReservation
    {
        Guid ReservationId { get; }
        Guid UserId { get; }
        int RoomNumber { get; }
        string Email { get; }
        DateOnly EndDate { get;  }
        DateTime ReservationDate { get;  }
        DateOnly StartDate { get; }
        double TotalPriceForNights { get; }
        ReservationStatus ReservationStatus { get; set; }
    }
}