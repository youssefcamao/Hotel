using System.Text.RegularExpressions;

namespace Hotel.Core
{
    public class EmailCheckService
    {
        Regex _regexEmail = new Regex(@"[\w\d\._\-]+@[\w]+\.[\w]{2,}");
        public bool CheckIfEmailValid(string email)
        {
            return _regexEmail.IsMatch(email);
        }
    }
}
