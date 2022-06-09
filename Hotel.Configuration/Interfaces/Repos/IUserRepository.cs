using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IUserRepository : IBaseRepository<IUser>
    {
        void CreateNewModel(IUser model, string password);
        IUser? GetUserWithAuth(string Email, string password);
    }
}
