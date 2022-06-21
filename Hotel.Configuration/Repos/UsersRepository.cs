using Dapper;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models.DapperModels;
using System.Data;
using System.Reflection;

namespace Hotel.Configuration.Repos
{
    public class UsersRepository : IUserRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public UsersRepository(ISqlDataAccess dataAccess)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }
            _dataAccess = dataAccess;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="password"></param> 
        /// <remarks>if the password is null or empty <see cref="ArgumentNullException"/> is thrown.</remarks>
        public void CreateNewModel(IUser model, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            _dataAccess.SaveData("InsertUser", new
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = password,
                IsUserAdmin = model.IsUserAdmin
            });
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="model"></param>
        public void DeleteModel(IUser model) =>
            _dataAccess.SaveData("DeleteUser", new { UserId = model.Id});
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        /// <remarks>if <see cref="IUser"/> is not implemented from the dapper user <see cref="ArgumentNullException"/> is thrown.</remarks>
        public IList<IUser> GetAll()
        {
            var dapperUsers = _dataAccess.LoadData<DapperUser, dynamic>("GetAllUsers", new { });
            var users = dapperUsers.Select(x => x is IUser user ? user : throw new ArgumentException("user doesn't implement the interface IUser")).ToList();
            return users;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns><inheritdoc/></returns>
        /// <remarks>if email or password empty or null <see cref="ArgumentNullException"/> is thrown.</remarks>
        public async Task<IUser?> GetUserWithAuthAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            else if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var user = await _dataAccess.LoadDataAsync<DapperUser, dynamic>("LoginAuth", new { Email = email, Password = password });
            return user.FirstOrDefault();
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para> this can take null for the password paramater if its not wished to be changed</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="password"></param>
        public void UpdateModel(IUser model, string? password) 
        {
            _dataAccess.SaveData("UpdateUsers", new 
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsUserAdmin = model.IsUserAdmin,
                Password = password
            });
        }
    }
}
