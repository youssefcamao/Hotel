using Hotel.UI.Wpf.MVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;

        public SignupViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
