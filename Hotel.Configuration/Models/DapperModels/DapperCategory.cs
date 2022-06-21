using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperCategory : IRoomCategory
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
        public string CategoryName { get; set; } = String.Empty;
        
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string Description { get; set; } = String.Empty;
        
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public double RoomPriceForNight { get; set; }
    }
}
