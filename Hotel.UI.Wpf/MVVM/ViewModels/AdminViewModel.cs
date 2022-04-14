using Hotel.Configuration.Interfaces;
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

        public AdminViewModel(NavigationStore navigationStore, IUser connectedUser)
        {
            _navigationStore = navigationStore;
            _connectedUser = connectedUser;
            OpenReservationCommand = new OpenReservationCommand(this, connectedUser);
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
