using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class OpenHotelRoomsManagerCommand : CommandBase
    {
        private AdminViewModel _parentViewModel;

        public OpenHotelRoomsManagerCommand(AdminViewModel parentViewModel)
        {
            _parentViewModel = parentViewModel;
        }

        public override void Execute(object? parameter)
        {
            _parentViewModel.CurrentChildAdminViewModel = new AdminHotelRoomsManagerViewModel();
        }
    }
}
