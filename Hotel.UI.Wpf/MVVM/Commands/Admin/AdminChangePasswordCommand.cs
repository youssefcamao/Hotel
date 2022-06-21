using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    /// <summary>
    /// This command changes the password of a user in the back end from <see cref="AdminUserItemViewModel"/>
    /// </summary>
    public class AdminChangePasswordCommand : CommandBase
    {
        private readonly UserManager _userManager;
        private readonly AdminChangeUserPassViewModel _parentViewModel;
        private readonly AdminUserManagerViewModel _adminUserManagerViewModel;
        private readonly AdminUserItemViewModel _selectedUserItem;

        public AdminChangePasswordCommand(UserManager userManager,
            AdminChangeUserPassViewModel parentViewModel,
            AdminUserManagerViewModel adminUserManagerViewModel, AdminUserItemViewModel selectedUserItem)
        {
            _userManager = userManager;
            _parentViewModel = parentViewModel;
            _adminUserManagerViewModel = adminUserManagerViewModel;
            _selectedUserItem = selectedUserItem;
            _parentViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object? parameter)
        {
            if (_parentViewModel.NewPassword == null)
            {
                throw new ArgumentNullException(nameof(_parentViewModel.NewPassword));
            }
            if (_selectedUserItem.User == null)
            {
                throw new ArgumentNullException(nameof(_selectedUserItem.User));
            }
            _userManager.UpdateUser(_selectedUserItem.User.Id, _selectedUserItem.User.FirstName, _selectedUserItem.User.LastName,
                _selectedUserItem.User.Email, _selectedUserItem.User.IsUserAdmin, _parentViewModel.NewPassword);
            _adminUserManagerViewModel.FillViewUsersFromList(_userManager.UsersList);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) && _parentViewModel.IsConfirmedPasswordValid && _parentViewModel.IsNewPasswordValid;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
