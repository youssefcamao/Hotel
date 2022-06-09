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

        public LoginCommand(LoginViewModel parentViewModel, NavigationStore navigationStore, UserManager userManager)
        {
            _parentViewModel = parentViewModel;
            _navigationStore = navigationStore;
            _userManager = userManager;
        }
        public override void Execute(object? parameter)
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
                    _navigationStore.CurrentViewModel = new AdminViewModel(_navigationStore, user, _userManager);
                }
                else
                {
                    _navigationStore.CurrentViewModel = new UserViewModel();
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
