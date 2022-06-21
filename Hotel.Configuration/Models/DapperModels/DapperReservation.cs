using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperReservation : IHotelReservation
    {
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public Guid CreationUserId { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public int RoomNumber { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public DateOnly StartDate { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public DateOnly EndDate { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public DateTime ReservationCreationTime { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public double TotalPriceForNights { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public ReservationStatus ReservationStatus { get; set; }
    }
}
