using Hotel.Configuration.Interfaces;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildAdminViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly IUser _connectedUser;
        private readonly ReservationManager _reservationManager;
        private readonly HotelRoomsManager _hotelRoomsManager = new HotelRoomsManager();

        public AdminViewModel(NavigationStore navigationStore, IUser connectedUser, UserManager userManager)
        {
            _navigationStore = navigationStore;
            _connectedUser = connectedUser;
            _reservationManager = new ReservationManager(userManager, _hotelRoomsManager);
            OpenReservationCommand = new OpenReservationCommand(this, connectedUser, userManager, _reservationManager, _hotelRoomsManager);
            OpenUserManagerCommand = new OpenUserManagerCommand(this);
            OpenHotelRoomsManager = new OpenHotelRoomsManagerCommand(this);
            LogoutCommand = new LogoutCommand(_navigationStore);
        }

        public ViewModelBase CurrentChildAdminViewModel
        {
            get
            {
                return _currentChildAdminViewModel;
            }
            set
            {
                _currentChildAdminViewModel = value;
                OnPropertyChanged(nameof(CurrentChildAdminViewModel));
            }
        }

        public ICommand OpenReservationCommand { get; }
        public ICommand OpenUserManagerCommand { get; }
        public ICommand OpenHotelRoomsManager { get; }
        public ICommand LogoutCommand { get; }
    }
}
