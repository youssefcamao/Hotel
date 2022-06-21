using Hotel.UI.Wpf.MVVM.ViewModels;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin;

namespace Hotel.UI.Wpf.MVVM.Commands.Admin
{
    /// <summary>
    /// This command switches the view to <see cref="AdminHotelRoomsManagerViewModel"/>
    /// </summary>
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
