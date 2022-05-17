using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class OpenUserManagerCommand : CommandBase
    {
        private AdminViewModel _parentViewModel;

        public OpenUserManagerCommand(AdminViewModel parentViewModel)
        {
            _parentViewModel = parentViewModel;
        }

        public override void Execute(object? parameter)
        {
            _parentViewModel.CurrentChildAdminViewModel = new AdminUserManagerViewModel();
        }
    }
}
