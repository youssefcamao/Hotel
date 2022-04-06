using Hotel.Configuration.Enums;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration
{
    public class User : IUser
    {
        public User(string firstName, string lastName, string email, string password, UserRole userRole)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserRole = userRole;
        }
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }

        public UserRole UserRole { get; }
    }
}
