using Hotel.Configuration.Interfaces;
using Hotel.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminReservationManagerViewModel : ViewModelBase
    {
        private readonly IUser _connectedUser;
        private readonly UserManager _userManager = new UserManager();
        private readonly HotelRoomsManager _hotelRoomsManager = new HotelRoomsManager();
        private const string _dialogHostId = "RootDialogHostId";
        private readonly ReservationManager _reservationManager;
        public AdminReservationManagerViewModel(IUser? connectedUser)
        {
            if (connectedUser == null)
            {
                throw new ArgumentNullException(nameof(connectedUser));
            }
            _connectedUser = connectedUser;
            _reservationManager = new ReservationManager(_userManager, _hotelRoomsManager);
            InitiateComponents();
            OpenInsertReservationDialog = new DelegateCommand(OnShowInsertReservationDialog);
            
        }
        public ObservableCollection<AdminReservationItemViewModel> Reservations { get; } = new ObservableCollection<AdminReservationItemViewModel>();
        private void InitiateComponents()
        {
            var reservations = _reservationManager.HotelRerservations;
            foreach (var reservation in reservations)
            {
                var user = _userManager.GetUserFromId(reservation.UserId) ?? throw new ArgumentNullException();
                var name = $"{user.FirstName} {user.LastName}";
                var bookedRoom = _hotelRoomsManager.GetRoomFromNumber(reservation.RoomNumber) ?? throw new ArgumentNullException();
                var category = _hotelRoomsManager.GetRoomCategoryFromId(bookedRoom.CategoryId) ?? throw new ArgumentNullException();
                Reservations.Add(new AdminReservationItemViewModel(reservation, category, name));
            }
        }
        private async void OnShowInsertReservationDialog(object _)
        {
            await DialogHost.Show(new AdminInsertReservationViewModel(_hotelRoomsManager, _reservationManager), _dialogHostId);
        }
        public ICommand OpenInsertReservationDialog { get; }
    }
}
