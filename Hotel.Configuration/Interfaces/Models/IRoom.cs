namespace Hotel.Configuration.Interfaces.Models
{
    public interface IRoom
    {
        /// <summary>
        /// gets the id of the category that the room belongs to
        /// </summary>
        Guid CategoryId { get; }
        /// <summary>
        /// get and set the boolean tha represents if a room is available
        /// </summary>
        bool IsRoomAvailable { get; set; }
        /// <summary>
        /// gets the number of the room
        /// </summary>
        int RoomNumber { get; }
    }
}
