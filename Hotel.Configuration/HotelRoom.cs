using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration
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
