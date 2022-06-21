using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    /// <summary>
    /// This command adds a new user to the back end and updates the grid view of the users
    /// </summary>
    public class AdminAddNewUserCommand : CommandBase
    {
        private readonly UserManager _userManager;
        private readonly AdminAddNewUserDialogViewModel _parentViewModel;
        private readonly AdminUserManagerViewModel _adminUserManagerViewModel;

        public AdminAddNewUserCommand(UserManager userManager,
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
            try
            {
                _userManager.CreateNewUser(_parentViewModel.FirstName, _parentViewModel.LastName, _parentViewModel.Email, _parentViewModel.Password, _parentViewModel.IsUserAdmin.Value);
                _adminUserManagerViewModel.FilterOnSelection();
                DialogHost.CloseDialogCommand.Execute(null, null);
            }
            catch (Exception ex)
            {
                _parentViewModel.Error = ex.Message;
            }
        }
        public override bool CanExecute(object? parameter)
        {
            var areAllInputsFilledAndCorrect = !string.IsNullOrWhiteSpace(_parentViewModel.Password)
                && !string.IsNullOrWhiteSpace(_parentViewModel.Email) && !string.IsNullOrWhiteSpace(_parentViewModel.FirstName)
                && !string.IsNullOrWhiteSpace(_parentViewModel.LastName) && _parentViewModel.IsUserAdmin != null;
            var canExecute = base.CanExecute(parameter) && areAllInputsFilledAndCorrect;
            return canExecute;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
