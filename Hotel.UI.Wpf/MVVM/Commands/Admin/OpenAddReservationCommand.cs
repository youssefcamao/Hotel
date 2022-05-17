using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using System;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class OpenAddReservationCommand : CommandBase
    {
        private AdminReservationManagerViewModel _adminReservationManagerViewModel;
        private const string _dialogHostId = "RootDialogHostId";

        public OpenAddReservationCommand(AdminReservationManagerViewModel adminReservationManagerViewModel)
        {
            _adminReservationManagerViewModel = adminReservationManagerViewModel;
        }

        public override void Execute(object? parameter)
        {
            var viewModel = new AdminInsertReservationViewModel();
        }
    }
}
