using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin
{
    public class AdminUserManagerViewModel : ViewModelBase
    {
        private readonly UserManager _userManager;
        private IList<IUser> _usersViewedList;

        public AdminUserManagerViewModel(UserManager userManager)
        {
            _userManager = userManager;
            Users = new ObservableCollection<AdminUserItemViewModel>();
            _usersViewedList = _userManager.UsersList;
            FillViewUsersFromList(_usersViewedList);
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
        private string _seachContent;
        public string SearchContent
        {
            get
            {
                return _seachContent;
            }
            set
            {
                _seachContent = value;
                OnPropertyChanged(nameof(SearchContent));
                FilterOnSearch();
            }
        }

        private void FilterOnSelection()
        {
            _usersViewedList = _userManager.UsersList;
            switch (_selectedFilter)
            {
                case "Admin":
                    _usersViewedList = _usersViewedList.Where(x => x.IsUserAdmin).ToList();
                    FillViewUsersFromList(_usersViewedList);
                    break;
                case "User":
                    _usersViewedList = _usersViewedList.Where(x => !x.IsUserAdmin).ToList();
                    FillViewUsersFromList(_usersViewedList);
                    break;
                case "All":
                    FillViewUsersFromList(_usersViewedList);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(SearchContent))
            {
                FilterOnSearch();
            }
        }
        private void FilterOnSearch()
        {
            var filterSearchList = new List<IUser>(_usersViewedList.Where(x => x.FirstName.Contains(_seachContent, StringComparison.OrdinalIgnoreCase)
            || x.LastName.Contains(_seachContent, StringComparison.OrdinalIgnoreCase) 
            || x.Email.Contains(_seachContent, StringComparison.OrdinalIgnoreCase)));
            FillViewUsersFromList(filterSearchList);
        }
    }
}
