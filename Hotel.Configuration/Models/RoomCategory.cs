using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models
{
    public class RoomCategory : IRoomCategory
    {
        public RoomCategory(string categoryName, string description, double roomPrice)
        {
            CategoryName = categoryName;
            Description = description;
            RoomPriceForNight = roomPrice;
            Id = Guid.NewGuid();
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string CategoryName { get; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public double RoomPriceForNight { get; }

    }
}
