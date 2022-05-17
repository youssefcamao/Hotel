using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using Hotel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminInsertReservationViewModel : ViewModelBase
    {
        public AdminInsertReservationViewModel(HotelRoomsManager roomsManager, ReservationManager reservationManager)
        {
            _roomsManager = roomsManager;
            _reservationManager = reservationManager;
            AllCategories = new ObservableCollection<string>(_roomsManager.RoomCategories.Select(x => x.CategoryName));
            AllReservationStatus = new ObservableCollection<string>(Enum.GetNames(typeof(ReservationStatus)));
        }
        private readonly HotelRoomsManager _roomsManager;
        private readonly ReservationManager _reservationManager;

        public ObservableCollection<string> AllCategories { get; }
        public ObservableCollection<string> AllReservationStatus { get; }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private DateOnly? _startDate;
        public DateTime? StartDate
        {
            get
            {
                if(_startDate == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _startDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                _startDate = DateOnly.FromDateTime(value.Value);
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateOnly? _endDate;
        public DateTime? EndDate
        {
            get
            {
                if (_endDate == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _endDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                _endDate = DateOnly.FromDateTime(value.Value);
                OnPropertyChanged(nameof(EndDate));
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public IRoomCategory ReservedRoomCategory { get; private set; }

        public string ReserverdRoomCategoryName
        {
            get
            {
                if (ReservedRoomCategory == null)
                {
                    return string.Empty;
                }
                else
                {
                    return ReservedRoomCategory.CategoryName;
                }
            }
            set
            {
                try
                {
                    ReservedRoomCategory = _roomsManager.GetCategoryFromCategoryName(value);
                }
                catch (ArgumentNullException)
                {

                }
                OnPropertyChanged(nameof(ReserverdRoomCategoryName));
            }
        }
        public ReservationStatus? _reservationStatus { get; private set; }
        public string ReservationChoosenStatus
        {
            get
            {
                if (ReservedRoomCategory == null)
                {
                    return string.Empty ;
                }
                else
                {
                    return _reservationStatus.ToString();
                }
            }
            set
            {
                _reservationStatus = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), value);
                OnPropertyChanged(nameof(ReservationChoosenStatus));
            }
        }

        public ICommand AddReservation { get; }

    }
}
