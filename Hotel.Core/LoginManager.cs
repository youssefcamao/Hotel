using Hotel.Configuration;
using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public class LoginManager
    {
        private readonly List<IUser> _usersList = new List<IUser> { new User("ramon", "Grothe", "ramon@admin.com", "ramon123", UserRole.Admin) ,
        new User("youssef", "sbai", "youssef@gmail.com", "youssef123", UserRole.NormalUser)};

        public IUser? CheckAndGetUser(string email, string password)
        {
            var user = _usersList.FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }

    }
}
