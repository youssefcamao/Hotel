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
    public class UserManager
    {
        private readonly List<IUser> _usersList = new List<IUser>();

        public UserManager()
        {
            InitiateComponentsTest();
        }
        private void InitiateComponentsTest()
        {
            _usersList.Add(new User("Ramon", "Grothe", "ramon@admin.com", "ramon123", UserRole.Admin));
            _usersList.Add(new User("Youssef", "Sbai", "youssef@gmail.com", "youssef123", UserRole.NormalUser));
            _usersList.Add(new User("Paul", "Maibach", "paul@gmail.com", "paul123", UserRole.NormalUser));

        }
        public IUser? GetUserFromEmailPass(string email, string password)
        {
            var user = _usersList.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
            return user;
        }
        public void CreateNewUser(string firstName, string lastName, string email, string password)
        {
            _usersList.Add(new User(firstName, lastName, email, password, UserRole.NormalUser));
        }

        public IUser? GetUserFromId(Guid UserId)
        {
            return _usersList.FirstOrDefault(x => x.Id == UserId);
        }
    }
}
