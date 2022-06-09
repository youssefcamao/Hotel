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
        public int RoomNumber { get; set; }
        public bool IsRoomAvailable { get; set; }
        public Guid CategoryId { get; }

    }
}
