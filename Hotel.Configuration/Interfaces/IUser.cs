using Hotel.Configuration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.Interfaces
{
    public interface IUser
    {
        public string FirstName { get;}
        public string LastName { get; }
        public string Email { get;}
        public string Password { get; }
        public UserRole UserRole { get; }

    }
}
