using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class OpenUserManagerCommand : CommandBase
    {
        private AdminViewModel _parentViewModel;
        private readonly UserManager _userManager;

        public OpenUserManagerCommand(AdminViewModel parentViewModel, UserManager userManager)
        {
            _parentViewModel = parentViewModel;
            _userManager = userManager;
        }

        public override void Execute(object? parameter)
        {
            _parentViewModel.CurrentChildAdminViewModel = new AdminUserManagerViewModel(_userManager);
        }
    }
}
