using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class OpenUserManagerCommand : CommandBase
    {
        private AdminViewModel _parentViewModel;
        private readonly UserManager _userManager;
        private readonly IUser _connectedUser;

        public OpenUserManagerCommand(AdminViewModel parentViewModel, UserManager userManager, IUser connectedUser)
        {
            _parentViewModel = parentViewModel;
            _userManager = userManager;
            _connectedUser = connectedUser;
        }

        public override void Execute(object? parameter)
        {
            _parentViewModel.CurrentChildAdminViewModel = new AdminUserManagerViewModel(_userManager, _connectedUser);
        }
    }
}
