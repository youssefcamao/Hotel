using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using System.Collections.ObjectModel;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminUserManagerViewModel : ViewModelBase
    {
        private readonly UserManager _userManager;

        public AdminUserManagerViewModel(UserManager userManager)
        {
            _userManager = userManager;
            Users = new ObservableCollection<AdminUserItemViewModel>();
            GetReservationsFromCore();
        }
        public ObservableCollection<AdminUserItemViewModel> Users { get; }
        internal void GetReservationsFromCore()
        {
            if (Users.Count != 0)
            {
                Users.Clear();
            }
            var users = _userManager.UsersList;
            foreach (var user in users)
            {
                Users.Add(new AdminUserItemViewModel(user));
            }
        }

    }
}
