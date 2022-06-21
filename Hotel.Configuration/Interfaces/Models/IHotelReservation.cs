using Hotel.Configuration.Enums;

namespace Hotel.Configuration.Interfaces.Models
{
    public interface IHotelReservation
    {
        /// <summary>
        /// gets unique Id of the hotel reservation
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// gets the id of the user that created the reservation
        /// </summary>
        Guid CreationUserId { get; }
        /// <summary>
        /// gets the first name that's registered under the reservation
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// gets the last name that's registered under the reservation
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// gets the number of the booked room
        /// </summary>
        int RoomNumber { get; }
        /// <summary>
        /// gets the email that was used for this reservation
        /// </summary>
        string Email { get; }
        /// <summary>
        /// gets the start date of the reservation
        /// </summary>
        DateOnly StartDate { get; }
        /// <summary>
        /// gets the end date of the reservation
        /// </summary>
        DateOnly EndDate { get; }
        /// <summary>
        /// gets the date and time of when the reservation was created
        /// </summary>
        DateTime ReservationCreationTime { get; }
        /// <summary>
        /// gets the total price for the resevation depending on the amount of nights 
        /// </summary>
        double TotalPriceForNights { get; }
        /// <summary>
        /// gets and sets the status of reservation
        /// </summary>
        /// <remarks> the reservationStatus can be only Accepted or Declined or Pending</remarks>
        ReservationStatus ReservationStatus { get; set; }
    }
}