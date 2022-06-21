using Hotel.Configuration.Interfaces.Models;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.Services;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel(NavigationStore navigationStore, IUser connectedUser)
        {
            CurrentUserString = UserHelperService.GetUserNameFromUser(connectedUser);
            LogoutCommand = new LogoutCommand(navigationStore);
        }
        /// <summary>
        /// gets and sets the string that represents the user on closing bar
        /// </summary>
        public string CurrentUserString { get; }
        public ICommand LogoutCommand { get; } 
    }
}
