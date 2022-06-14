using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public class PasswordCheckService : ICheckService<string>
    {
        private readonly Regex _regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
        public bool CheckIfValid(string password)
        {
            return _regex.IsMatch(password);
        }
    }
}
