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
            CreateNewUser("Ramon", "Grothe", "ramon@admin.com", "ramon123", UserRole.Admin);
            CreateNewUser("Youssef", "Sbai", "youssef@admin.com", "youssef123", UserRole.Admin);
            CreateNewUser("Jannik", "Krusch", "jannik@gmail.com", "jannik123", UserRole.NormalUser);
            CreateNewUser("Paul", "Maibach", "paul@gmail.com", "paul123", UserRole.NormalUser);

        }
        public IUser? GetUserFromEmailPass(string email, string password)
        {
            if (email == null || password == null)
            {
                return null;
            }
            var user = _usersList.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
            return user;
        }
        public void CreateNewUser(string firstName, string lastName, string email, string password, UserRole userRole)
        {
            var userId = Guid.NewGuid();
            _usersList.Add(new User(firstName, lastName, email, password, userRole, userId));
        }

        public IUser? GetUserFromId(Guid UserId)
        {
            return _usersList.FirstOrDefault(x => x.Id == UserId);
        }
    }
}
