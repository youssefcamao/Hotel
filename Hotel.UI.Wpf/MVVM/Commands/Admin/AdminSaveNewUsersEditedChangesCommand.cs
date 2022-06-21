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
    /// This command Checks the input fields in the details and save any changes and refreshes the UI after saving
    /// </summary>
    public class AdminSaveNewUsersEditedChangesCommand : CommandBase
    {
        private readonly UserManager _userManager;
        private readonly AdminEditUserDetailsViewModel _parentViewModel;
        private readonly AdminUserManagerViewModel _adminUserManagerViewModel;
        private readonly AdminUserItemViewModel _selectedUserItem;

        public AdminSaveNewUsersEditedChangesCommand(UserManager userManager,
            AdminEditUserDetailsViewModel parentViewModel, 
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
            if (_parentViewModel.IsUserAdmin == null)
            {
                throw new ArgumentNullException(nameof(_parentViewModel.IsUserAdmin));
            }
            if (_selectedUserItem.User == null)
            {
                throw new ArgumentNullException(nameof(_selectedUserItem.User));
            }
            _userManager.UpdateUser(_selectedUserItem.User.Id, _parentViewModel.FirstName, _parentViewModel.LastName, _parentViewModel.Email, _parentViewModel.IsUserAdmin.Value, null);
            _adminUserManagerViewModel.FillViewUsersFromList(_userManager.UsersList);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
        public override bool CanExecute(object? parameter)
        {
            var areAllInputsFilled = !string.IsNullOrEmpty(_parentViewModel.Email) 
                && !string.IsNullOrEmpty(_parentViewModel.FirstName)
                && !string.IsNullOrEmpty(_parentViewModel.LastName) 
                && _parentViewModel.IsUserAdmin != null;
            //boolean represents if there is any new edits on the details
            var IfDetailsChanged = _parentViewModel.FirstName != _selectedUserItem.User.FirstName
                || _parentViewModel.LastName != _selectedUserItem.User.LastName
                || _parentViewModel.Email != _selectedUserItem.User.Email
                || _parentViewModel.IsUserAdmin != _selectedUserItem.User.IsUserAdmin;
            var canExecute = base.CanExecute(parameter) && areAllInputsFilled && IfDetailsChanged;
            return canExecute;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
