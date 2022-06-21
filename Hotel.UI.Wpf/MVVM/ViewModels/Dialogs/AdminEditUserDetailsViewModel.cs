using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminEditUserDetailsViewModel : ViewModelBase
    {
        public AdminEditUserDetailsViewModel(Object param, ObservableCollection<string> userRoles,
            UserManager userManager, AdminUserManagerViewModel adminUserManagerViewModel)
        {
            if (param is AdminUserItemViewModel adminUserItemViewModel)
            {
                AdminUserItemViewModel = adminUserItemViewModel;
            }
            else
            {
                throw new ArgumentNullException(nameof(param));
            }
           if (AdminUserItemViewModel.User == null)
            {
                throw new ArgumentNullException(nameof(AdminUserItemViewModel.User));
            }
            _firstName = AdminUserItemViewModel.User.FirstName;
            _lastName = AdminUserItemViewModel.User.LastName;
            _email = AdminUserItemViewModel.User.Email;
            UserRoleCollection = userRoles;
            IsUserAdmin = AdminUserItemViewModel.User.IsUserAdmin;
            SaveChangesCommand = new AdminSaveNewUsersEditedChangesCommand(userManager, this, adminUserManagerViewModel, adminUserItemViewModel);
    }
        private string _firstName;
        /// <summary>
        /// gets and sets the first name field with OnPropretychanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the last name field with OnPropretychanged
        /// </summary>
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
        /// <summary>
        /// gets and sets the Email field with OnPropretychanged
        /// </summary>
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
        public string? UserRole
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
                OnPropertyChanged(nameof(UserRole));
            }
        }
        public AdminUserItemViewModel AdminUserItemViewModel { get; }
        public ObservableCollection<string> UserRoleCollection { get; } = new ObservableCollection<string>();
        public ICommand SaveChangesCommand { get; }
    }
}
