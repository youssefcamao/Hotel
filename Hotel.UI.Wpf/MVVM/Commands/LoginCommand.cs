using Hotel.Configuration.Interfaces.Repos;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _parentViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly UserManager _userManager;
        private readonly ISqlDataAccess _sqlDataAccess;

        public LoginCommand(LoginViewModel parentViewModel, NavigationStore navigationStore,
            UserManager userManager, ISqlDataAccess sqlDataAccess)
        {
            _parentViewModel = parentViewModel;
            _navigationStore = navigationStore;
            _userManager = userManager;
            _sqlDataAccess = sqlDataAccess;
        }
        public override async void Execute(object? parameter)
        {
            var email = _parentViewModel.Email;
            var password = _parentViewModel.UserPassword;
            if (email == null)
            {
                return;
            }
            if (password == null)
            {
                return;
            }
            _parentViewModel.IsLoginInProgress = true;
            var user = await _userManager.GetUserFromEmailPassAsync(email, password);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                _parentViewModel.IsLoginInProgress = false;
                if (user.IsUserAdmin)
                {
                    _navigationStore.CurrentViewModel = new AdminViewModel(_navigationStore, user, _userManager, _sqlDataAccess);
                }
                else
                {
                    _navigationStore.CurrentViewModel = new UserViewModel(_navigationStore, user);
                }
            }

        }
    }
}
