using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Repos;
using Hotel.Core;
using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.Stores;
using MaterialDesignThemes.Wpf;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ISqlDataAccess _sqlDataAccess = new SqlDataAccess(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString); 
        private readonly IUserRepository _userRepository;
        private readonly UserManager _userManager;

        public LoginViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _userRepository = new UsersRepository(_sqlDataAccess);
            _userManager = new UserManager(_userRepository);
            LoginCommand = new LoginCommand(this, _navigationStore, _userManager, _sqlDataAccess);
            SignupCommand = new SignupCommand(_navigationStore, _userManager);
        }
        private string? _email;
        public string? Email
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
        private string? _userPassword;

        public string? UserPassword
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
        private bool _isLoginInProgress;
        public bool IsLoginInProgress
        {
            get
            {
                return _isLoginInProgress;
            }
            set
            {
                _isLoginInProgress = value;
                OnPropertyChanged(nameof(IsLoginInProgress));
            }
        }
        public ICommand LoginCommand { get; }
        public ICommand SignupCommand { get; }
        public ISnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();

        public void SendSuccessfulRegistrationMessage()
        {
            BoundMessageQueue.Enqueue("Thank you for registring with us", "Close", () =>
            {
                Debug.WriteLine("Close clicked");
            });
        }


    }
}
