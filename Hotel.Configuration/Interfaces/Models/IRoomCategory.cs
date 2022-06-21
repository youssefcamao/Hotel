namespace Hotel.Configuration.Interfaces.Models
{
    public interface IRoomCategory
    {
        /// <summary>
        /// gets the id of the room category
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// gets the name of the category name
        /// </summary>
        string CategoryName { get; }
        /// <summary>
        /// gets the description of the room
        /// <remark> the description must inclunde the advantages of the room and the number of the allowed people</remark>
        /// </summary>
        string Description { get; }
        /// <summary>
        /// gets the price of 1 night in this room
        /// </summary>
        double RoomPriceForNight { get; }
    }
}
