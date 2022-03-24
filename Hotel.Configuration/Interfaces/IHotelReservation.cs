namespace Hotel.Configuration.Interfaces
{
    public interface IHotelReservation
    {
        string Email { get; set; }
        DateTime EndDate { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime ReservationDate { get; set; }
        DateTime StartDate { get; set; }
    }
}