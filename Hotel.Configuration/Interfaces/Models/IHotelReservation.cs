using Hotel.Configuration.Enums;

namespace Hotel.Configuration.Interfaces.Models
{
    public interface IHotelReservation
    {
        Guid Id { get; }
        Guid CreationUserId { get; }
        string FirstName { get; }
        string LastName { get; }
        int RoomNumber { get; }
        string Email { get; }
        DateOnly StartDate { get; }
        DateOnly EndDate { get; }
        DateTime ReservationCreationTime { get; }
        double TotalPriceForNights { get; }
        ReservationStatus ReservationStatus { get; set; }
    }
}