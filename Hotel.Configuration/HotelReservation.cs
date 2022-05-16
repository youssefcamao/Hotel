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
        public HotelReservation(Guid userId, int roomNumber, DateOnly startDate, DateOnly endDate, 
            ReservationStatus reservationStatus, double totalPrice, string email)
        {
            ReservationDate = DateTime.Now;
            ReservationId = Guid.NewGuid();
            UserId = userId;
            RoomNumber = roomNumber;
            StartDate = startDate;
            EndDate = endDate;
            TotalPriceForNights = totalPrice;
            Email = email;
            ReservationStatus = reservationStatus;
        }
        public DateTime ReservationDate { get;  }
        public DateOnly StartDate { get;  }
        public DateOnly EndDate { get;  }
        public int RoomNumber { get; }
        public double TotalPriceForNights { get; }
        public Guid ReservationId { get; }

        public Guid UserId { get; }
        public string Email { get; }

        public ReservationStatus ReservationStatus { get; set; }
    }
}
