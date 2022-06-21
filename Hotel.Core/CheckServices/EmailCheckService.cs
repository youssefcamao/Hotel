using Hotel.Configuration.Interfaces;
using System.Text.RegularExpressions;

namespace Hotel.Core.CheckServices
{
    public class EmailCheckService : ICheckService<string>
    {
        Regex _regexEmail = new Regex(@"[\w\d\._\-]+@[\w]+\.[\w]{2,}");

        /// <summary>
        /// <inheritdoc/>
        /// <para>This method checks if the input email is in the correct format of abc@xyz.efd with a Regex.</para>
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if it matches the Regex or false if not</returns>
        public bool CheckIfValid(string email)
        {
            return _regexEmail.IsMatch(email);
        }
    }
}
