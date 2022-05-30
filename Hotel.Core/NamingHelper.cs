using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public static class NamingHelper
    {
        public static string MakeFirstLetterUpperCase(string firstName)
        {
            if (firstName.Count() > 1)
            {
                firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);
            }

            return firstName;
        }
    }
}
