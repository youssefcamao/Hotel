using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
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
        public AdminInsertReservationViewModel(HotelRoomsManager roomsManager, ReservationManager reservationManager,
            IUser _connectedUser, AdminViewModel _parentViewModel, UserManager userManager)
        {
            _roomsManager = roomsManager;
            _reservationManager = reservationManager;
            this._connectedUser = _connectedUser;
            _userManager = userManager;
            AllCategories = new ObservableCollection<string>(_roomsManager.RoomCategories.Select(x => x.CategoryName));
            AllReservationStatus = new ObservableCollection<string>(Enum.GetNames(typeof(ReservationStatus)));
            AddReservationCommand = new AddReservationCommand(_connectedUser, this, _reservationManager, _parentViewModel, _userManager, _roomsManager);
        }
        private readonly HotelRoomsManager _roomsManager;
        private readonly ReservationManager _reservationManager;
        private readonly IUser _connectedUser;
        private readonly UserManager _userManager;

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
        public DateOnly? StartDate { get; private set; }
        public DateTime? ChoosenStartDateString
        {
            get
            {
                if(StartDate == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return StartDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                StartDate = DateOnly.FromDateTime(value.Value);
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
                    return DateTime.Now;
                }
                else
                {
                    return EndDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                EndDate = DateOnly.FromDateTime(value.Value);
                OnPropertyChanged(nameof(ChoosenEndDateString));
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
        public ReservationStatus? ReservationStatus { get; private set; }
        public string ReservationChoosenStatusString
        {
            get
            {
                if (ReservedRoomCategory == null)
                {
                    return string.Empty ;
                }
                else
                {
                    return ReservationStatus.ToString();
                }
            }
            set
            {
                ReservationStatus = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), value);
                OnPropertyChanged(nameof(ReservationChoosenStatusString));
            }
        }

        public ICommand AddReservationCommand { get; }

    }
}
