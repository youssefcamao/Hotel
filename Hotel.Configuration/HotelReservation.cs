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
            ReservationStatus reservationStatus, double totalPrice, string firstName, string lastName, string email)
        {
            ReservationDate = DateTime.Now;
            ReservationId = Guid.NewGuid();
            CreationUserId = userId;
            RoomNumber = roomNumber;
            StartDate = startDate;
            EndDate = endDate;
            TotalPriceForNights = totalPrice;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ReservationStatus = reservationStatus;
        }
        public DateTime ReservationDate { get;  }
        public DateOnly StartDate { get;  }
        public DateOnly EndDate { get;  }
        public int RoomNumber { get; }
        public double TotalPriceForNights { get; }
        public Guid ReservationId { get; }

        public Guid CreationUserId { get; }
        public string FirstName { get; }

        public string LastName { get; }
        public string Email { get; }

        public ReservationStatus ReservationStatus { get; set; }

        
    }
}
