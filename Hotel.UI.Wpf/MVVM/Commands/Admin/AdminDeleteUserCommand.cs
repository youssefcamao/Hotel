using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class AdminDeleteUserCommand : CommandBase
    {
        private readonly UserManager _userManager;
        private readonly object _param;
        private readonly AdminUserManagerViewModel _parentViewModel;

        public AdminDeleteUserCommand(UserManager userManager, Object param, AdminUserManagerViewModel parentViewModel)
        {
            _userManager = userManager;
            _param = param;
            _parentViewModel = parentViewModel;
        }
        public override void Execute(object? parameter)
        {
            if (_param is AdminUserItemViewModel itemViewModel)
            {
                _userManager.DeleteUser(itemViewModel.User);
                _parentViewModel.FillViewUsersFromList(_userManager.UsersList);
                DialogHost.CloseDialogCommand.Execute(null, null);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(_param));
            }
        }
    }
}
