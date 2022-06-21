using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;

namespace Hotel.UI.Wpf.Ui_Helpers
{
    public static class UserHelperService
    {
        /// <summary>
        /// This static method returns a string with the first and last name combinded and formatted
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetUserNameFromUser(IUser user)
        {
            var firstName = NamingHelper.FixNameFormat(user.FirstName);
            var lastName = NamingHelper.FixNameFormat(user.LastName);
            var userRole = user.IsUserAdmin ? "Admin" : "User";
            return $"{userRole}/{firstName} {lastName}";
        }
    }
}
