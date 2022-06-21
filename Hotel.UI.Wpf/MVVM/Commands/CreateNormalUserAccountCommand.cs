using Hotel.Configuration.Exceptions;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Stores;
using Hotel.UI.Wpf.MVVM.ViewModels;
using System;
using System.ComponentModel;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This command Creates a new user as a normal user and swithces back to the login view
    /// </summary>
    /// <remarks>It Sends a snackbar if the registraction was successful</remarks>
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
            try
            {
                _loginManager.CreateNewUser(_parentViewModel.FirstName, _parentViewModel.LastName,
                    _parentViewModel.Email, _parentViewModel.Password, false);
                var loginView = new LoginViewModel(_navigationStore);
                _navigationStore.CurrentViewModel = loginView;
                loginView.SendSuccessfulRegistrationMessage();
            }
            catch (Exception e)
            {
                _parentViewModel.Error = e.Message;
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) && !string.IsNullOrWhiteSpace(_parentViewModel.FirstName)
                && !string.IsNullOrWhiteSpace(_parentViewModel.LastName) && !string.IsNullOrWhiteSpace(_parentViewModel.Email)
                && !string.IsNullOrWhiteSpace(_parentViewModel.Password);
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExcutedChanged();
        }
    }
}
