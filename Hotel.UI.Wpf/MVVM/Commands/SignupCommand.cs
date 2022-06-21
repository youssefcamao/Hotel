using Hotel.Core.Managers;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This command will navigate to the signUp view
    /// </summary>
    public class SignupCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserManager _userManager;

        public SignupCommand(NavigationStore navigationStore, UserManager userManager)
        {
            _navigationStore = navigationStore;
            _userManager = userManager;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SignupViewModel(_navigationStore, _userManager);
        }
    }
}
