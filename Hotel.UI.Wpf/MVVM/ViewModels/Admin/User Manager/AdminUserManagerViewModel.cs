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
        private readonly IUser _connectedUser;
        private IList<IUser> _usersViewedList;

        public AdminUserManagerViewModel(UserManager userManager, IUser connectedUser)
        {
            _userManager = userManager;
            _connectedUser = connectedUser;
            Users = new ObservableCollection<AdminUserItemViewModel>();
            _usersViewedList = _userManager.UsersList;
            FillViewUsersFromList(_usersViewedList);
            Users.CollectionChanged += Users_CollectionChanged;
        }

        private void Users_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(NoDataAvailableMessageVisibility));
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
                if (user.Id != _connectedUser.Id)
                {
                Users.Add(new AdminUserItemViewModel(user));
                }
            }
        }
        public bool? IsAllUsersSelected
        {
            get
            {
                var selected = Users.Select(item => item.IsSelected).Distinct().ToList();
                return selected.Count == 1 ? selected.Single() : (bool?)null;
            }
            set
            {
                if (value.HasValue)
                {
                    SelectAll(value.Value);
                }
            }
        }
        private void SelectAll(bool select)
        {
            foreach (var user in Users)
            {
                user.IsSelected = select;
            }
        }
        public ObservableCollection<string> AllFilters => new ObservableCollection<string> { "All", "Admin", "User" };
        public string NoDataAvailableMessageVisibility => Users.Count == 0 ? "Visible" : "Collapsed";
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
