using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IUserRepository : IBaseRepository<IUser>
    {
        /// <summary>
        /// this method creates a new user in the database
        /// <para> the user must be of type <see cref="IUser"/></para>
        /// <para>a password of type <see cref="string"/> is also required</para>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        void CreateNewModel(IUser user, string password);
        /// <summary>
        /// this method updates a user in the database
        /// <para> the param user must be of type <see cref="IUser"/></para>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        void UpdateModel(IUser user, string? password);
        /// <summary>
        /// this method gets the user async from the database 
        /// if <paramref name="Email"/> and <paramref name="password"/> matches the database values
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns> returns the user async or <see cref="null"/> if user not found</returns>
        Task<IUser?> GetUserWithAuthAsync(string Email, string password);
    }
}
