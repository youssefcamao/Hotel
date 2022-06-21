using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models;
using Hotel.Configuration.Exceptions;

namespace Hotel.Core
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// gets all <see cref="IUser"/> from the repository
        /// </summary>
        public IList<IUser> UsersList => _userRepository.GetAll();
        /// <summary>
        /// this method gets the user async from email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns> <see cref="IUser"/> if found and null if not</returns>
        public async Task<IUser?> GetUserFromEmailPassAsync(string email, string password)
        {
            if (email == null || password == null)
            {
                return null;
            }
            var user = await _userRepository.GetUserWithAuthAsync(email, password);
            return user;
        }
        /// <summary>
        /// This method creates a new user
        /// </summary>
        /// <remarks> if email is already used by another user <see cref="EmailAlreadyUsedException"/> is thrown</remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="isUserAdmin"></param>
        /// <exception cref="EmailAlreadyUsedException"></exception>
        public void CreateNewUser(string firstName, string lastName, string email, string password, bool isUserAdmin)
        {
            var userId = Guid.NewGuid();
            var doesEmailAlreadyExist = UsersList.Any(x => x.Email == email);
            if (doesEmailAlreadyExist)
            {
                throw new EmailAlreadyUsedException(nameof(email));
            }
            var user = new User(userId, NamingHelper.FixNameFormat(firstName), NamingHelper.FixNameFormat(lastName), email, isUserAdmin);
            _userRepository.CreateNewModel(user, password);
        }
        /// <summary>
        /// This method update a user with it id
        /// <para> password can be given as null if it's not wished to be changed</para>
        /// </summary>
        /// <remarks>if user is not found <see cref="ArgumentNullException"/> is thrown</remarks>
        /// <param name="userId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="isUserAdmin"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateUser(Guid userId, string firstName, string lastName, string email, bool isUserAdmin, string? password = null)
        {
            var user = UsersList.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.FirstName = NamingHelper.FixNameFormat(firstName);
            user.LastName = NamingHelper.FixNameFormat(lastName);
            user.Email = email;
            user.IsUserAdmin = isUserAdmin;
            _userRepository.UpdateModel(user,password);
        }
        /// <summary>
        /// This methdo deletes a user
        /// </summary>
        /// <remarks>if user is not found <see cref="ArgumentNullException"/> is thrown</remarks>
        /// <param name="user"></param>
        public void DeleteUser(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _userRepository.DeleteModel(user);
        }
        /// <summary>
        /// This method return a user from it's Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns><see cref="IUser"/> if found and null if not</returns>
        public IUser? GetUserFromId(Guid UserId) 
        {
            return UsersList.FirstOrDefault(x => x.Id == UserId);
        }
                
    }
}
