using Hotel.UI.Wpf.MVVM.ViewModels;
using System;

namespace Hotel.UI.Wpf.MVVM.Stores
{
    /// <summary>
    /// This store is responsible for the main navigation in the app
    /// </summary>
    public class NavigationStore
    {
        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel; set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        /// <summary>
        /// gets and sets the current view model
        /// </summary>
        public event Action? CurrentViewModelChanged;
    }
}
