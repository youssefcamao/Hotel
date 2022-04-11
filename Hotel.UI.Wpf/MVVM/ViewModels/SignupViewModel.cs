using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;

        public SignupViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            CancelSignUpCommand = new CancelSignUpCommand(_navigationStore);
        }

        public ICommand CancelSignUpCommand { get; }
    }
}
