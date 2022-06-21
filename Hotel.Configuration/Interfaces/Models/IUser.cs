namespace Hotel.Configuration.Interfaces.Models
{
    public interface IUser
    {
        /// <summary>
        /// gets the Id of the user
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// gets and sets the first name of the user
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// gets snd sets the last name of the user
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// gets and sets the email of the registred user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// gets and sets boolean the represents if the created user is admin or not
        /// </summary>
        public bool IsUserAdmin { get; set; }

    }
}
