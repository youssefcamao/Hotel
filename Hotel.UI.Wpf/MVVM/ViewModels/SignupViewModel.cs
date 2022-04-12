using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Stores;
using MaterialDesignThemes.Wpf;
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
        private readonly LoginManager _loginManager = new LoginManager();

        public SignupViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            CancelSignUpCommand = new CancelSignUpCommand(_navigationStore);
            CreateNewNormalUserCommand = new CreateNormalUserAccountCommand(_loginManager, this, _navigationStore);
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
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
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand CancelSignUpCommand { get; }
        public ICommand CreateNewNormalUserCommand { get; }
    }
}
