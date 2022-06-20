using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminAddNewUserDialogViewModel : ViewModelBase
    {
        public AdminAddNewUserDialogViewModel(UserManager userManager, AdminUserManagerViewModel adminUserManagerViewModel)
        {
            _userManager = userManager;
            _adminUserManagerViewModel = adminUserManagerViewModel;
            UserRole = new ObservableCollection<string> { "Admin", "User" };
            AddNewUserCommand = new AddNewUserCommand(_userManager, this, _adminUserManagerViewModel);
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
        private string _password;
        private readonly UserManager _userManager;
        private readonly AdminUserManagerViewModel _adminUserManagerViewModel;

        public string Password
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
        public ObservableCollection<string> UserRole { get; }
        public bool? IsUserAdmin { get; set; }
        public string SelectedRole
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
                        IsUserAdmin= false;
                        break;
                    default:
                        IsUserAdmin = null;
                        break;
                }
                OnPropertyChanged(nameof(SelectedRole));
            }
        }
        private string _error;
        public string Error
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
        public string ExceptionErrorVisibility => Error != null ? "Visible" : "Collapsed";
        public ICommand AddNewUserCommand { get; }
    }
}
