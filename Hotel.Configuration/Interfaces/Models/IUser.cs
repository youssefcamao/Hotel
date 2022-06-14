namespace Hotel.Configuration.Interfaces.Models
{
    public interface IUser
    {
        Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsUserAdmin { get; set; }

    }
}
