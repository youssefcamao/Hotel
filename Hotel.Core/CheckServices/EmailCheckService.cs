using Hotel.Configuration.Interfaces;
using System.Text.RegularExpressions;

namespace Hotel.Core
{
    public class EmailCheckService : ICheckService<string>
    {
        Regex _regexEmail = new Regex(@"[\w\d\._\-]+@[\w]+\.[\w]{2,}");
        public bool CheckIfValid(string email)
        {
            return _regexEmail.IsMatch(email);
        }
    }
}
