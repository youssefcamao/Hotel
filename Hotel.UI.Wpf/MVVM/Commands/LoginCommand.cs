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
            var user = _userManager.GetUserFromEmailPass(email, password);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
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
        public override bool CanExecute(object? parameter)
        {
            var email = _parentViewModel.Email;
            var password = _parentViewModel.UserPassword;
            var user = _userManager.GetUserFromEmailPass(email, password);
            return user != null;
        }
    }
}
