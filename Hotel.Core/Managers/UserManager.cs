using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models;

namespace Hotel.Core
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IList<IUser> UsersList => _userRepository.GetAll();
        public IUser? GetUserFromEmailPass(string email, string password)
        {
            if (email == null || password == null)
            {
                return null;
            }
            var user = _userRepository.GetUserWithAuth(email, password);
            return user;
        }
        public void CreateNewUser(string firstName, string lastName, string email, string password, bool isUserAdmin)
        {
            var userId = Guid.NewGuid();
            var user = new User(userId, NamingHelper.FixNameFormat(firstName), NamingHelper.FixNameFormat(lastName), email, isUserAdmin);
            _userRepository.CreateNewModel(user, password);
        }
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
        public void DeleteUser(IUser user) =>
            _userRepository.DeleteModel(user);
        public IUser? GetUserFromId(Guid UserId) 
        {
            return UsersList.FirstOrDefault(x => x.Id == UserId);
        }
                
    }
}
