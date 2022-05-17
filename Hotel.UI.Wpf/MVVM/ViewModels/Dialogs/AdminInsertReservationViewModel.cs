using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminInsertReservationViewModel : ViewModelBase
    {
        public AdminInsertReservationViewModel()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Email { get; set; }
        public string RoomCategoryName { get; set; }
        public string StatusString { get; set; }
        public ReservationStatus ReservationStatus => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), StatusString);
        public IRoomCategory ChoosenRoomCategory { get; }

        public ICommand AddReservation { get; }

    }
}
