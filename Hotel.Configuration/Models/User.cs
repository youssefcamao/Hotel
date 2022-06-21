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
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsUserAdmin { get; set; }

    }
}
