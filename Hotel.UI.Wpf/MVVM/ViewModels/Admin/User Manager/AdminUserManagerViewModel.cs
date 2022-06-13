using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminUserManagerViewModel : ViewModelBase
    {
        private readonly UserManager _userManager;

        public AdminUserManagerViewModel(UserManager userManager)
        {
            _userManager = userManager;
            Users = new ObservableCollection<AdminUserItemViewModel>();
            FillViewUsersFromList(_userManager.UsersList);
        }
        public ObservableCollection<AdminUserItemViewModel> Users { get; }
        internal void FillViewUsersFromList(IEnumerable<IUser> usersList)
        {
            if (Users.Count != 0)
            {
                Users.Clear();
            }
            var users = usersList;
            foreach (var user in users)
            {
                Users.Add(new AdminUserItemViewModel(user));
            }
        }
        public ObservableCollection<string> AllFilters => new ObservableCollection<string> { "All", "Admin", "User" };
        private string _selectedFilter = "All";
        public string SelectedFilter
        {
            get
            {
                return _selectedFilter;
            }
            set
            {
                if (value != _selectedFilter)
                {
                    _selectedFilter = value;
                    FilterOnSelection();
                }
                OnPropertyChanged(nameof(SelectedFilter));
            }
        }

        private void FilterOnSelection()
        {
            var userList = _userManager.UsersList;
            switch (_selectedFilter)
            {
                case "Admin":
                    FillViewUsersFromList(userList.Where(x => x.IsUserAdmin));
                    break;
                case "User":
                    FillViewUsersFromList(userList.Where(x => !x.IsUserAdmin));
                    break;
                case "All":
                    FillViewUsersFromList(userList);
                    break;
                default:
                    break;
            }
        }
    }
}
