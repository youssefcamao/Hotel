using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System.ComponentModel;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    public class CreateNormalUserAccountCommand : CommandBase
    {
        private readonly UserManager _loginManager;
        private readonly SignupViewModel _parentViewModel;
        private readonly NavigationStore _navigationStore;

        public CreateNormalUserAccountCommand(UserManager loginManager, SignupViewModel parentViewModel,
            NavigationStore navigationStore)
        {
            _loginManager = loginManager;
            _parentViewModel = parentViewModel;
            _navigationStore = navigationStore;
            _parentViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                _loginManager.CreateNewUser(_parentViewModel.FirstName, _parentViewModel.LastName,
                    _parentViewModel.Email, _parentViewModel.Password, false);
                var loginView = new LoginViewModel(_navigationStore);
                _navigationStore.CurrentViewModel = loginView;
                loginView.SendSuccessfulRegistrationMessage();

            }
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) && _parentViewModel.FirstName != null 
                && _parentViewModel.LastName != null && _parentViewModel.Email != null
                && _parentViewModel.Password != null;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
