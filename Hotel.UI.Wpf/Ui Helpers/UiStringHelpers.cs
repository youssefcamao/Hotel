using Hotel.Configuration.Interfaces.Models;
using Hotel.Core;

namespace Hotel.UI.Wpf.Ui_Helpers
{
    public static class UiStringHelpers
    {
        public static string GetUserNameFromUser(IUser user)
        {
            var firstName = NamingHelper.FixNameFormat(user.FirstName);
            var lastName = NamingHelper.FixNameFormat(user.LastName);
            var userRole = user.IsUserAdmin ? "Admin" : "User";
            return $"{userRole}/{firstName} {lastName}";
        }
    }
}
