using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models
{
    public class User : IUser
    {
        public User(Guid id, string firstName, string lastName, string email, bool isAdmin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsUserAdmin = isAdmin;
        }
        public User()
        {

        }
        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public bool IsUserAdmin { get; }

    }
}
