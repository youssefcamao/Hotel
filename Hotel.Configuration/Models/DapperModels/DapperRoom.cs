using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperRoom : IRoom
    {
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public int RoomNumber { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public bool IsRoomAvailable { get; set; }
    }
}
