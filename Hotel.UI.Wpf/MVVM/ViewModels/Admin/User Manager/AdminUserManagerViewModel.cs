using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager;
using Hotel.UI.Wpf.MVVM.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;
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
        private readonly ObservableCollection<string> _userRoles = new ObservableCollection<string> { "Admin", "User"};
        private readonly string _dialogHostId = "UserManagerDialog";

        public AdminUserManagerViewModel(UserManager userManager, IUser connectedUser)
        {
            _userManager = userManager;
            _connectedUser = connectedUser;
            Users = new ObservableCollection<AdminUserItemViewModel>();
            _usersViewedList = _userManager.UsersList;
            FillViewUsersFromList(_usersViewedList);
            Users.CollectionChanged += Users_CollectionChanged;
            OpenAddNewUserDialogCommand = new DelegateCommand(OnShowAddUserDialog);
            OpenChangeUserPasswordDialogCommand = new DelegateCommand(OnShowChangePasswordDialog);
            OpenEditUserDetailsDialogCommand = new DelegateCommand(OnShowEditUseDetailsDialog);
            OpenDeleteUserConfirmationDialog = new DelegateCommand(OnOpenDeleteReservationConfiramtion);
            DeleteSelectedUsers = new AdminDeleteSelectedUsersCommand(_userManager, this, _dialogHostId);
        }

        private void Users_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(NoDataAvailableMessageVisibility));
        }

        public ObservableCollection<AdminUserItemViewModel> Users { get; }
        
        /// <summary>
        /// This method fills the User grid view with the given <see cref="IEnumerable<<see cref="IUser"/>>"/>
        /// </summary>
        /// <remarks>it clears all the old users before adding the new ones</remarks>
        /// <param name="usersList"></param>
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
        /// <summary>
        /// gets a bool that represnts if all the userse selected from the grid view
        /// </summary>
        /// <remarks>this boolean can be also null if the selected users are equal to 1</remarks>
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
        /// <summary>
        /// This collection represents the elements in the combo box of the users's filter
        /// </summary>
        public ObservableCollection<string> AllFilters => new ObservableCollection<string> { "All", "Admin", "User" };
        /// <summary>
        /// This proprety represents the visibility of the no data availble on the user grid
        /// </summary>
        /// <remarks> it swithces visibility to visbile if the users count are more than 0</remarks>
        /// <remarks>the string must be either Visible or Collapsed</remarks>
        public string NoDataAvailableMessageVisibility => Users.Count == 0 ? "Visible" : "Collapsed";
        private string _selectedFilter = "All";
        /// <summary>
        /// This proprety represents the selected combobox element from the users filter
        /// </summary>
        /// <remarks> it set to All as default</remarks>
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
        private string? _seachContent;
        /// <summary>
        /// gets and sets the search content on the user grid view
        /// </summary>
        /// <remarks>This Property filters evreytime it gets set</remarks>
        public string? SearchContent
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
        /// <summary>
        /// This method Filter on the seleced Users
        /// </summary>
        /// <remarks>it only filters on the viewed users on the grid</remarks>
        internal void FilterOnSelection()
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
            if (_seachContent == null)
            {
                return;
            }
            var filterSearchList = new List<IUser>(_usersViewedList.Where(x => x.FirstName.Contains(_seachContent, StringComparison.OrdinalIgnoreCase)
            || x.LastName.Contains(_seachContent, StringComparison.OrdinalIgnoreCase) 
            || x.Email.Contains(_seachContent, StringComparison.OrdinalIgnoreCase)));
            FillViewUsersFromList(filterSearchList);
        }
        private void SelectAll(bool select)
        {
            foreach (var user in Users)
            {
                user.IsSelected = select;
            }
        }
        private async void OnShowAddUserDialog(object _)
        {
            await DialogHost.Show(new AdminAddNewUserDialogViewModel(_userManager, this), _dialogHostId);
        }
        private async void OnShowChangePasswordDialog(object param)
        {
            await DialogHost.Show(new AdminChangeUserPassViewModel(param, _userManager, this), _dialogHostId);
        }
        private async void OnShowEditUseDetailsDialog(object param)
        {
            await DialogHost.Show(new AdminEditUserDetailsViewModel(param, _userRoles, _userManager, this), _dialogHostId);
        }
        private async void OnOpenDeleteReservationConfiramtion(object paramater)
        {
            await DialogHost.Show(new ConfirmationDialogViewModel("Are You Sure You Want To Delete this User ?", new AdminDeleteUserCommand(_userManager, paramater, this)), _dialogHostId);
        }
        public ICommand OpenAddNewUserDialogCommand { get; }
        public ICommand OpenChangeUserPasswordDialogCommand { get; }
        public ICommand OpenEditUserDetailsDialogCommand { get; }
        public ICommand OpenDeleteUserConfirmationDialog { get; }
        public ICommand DeleteSelectedUsers { get; }
    }
}
