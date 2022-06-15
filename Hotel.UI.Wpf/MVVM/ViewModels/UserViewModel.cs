using Hotel.Configuration.Interfaces.Models;
using Hotel.UI.Wpf.MVVM.Commands.Admin;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.Ui_Helpers;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel(NavigationStore navigationStore, IUser connectedUser)
        {
            CurrentUserString = UiStringHelpers.GetUserNameFromUser(connectedUser);
            LogoutCommand = new LogoutCommand(navigationStore);
        }
        public string CurrentUserString { get; }
        public ICommand LogoutCommand { get; } 
    }
}
