using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// this command Navigate back to the login view
    /// </summary>
    internal class CancelSignUpCommand : CommandBase
    {
        private NavigationStore _navigationStore;

        public CancelSignUpCommand(NavigationStore navigationStore)
        {
            if (navigationStore == null)
            {
                throw new ArgumentNullException(nameof(navigationStore));
            }
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);
        }
    }
}
