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
        /// <summary>
        /// gets <see cref="IUser"/> that represnts <see cref="AdminUserItemViewModel"/> 
        /// </summary>
        public IUser User { get; }

        public AdminUserItemViewModel(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            User = user;
        }
        /// <summary>
        /// gets the full name from the <see cref="IUser"/>
        /// </summary>
        public string Name => User.FirstName + " " + User.LastName;
        /// <summary>
        /// gets the email from the <see cref="IUser"/>
        /// </summary>
        public string Email => User.Email;
        /// <summary>
        /// gets the the userRole as string from the IsUser boolean from <see cref="IUser"/>
        /// </summary>
        /// <remarks> string must be either User or Admin</remarks>
        public string UserRole => User.IsUserAdmin ? "Admin" : "User";
        private bool _isSelected;
        /// <summary>
        /// This Proprety represents if <see cref="AdminUserItemViewModel"/> is seleced in the grid
        /// </summary>
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
