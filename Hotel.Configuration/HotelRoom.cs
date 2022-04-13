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
        public HotelRoom()
        {
            CategoryId = Guid.NewGuid();
        }
        public int RoomNumber { get; set; }
        public bool IsRoomAvailable { get; set; }

        public Guid Id { get; }

        public Guid CategoryId { get; }

    }
}
