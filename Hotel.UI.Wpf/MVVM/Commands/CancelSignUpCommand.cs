using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.Commands
{
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
