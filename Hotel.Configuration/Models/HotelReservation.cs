using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models
{
    public class HotelReservation : IHotelReservation
    {
        public HotelReservation(Guid userId, int roomNumber, DateOnly startDate, DateOnly endDate,
            ReservationStatus reservationStatus, double totalPrice, string firstName, string lastName, string email)
        {
            ReservationCreationTime = DateTime.Now;
            Id = Guid.NewGuid();
            CreationUserId = userId;
            RoomNumber = roomNumber;
            StartDate = startDate;
            EndDate = endDate;
            TotalPriceForNights = totalPrice;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ReservationStatus = reservationStatus;
        }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public DateTime ReservationCreationTime { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public DateOnly StartDate { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public DateOnly EndDate { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public int RoomNumber { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public double TotalPriceForNights { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public Guid CreationUserId { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public string LastName { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public string Email { get; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public ReservationStatus ReservationStatus { get; set; }


    }
}
