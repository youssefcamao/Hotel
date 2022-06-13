using Hotel.Configuration.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Admin.User_Manager
{
    public class AdminUserItemViewModel : ViewModelBase
    {
        public IUser User { get; }

        public AdminUserItemViewModel(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            User = user;
        }
        public string Name => User.FirstName + " " + User.LastName;
        public string Email => User.Email;
        public string UserRole => User.IsUserAdmin ? "Admin" : "User";
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
