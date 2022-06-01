using Hotel.Configuration.Interfaces;
using Hotel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.Wpf.Ui_Helpers
{
    public static class UiStringHelpers
    {
        public static string GetUserNameFromUser(IUser user)
        {
            var firstName = NamingHelper.FixNameFormat(user.FirstName);
            var lastName = NamingHelper.FixNameFormat(user.LastName);
            return $"{user.UserRole}/{firstName} {lastName}";
        }
    }
}
