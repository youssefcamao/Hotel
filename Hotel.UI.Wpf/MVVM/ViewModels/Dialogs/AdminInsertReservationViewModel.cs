using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using MaterialDesignThemes.Wpf;
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
            IUser _connectedUser, AdminViewModel _parentViewModel, UserManager userManager, bool isDialogOpen)
        {
            _roomsManager = roomsManager;
            _reservationManager = reservationManager;
            this._connectedUser = _connectedUser;
            _userManager = userManager;
            AllCategories = new ObservableCollection<string>(_roomsManager.RoomCategories.Select(x => x.CategoryName));
            AllReservationStatus = new ObservableCollection<string> { ReservationStatus.Accepted.ToString(), ReservationStatus.Pending.ToString()};
            AddReservationCommand = new AddReservationCommand(_connectedUser, this, _reservationManager, _parentViewModel,
                _userManager, _roomsManager, isDialogOpen);
        }
        private readonly HotelRoomsManager _roomsManager;
        private readonly ReservationManager _reservationManager;
        private readonly IUser _connectedUser;
        private readonly UserManager _userManager;

        public ObservableCollection<string> AllCategories { get; }
        public ObservableCollection<string> AllReservationStatus { get; }
        private bool _emailHasError;
        public bool EmailHasError
        {
            get
            {
                return _emailHasError;
            }
            set
            {
                _emailHasError = value;
                OnPropertyChanged(nameof(EmailHasError));
            }
        }

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
                    return null;
                }
                else
                {
                    return StartDate.Value.ToDateTime(new TimeOnly());
                }
            }
            set
            {
                StartDate = DateOnly.FromDateTime(value.Value);
                if (StartDate != null)
                {
                    IsEndDateEnabled = true;
                }
                else
                {
                    IsEndDateEnabled = false;
                }
                OnPropertyChanged(nameof(ChoosenStartDateString));
            }
        }
        private bool _isEndDateEnabled = false;
        public bool IsEndDateEnabled
        {
            get
            {
                return _isEndDateEnabled;
            }
            set
            {
                _isEndDateEnabled = value;
                OnPropertyChanged(nameof(IsEndDateEnabled));
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
                    return null ;
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
        public ICommand AddReservationCommand { get; }

    }
}
