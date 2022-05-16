using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminInsertReservationViewModel : ViewModelBase
    {
        public string FullName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public IRoomCategory ChoosenRoomCategory { get; set; }

    }
}
