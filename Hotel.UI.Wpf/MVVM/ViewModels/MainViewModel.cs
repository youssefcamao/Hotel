using Hotel.UI.Wpf.MVVM.Stores;
using System;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore? navigationStore)
        {
            if (navigationStore == null)
            {
                throw new ArgumentNullException(nameof(navigationStore));
            }
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private string _menuButtonStatus = "Collapsed";
        public string MenuButtonStatus
        {
            get
            {
                return _menuButtonStatus;
            }
            set
            {
                _menuButtonStatus = value;
                OnPropertyChanged(nameof(MenuButtonStatus));
            }
        }
        public ViewModelBase? CurrentViewModel { get => _navigationStore.CurrentViewModel; }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            if (CurrentViewModel is AdminViewModel)
            {
                MenuButtonStatus = "Visible";
                OnPropertyChanged(nameof(MenuButtonStatus));
            }
            else
            {
                MenuButtonStatus = "Collapsed";
            }
        }
    }
}
