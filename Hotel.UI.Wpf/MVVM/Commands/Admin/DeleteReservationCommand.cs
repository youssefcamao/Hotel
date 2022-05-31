using Hotel.Configuration.Enums;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    public class DeleteReservationCommand : CommandBase
    {
        private ReservationManager _reservationManager;
        private readonly object _param;
        private readonly AdminReservationManagerViewModel _parentViewModel;

        public DeleteReservationCommand(ReservationManager reservationManager, Object param, AdminReservationManagerViewModel parentViewModel)
        {
            _reservationManager = reservationManager;
            _param = param;
            _parentViewModel = parentViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_param is AdminReservationItemViewModel itemViewModel)
            {
                _reservationManager.DeleteReservationFromId(itemViewModel.Reservation.ReservationId);
                _parentViewModel.GetReservationsFromCore();
                DialogHost.CloseDialogCommand.Execute(null, null);
            }

        }
    }
}
