using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands.Popups;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Popups
{
    public class AdminReservationsFilterPopupViewModel : ViewModelBase
    {
        public AdminReservationsFilterPopupViewModel(HotelRoomsManager roomsManager, ReservationManager reservationManager,
            UserManager userManager, ObservableCollection<AdminReservationItemViewModel> reservationsViewModel)
        {
            _roomsManager = roomsManager;
            _reservationManager = reservationManager;
            _userManager = userManager;
            AllCategories = new ObservableCollection<string>(_roomsManager.RoomCategories.Select(x => x.CategoryName));
            AllReservationStatus = new ObservableCollection<string>(Enum.GetNames(typeof(ReservationStatus)));
            SaveFilterCommand = new SaveFilterSettingsCommand(this, _reservationManager, _roomsManager,
               _userManager, reservationsViewModel);
        }
        private readonly HotelRoomsManager _roomsManager;
        private readonly ReservationManager _reservationManager;
        private readonly UserManager _userManager;

        public ObservableCollection<string> AllCategories { get; }
        public ObservableCollection<string> AllReservationStatus { get; }
        private bool _isNameFilterOn;
        public bool IsNameFilterOn
        {
            get
            {
                return _isNameFilterOn;
            }
            set
            {
                _isNameFilterOn = value;
                OnPropertyChanged(nameof(IsNameFilterOn));
            }
        }
        private bool _isPriceFilterON;
        public bool IsPriceFilterON
        {
            get
            {
                return _isPriceFilterON;
            }
            set
            {
                _isPriceFilterON = value;
                OnPropertyChanged(nameof(IsPriceFilterON));
            }
        }

        private bool _isStatusFilterOn;
        public bool IsStatusFilterOn
        {
            get
            {
                return _isStatusFilterOn;
            }
            set
            {
                _isStatusFilterOn = value;
                OnPropertyChanged(nameof(IsStatusFilterOn));
            }
        }
        private bool _isRoomFilterOn;
        public bool IsRoomTypeFilterOn
        {
            get
            {
                return _isRoomFilterOn;
            }
            set
            {
                _isRoomFilterOn = value;
                OnPropertyChanged(nameof(IsRoomTypeFilterOn));
            }
        }
        private bool _isDateFilterOn;
        public bool IsDateFilterOn
        {
            get
            {
                return _isDateFilterOn;
            }
            set
            {
                _isDateFilterOn = value;
                OnPropertyChanged(nameof(IsDateFilterOn));
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private double? _minPrice;
        public double? MinPrice
        {
            get
            {
                return _minPrice;
            }
            set
            {
                _minPrice = value;
                OnPropertyChanged(nameof(MinPrice));
            }
        }
        private double? _maxPrice;
        public double? MaxPrice
        {
            get
            {
                return _maxPrice;
            }
            set
            {
                _maxPrice = value;
                OnPropertyChanged(nameof(MaxPrice));
            }
        }
        public IRoomCategory ReservedRoomCategory { get; private set; }

        public string ReserverdRoomCategoryName
        {
            get
            {
                if (ReservedRoomCategory == null)
                {
                    return null;
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
        public ReservationStatus? ReservationStatusType { get; private set; }
        public string ReservationChoosenStatusString
        {
            get
            {
                if (ReservedRoomCategory == null)
                {
                    return null;
                }
                else
                {
                    return ReservationStatusType.ToString();
                }
            }
            set
            {
                ReservationStatusType = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), value);
                OnPropertyChanged(nameof(ReservationChoosenStatusString));
            }
        }
        public DateOnly? StartDate { get; private set; }
        public DateTime? ChoosenStartDateString
        {
            get
            {
                if (StartDate == null)
                {
                    return null;
                }
                else
                {
                    return StartDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                if (value != null)
                {
                    StartDate = DateOnly.FromDateTime(value.Value);
                }
                OnPropertyChanged(nameof(ChoosenStartDateString));
            }
        }
        public DateOnly? EndDate { get; private set; }
        public DateTime? ChoosenEndDateString
        {
            get
            {
                if (EndDate == null)
                {
                    return null;
                }
                else
                {
                    return EndDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                if (value == null)
                {
                    EndDate = null;
                }
                else
                {
                    EndDate = DateOnly.FromDateTime(value.Value);
                }
                OnPropertyChanged(nameof(ChoosenEndDateString));
            }
        }

        public ICommand SaveFilterCommand { get; }
    }
}
