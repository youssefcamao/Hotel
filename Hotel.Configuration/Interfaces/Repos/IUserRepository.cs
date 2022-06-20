using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IUserRepository : IBaseRepository<IUser>
    {
        void CreateNewModel(IUser user, string password);
        void UpdateModel(IUser user, string? password);
        Task<IUser?> GetUserWithAuthAsync(string Email, string password);
    }
}
