using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            AllReservationStatus = new ObservableCollection<string> { ReservationStatus.Accepted.ToString(), ReservationStatus.Pending.ToString() };
            AddReservationCommand = new AdminAddReservationCommand(_connectedUser, this, _reservationManager, _parentViewModel,
                _userManager, _roomsManager, isDialogOpen);
        }
        private readonly HotelRoomsManager _roomsManager;
        private readonly ReservationManager _reservationManager;
        private readonly IUser _connectedUser;
        private readonly UserManager _userManager;
        /// <summary>
        /// gets all the categoris from the backend
        /// </summary>
        public ObservableCollection<string> AllCategories { get; }
        /// <summary>
        /// gets all the reservation status from the backend
        /// </summary>
        public ObservableCollection<string> AllReservationStatus { get; }
        private bool _emailHasError;
        /// <summary>
        /// This Porprety represnt if the email has any error
        /// </summary>
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
        private string? _error;
        /// <summary>
        /// This Property represents the error that was thrown on the add new user command
        /// </summary>
        /// <remarks>null if no exception was thrown during the command</remarks>
        public string? Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
                OnPropertyChanged(nameof(ExceptionErrorVisibility));
            }
        }
        /// <summary>
        /// This Proprety represents the visibility string of the erro
        /// </summary>
        /// <remarks>it gets setted auto depending on the state of the error message</remarks>
        public string ExceptionErrorVisibility => Error != null ? "Visible" : "Collapsed";

        private string? _firstName;
        /// <summary>
        /// gets and sets the first name field with OnPropretychanged
        /// </summary>
        public string? FirstName
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
        private string? _lastName;
        /// <summary>
        /// gets and sets the last name field with OnPropretychanged
        /// </summary>
        public string? LastName
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
                    IsEndDateEnabled = true;
                }
                else
                {
                    if (EndDate != null)
                    {
                        ChoosenEndDateInDateTime = null;
                    }
                    IsEndDateEnabled = false;
                }
                OnPropertyChanged(nameof(ChoosenStartDateInDateTime));
            }
        }
        private bool _isEndDateEnabled = false;
        /// <summary>
        /// gets a boolean that represents if the end date input is enabled
        /// </summary>
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
        private string? _email;
        /// <summary>
        /// gets and sets the Email field with OnPropretychanged
        /// </summary>
        public string? Email
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
        /// <summary>
        /// getss the choosen category from the category comboBox
        /// </summary>
        /// <remarks>This proprety can be null if no romm category is selected</remarks>
        public IRoomCategory? ReservedRoomCategory { get; private set; }
        /// <summary>
        /// gets the name of the selected room category
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
                    ReservedRoomCategory = _roomsManager.GetCategoryFromCategoryName(value);
                }
                catch (ArgumentNullException)
                {

                }
                OnPropertyChanged(nameof(ReserverdRoomCategoryName));
            }
        }
        /// <summary>
        /// getss the choosen status type from the resevation status comboBox
        /// </summary>
        /// <remarks>This proprety can be null if no status is selected</remarks>
        public ReservationStatus? ReservationStatusType { get; private set; }
        /// <summary>
        /// gets the string format of the ReservationStatusType
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
                if (value != null)
                {
                    ReservationStatusType = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), value);
                }
                OnPropertyChanged(nameof(ReservationChoosenStatusString));
            }
        }
        public ICommand AddReservationCommand { get; }

    }
}
