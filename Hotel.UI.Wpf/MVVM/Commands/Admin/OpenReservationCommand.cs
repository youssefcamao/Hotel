using Hotel.Configuration.Interfaces;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    public class OpenReservationCommand : CommandBase
    {
        private AdminViewModel _parentViewModel;
        private IUser _connectedUser;

        public OpenReservationCommand(AdminViewModel parentViewModel, IUser connectedUser)
        {
            _parentViewModel = parentViewModel;
            _connectedUser = connectedUser;
        }

        public override void Execute(object? parameter)
        {
            _parentViewModel.CurrentChildAdminViewModel = new AdminReservationManagerViewModel(_connectedUser);
        }
    }
}
