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
        private readonly UserManager _loginManager = new UserManager();

        public LoginCommand(LoginViewModel parentViewModel, NavigationStore navigationStore)
        {
            _parentViewModel = parentViewModel;
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            var email = _parentViewModel.Email;
            var password = _parentViewModel.UserPassword;
            var user = _loginManager.GetUserFromEmailPass(email, password);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                switch (user.UserRole)
                {
                    case Configuration.Enums.UserRole.Admin:
                        _navigationStore.CurrentViewModel = new AdminViewModel(_navigationStore,user);
                        break;
                    case Configuration.Enums.UserRole.NormalUser:
                        _navigationStore.CurrentViewModel = new UserViewModel();
                        break;
                    default:
                        break;
                }
            }

        }
        public override bool CanExecute(object? parameter)
        {
            var email = _parentViewModel.Email;
            var password = _parentViewModel.UserPassword;
            var user = _loginManager.GetUserFromEmailPass(email, password);
            return user != null;
        }
    }
}
