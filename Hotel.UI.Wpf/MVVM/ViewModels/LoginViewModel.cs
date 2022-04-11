using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly NavigationStore _navigationStore;

        public LoginViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            LoginCommand = new LoginCommand(this, _navigationStore);
            SignupCommand = new SignupCommand(_navigationStore);
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string _userPassword;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }
        public ICommand LoginCommand { get; }
        public ICommand SignupCommand { get; }

        public bool HasErrors { get; set; } = false;

        public IEnumerable GetErrors(string? propertyName)
        {

            return new List<string> { "Email or Password is wrong" };

        }
        public void OnErrorsChanged(string name1,string name2)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(name1));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(name2));
        }
    }
}
