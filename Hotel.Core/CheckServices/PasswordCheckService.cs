using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hotel.Core.CheckServices
{
    public class PasswordCheckService : ICheckService<string>
    {
        private readonly Regex _regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");

        /// <summary>
        /// <inheritdoc/>
        /// <para>This method checks if the new password either for registration or user change is using the pattern of atleast a big letter, 
        /// number and small letter. also if its atleast 8 characters long.</para>
        /// </summary>
        /// <param name="password"></param>
        /// <returns>True if it matches the Regex, false if not.</returns>
        public bool CheckIfValid(string password)
        {
            return _regex.IsMatch(password);
        }
    }
}
