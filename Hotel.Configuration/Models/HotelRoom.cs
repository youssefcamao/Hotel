using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models
{
    public class HotelRoom : IRoom
    {
        public HotelRoom(int roomNumber, bool isRoomAvailable, Guid categoryId)
        {
            RoomNumber = roomNumber;
            IsRoomAvailable = isRoomAvailable;
            CategoryId = categoryId;
        }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public int RoomNumber { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsRoomAvailable { get; set; }
        /// <summary>
        /// <inheritdoc/><br/>
        /// </summary>
        public Guid CategoryId { get; }

    }
}
