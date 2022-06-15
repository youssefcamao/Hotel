using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class AdminDeleteSelectedUsersCommand : CommandBase
    {
        private readonly UserManager _userManager;
        private readonly AdminUserManagerViewModel _parentViewModel;
        private readonly string _dialogHostId;

        private IEnumerable<AdminUserItemViewModel> _selectedUserViewModles => _parentViewModel.Users.Where(x => x.IsSelected);

        public AdminDeleteSelectedUsersCommand(UserManager userManager, AdminUserManagerViewModel parentViewModel, string dialogHostId)
        {
            _userManager = userManager;
            _parentViewModel = parentViewModel;
            _dialogHostId = dialogHostId;
            _parentViewModel.Users.CollectionChanged += Users_CollectionChanged;
            SubscribeToAllViewUsers();
        }

        private void Users_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SubscribeToAllViewUsers();
        }

        private void SubscribeToAllViewUsers()
        {
            foreach (var user in _parentViewModel.Users)
            {
                user.PropertyChanged += User_PropertyChanged;
            }
        }

        public override void Execute(object? parameter)
        {
            DialogHost.Show(new ConfirmationDialogViewModel("Are You Sure You Want To Delete Selected Users ?", new DelegateCommand(OnConfirmDelete)), _dialogHostId);
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) && _selectedUserViewModles != null && _selectedUserViewModles.Count() > 0;
        }
        private void OnConfirmDelete(Object _)
        {
            foreach (var userViewModel in _selectedUserViewModles)
            {
                _userManager.DeleteUser(userViewModel.User);
            }
            _parentViewModel.FilterOnSelection();
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
        private void User_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
