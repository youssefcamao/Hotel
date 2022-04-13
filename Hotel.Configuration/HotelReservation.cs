using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration
{
    public class HotelReservation : IHotelReservation
    {
        public DateTime ReservationDate { get;  } = DateTime.Now;
        public DateTime StartDate { get;  }
        public DateTime EndDate { get;  }
        public Guid RoomId { get; }

        public Guid ReservationId { get; }

        public Guid UserId { get; }

        public ReservationStatus ReservationStatus { get; }
    }
}
