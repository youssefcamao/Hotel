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
        public Guid Id { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsUserAdmin { get; set; }

    }
}
