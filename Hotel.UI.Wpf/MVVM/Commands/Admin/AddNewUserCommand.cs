using Hotel.Configuration.Exceptions;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class AddNewUserCommand : CommandBase
    {
        private readonly UserManager _userManager;
        private readonly AdminAddNewUserDialogViewModel _parentViewModel;
        private readonly AdminUserManagerViewModel _adminUserManagerViewModel;

        public AddNewUserCommand(UserManager userManager, 
            AdminAddNewUserDialogViewModel parentViewModel, AdminUserManagerViewModel adminUserManagerViewModel)
        {
            _userManager = userManager;
            _parentViewModel = parentViewModel;
            _adminUserManagerViewModel = adminUserManagerViewModel;
            _parentViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object? parameter)
        {
            if (_parentViewModel.IsUserAdmin == null)
            {
                throw new ArgumentNullException(nameof(_parentViewModel.IsUserAdmin));
            }
            _userManager.CreateNewUser(_parentViewModel.FirstName, _parentViewModel.LastName, _parentViewModel.Email, _parentViewModel.Password, _parentViewModel.IsUserAdmin.Value);
            _adminUserManagerViewModel.FillViewUsersFromList(_userManager.UsersList);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
        public override bool CanExecute(object? parameter)
        {
            var areAllInputsFilledAndCorrect = !string.IsNullOrEmpty(_parentViewModel.Password)
                && !string.IsNullOrEmpty(_parentViewModel.Email) && !string.IsNullOrEmpty(_parentViewModel.FirstName)
                && !string.IsNullOrEmpty(_parentViewModel.LastName) && _parentViewModel.IsUserAdmin != null;
            var canExecute = base.CanExecute(parameter) && areAllInputsFilledAndCorrect;
            return canExecute;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
