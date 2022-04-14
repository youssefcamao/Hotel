using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationItemViewModel : ViewModelBase
    {
        private readonly IHotelReservation _reservation;

        public int RoomNumber => _reservation.RoomNumber;
        public string Name { get;}
        public string StartDate => GetCustomDateStringFormat(_reservation.StartDate);
        public string EndDate => GetCustomDateStringFormat(_reservation.EndDate);
        public string TotalPrice => $"{_reservation.TotalPriceForNights} €";
        public string Status => _reservation.ReservationStatus.ToString();

        public AdminReservationItemViewModel(IHotelReservation reservation, string name)
        {
            _reservation = reservation;
            Name = name;
        }
        private string GetCustomDateStringFormat(DateOnly date)
        {
            var day = date.Day > 9 ? $"{date.Day}": $"{date.Day}";
            return $"{date.ToString("MMMM")} {day},{date.Year}";
        }
    }
}
