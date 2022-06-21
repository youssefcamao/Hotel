using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This Command switches to the given viewModel by using <see cref="NavigationStore"/>
    /// </summary>
    public class SwitchViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelBase _newViewModel;

        public SwitchViewCommand(NavigationStore navigationStore, ViewModelBase newViewModel)
        {
            _navigationStore = navigationStore;
            _newViewModel = newViewModel;
        }
        public override void Execute(object? parameter)
        {
            if (_newViewModel == null)
            {
                throw new ArgumentNullException();
            }
            _navigationStore.CurrentViewModel = _newViewModel;
        }
    }
}
