using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperUser : IUser
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsUserAdmin { get; set; }
    }
}
