namespace Hotel.Configuration.Interfaces.Models
{
    public interface IUser
    {
        Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public bool IsUserAdmin { get; }

    }
}
