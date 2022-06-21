using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class AdminChangeUserPassViewModel : ViewModelBase
    {
        public AdminChangeUserPassViewModel(object param, UserManager userManager, AdminUserManagerViewModel adminUserManagerViewModel)
        {
            if (param is AdminUserItemViewModel adminUserItemViewModel)
            {
                AdminChangePasswordCommand = new AdminChangePasswordCommand(userManager, this, adminUserManagerViewModel, adminUserItemViewModel);
            }
            else
            {
                throw new ArgumentNullException(nameof(param));
            }
        }
        private string? _newPassword;
        /// <summary>
        /// gets and sets the New Password field with OnPropretychanged
        /// </summary>
        public string? NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
                OnPropertyChanged(nameof(IsNewPasswordValidMarkVisibility));
                OnPropertyChanged(nameof(ConfirmedPasswordValidMarkVisibility));
            }
        }
        private string? _confirmedPassword;
        /// <summary>
        /// gets and sets the Confirm Password field with OnPropretychanged
        /// </summary>
        public string? ConfirmedPassword
        {
            get
            {
                return _confirmedPassword;
            }
            set
            {
                _confirmedPassword = value;
                OnPropertyChanged(nameof(ConfirmedPassword));
                OnPropertyChanged(nameof(ConfirmedPasswordValidMarkVisibility));
            }
        }
        /// <summary>
        /// gets if then new password is valid and not equal null
        /// </summary>
        public bool IsNewPasswordValid => NewPassword != null;
        /// <summary>
        /// gets if the new password matches the confirmed password
        /// </summary>
        public bool IsConfirmedPasswordValid => NewPassword == ConfirmedPassword && NewPassword != null;
        /// <summary>
        /// gets the visibility string depending on the IsNewPasswordValid boolean
        /// </summary>
        public string? IsNewPasswordValidMarkVisibility => IsNewPasswordValid ? "Visible" : "Collapsed";
        /// <summary>
        /// gets the visibility string depending on the IsConfirmedPasswordValid boolean
        /// </summary>
        public string? ConfirmedPasswordValidMarkVisibility => IsConfirmedPasswordValid ? "Visible" : "Collapsed";
        public ICommand AdminChangePasswordCommand { get; }
    }
}
