using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminAddNewUserDialogViewModel : ViewModelBase
    {
        private readonly UserManager _userManager;
        private readonly AdminUserManagerViewModel _adminUserManagerViewModel;
        public AdminAddNewUserDialogViewModel(UserManager userManager, AdminUserManagerViewModel adminUserManagerViewModel)
        {
            _userManager = userManager;
            _adminUserManagerViewModel = adminUserManagerViewModel;
            UserRole = new ObservableCollection<string> { "Admin", "User" };
            AddNewUserCommand = new AdminAddNewUserCommand(_userManager, this, _adminUserManagerViewModel);
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
        /// <summary>
        /// gets the user role collection that represets the combobox field
        /// </summary>
        public ObservableCollection<string> UserRole { get; }
        /// <summary>
        /// gets and sets the boolean that represents the user role
        /// </summary>
        /// <remarks>This boolean can be also setted to null if no selection occured</remarks>
        public bool? IsUserAdmin { get; set; }
        /// <summary>
        /// get and sets the selected role from the user role combobox with OnPropretychanged
        /// </summary>
        /// <remarks>
        /// <para>This proprety converts the string to the IsUserAdmin boolean</para>
        /// </remarks>
        public string? SelectedRole
        {
            get
            {
                switch (IsUserAdmin)
                {
                    case true:
                        return "Admin";
                    case false:
                        return "User";
                    default:
                        return null;
                }
            }
            set
            {
                switch (value)
                {
                    case "Admin":
                        IsUserAdmin = true;
                        break;
                    case "User":
                        IsUserAdmin = false;
                        break;
                    default:
                        IsUserAdmin = null;
                        break;
                }
                OnPropertyChanged(nameof(SelectedRole));
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
        public ICommand AddNewUserCommand { get; }
    }
}
