using Hotel.Configuration.Enums;

namespace Hotel.Configuration.Interfaces
{
    public interface IHotelReservation
    {
        Guid ReservationId { get; }
        Guid UserId { get; }
        Guid RoomId { get; }
        DateTime EndDate { get;  }
        DateTime ReservationDate { get;  }
        DateTime StartDate { get; }
        ReservationStatus ReservationStatus { get; }
    }
}