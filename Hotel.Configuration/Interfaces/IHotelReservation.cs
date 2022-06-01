using Hotel.Configuration.Enums;

namespace Hotel.Configuration.Interfaces
{
    public interface IHotelReservation
    {
        Guid ReservationId { get; }
        Guid CreationUserId { get; }
        string FirstName { get; }
        string LastName { get; }
        int RoomNumber { get; }
        string Email { get; }
        DateOnly EndDate { get;  }
        DateTime ReservationCreationTime { get;  }
        DateOnly StartDate { get; }
        double TotalPriceForNights { get; }
        ReservationStatus ReservationStatus { get; set; }
    }
}