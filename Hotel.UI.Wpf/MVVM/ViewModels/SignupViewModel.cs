using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Stores;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly UserManager _userManager;

        public SignupViewModel(NavigationStore navigationStore, UserManager userManager)
        {
            _navigationStore = navigationStore;
            _userManager = userManager;
            CancelSignUpCommand = new CancelSignUpCommand(_navigationStore);
            CreateNewNormalUserCommand = new CreateNormalUserAccountCommand(_userManager, this, _navigationStore);
        }
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
        private string? _password;
        /// <summary>
        /// gets and sets the password field with OnPropretychanged
        /// </summary>
        public string? Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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
        public string? ExceptionErrorVisibility => Error != null ? "Visible" : "Collapsed";
        public ICommand CancelSignUpCommand { get; }
        public ICommand CreateNewNormalUserCommand { get; }
    }
}
