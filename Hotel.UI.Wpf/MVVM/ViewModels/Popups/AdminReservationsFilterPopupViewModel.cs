using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands.Popups;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        /// <summary>
        /// gets all the categories from the core
        /// </summary>
        public ObservableCollection<string> AllCategories { get; }
        /// <summary>
        /// gets all the reservation status types
        /// </summary>
        public ObservableCollection<string> AllReservationStatus { get; }
        private bool _isNameFilterOn;
        /// <summary>
        /// gets and sets the filter checkbox for the name with OnPropretyChanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the filter checkbox for the price with OnPropretyChanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the filter checkbox for the status with OnPropretyChanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the filter checkbox for the room with OnPropretyChanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the filter checkbox for the date with OnPropretyChanged
        /// </summary>
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
        private string? _name;
        /// <summary>
        /// gets and sets the name field with OnPropretychanged
        /// </summary>
        public string? Name
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
        /// <summary>
        /// gets and sets the MinPrice field with OnPropretychanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the MaxPrice field with OnPropretychanged
        /// </summary>
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
        /// <summary>
        /// gets the selected room category
        /// </summary>
        public IRoomCategory ReservedRoomCategory { get; private set; }
        /// <summary>
        /// gets and sets string that represents the name of the selected room category
        /// </summary>
        public string? ReserverdRoomCategoryName
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
                if (value == null)
                {
                    return;
                }
                try
                {
                    ReservedRoomCategory = _roomsManager.GetCategoryFromCategoryName(value) ?? throw new ArgumentNullException();
                }
                catch (ArgumentNullException)
                {

                }
                OnPropertyChanged(nameof(ReserverdRoomCategoryName));
            }
        }
        /// <summary>
        /// gets and sets string that represents the selected ReservationStatusType
        /// </summary>
        public ReservationStatus? ReservationStatusType { get; private set; }
        /// <summary>
        /// gets and sets string that represents the selected ReservationStatusType
        /// </summary>
        public string? ReservationChoosenStatusString
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
        /// <summary>
        /// gets and Start Date filed with OnPropretychanged
        /// </summary>
        public DateOnly? StartDate { get; private set; }
        /// <summary>
        /// gets the start date in <see cref="DateTime"/> format
        /// </summary>
        public DateTime? ChoosenStartDateInDateTime
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
                OnPropertyChanged(nameof(ChoosenStartDateInDateTime));
            }
        }
        /// <summary>
        /// gets and End Date filed with OnPropretychanged
        /// </summary>
        public DateOnly? EndDate { get; private set; }
        /// <summary>
        /// gets the end date in <see cref="DateTime"/> format
        /// </summary>
        public DateTime? ChoosenEndDateInDateTime
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
                OnPropertyChanged(nameof(ChoosenEndDateInDateTime));
            }
        }

        public ICommand SaveFilterCommand { get; }

    }
}
