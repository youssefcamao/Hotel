using Hotel.Configuration.Interfaces.DataAccess;
using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This command is async and takes the email and passowrd from the parent view model and sends it to the back end for auth
    /// </summary>
    /// <remarks>If login is successful it swithces to new view depending on the users role </remarks>
    public class LoginCommand : AsyncCommandBase
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

        public override async Task ExecuteAsync(object? parameter)
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
                _parentViewModel.IsLoginInProgress = false;
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
            _parentViewModel.IsLoginInProgress = false;
        }
    }
}
