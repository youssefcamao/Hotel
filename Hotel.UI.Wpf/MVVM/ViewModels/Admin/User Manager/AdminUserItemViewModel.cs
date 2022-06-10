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
        private readonly IUser _user;

        public AdminUserItemViewModel(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _user = user;
        }
        public string Name => _user.FirstName + " " + _user.LastName;
        public string Email => _user.Email;
        private bool _isUserAdmin;
        public string UserRole
        {
            get
            {
                if (_isUserAdmin)
                {
                    return "Admin";
                }
                else
                {
                    return "Normal User";
                }
;
            }
            set
            {
                switch (value)
                {
                    case "Admin":
                        _isUserAdmin = true;
                        break;
                    case "Normal User":
                        _isUserAdmin = false;
                        break;
                };
                OnPropertyChanged(nameof(UserRole));
            }
        }
    }
}
