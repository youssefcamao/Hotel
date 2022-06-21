using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;
using MaterialDesignThemes.Wpf;
using System;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    /// <summary>
    /// This command deletes a reservation from the backend and updates the resrevation grid view
    /// </summary>
    public class AdminDeleteReservationCommand : CommandBase
    {
        private ReservationManager _reservationManager;
        private readonly object _param;
        private readonly AdminReservationManagerViewModel _parentViewModel;

        public AdminDeleteReservationCommand(ReservationManager reservationManager, Object param, AdminReservationManagerViewModel parentViewModel)
        {
            _reservationManager = reservationManager;
            _param = param;
            _parentViewModel = parentViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_param is AdminReservationItemViewModel itemViewModel)
            {
                _reservationManager.DeleteReservationFromId(itemViewModel.Reservation.Id);
                _parentViewModel.GetReservationsFromCore();
                DialogHost.CloseDialogCommand.Execute(null, null);
            }

        }
    }
}
