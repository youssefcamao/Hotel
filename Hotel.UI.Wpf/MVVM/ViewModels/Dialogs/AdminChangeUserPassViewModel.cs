using Hotel.Core;
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
        public bool IsNewPasswordValid => NewPassword != null;
        public bool IsConfirmedPasswordValid => NewPassword == ConfirmedPassword && NewPassword != null;
        public string? IsNewPasswordValidMarkVisibility => IsNewPasswordValid ? "Visible" : "Collapsed";
        public string? ConfirmedPasswordValidMarkVisibility => IsConfirmedPasswordValid ? "Visible" : "Collapsed";
        public ICommand AdminChangePasswordCommand { get; }
    }
}
