using Hotel.UI.Wpf.MVVM.Stores;
using System;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            if (navigationStore == null)
            {
                throw new ArgumentNullException(nameof(navigationStore));
            }
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        public ViewModelBase? CurrentViewModel { get => _navigationStore.CurrentViewModel; }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
