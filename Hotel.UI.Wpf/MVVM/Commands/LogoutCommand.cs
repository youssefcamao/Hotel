using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This command will navigate back to the login view
    /// </summary>
    public class LogoutCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public LogoutCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);
        }
    }
}
