using Hotel.Core.CheckServices;
using System.Globalization;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.ValidationRules
{
    /// <summary>
    /// This validationRule is validation on the password by using the logic of <see cref="PasswordCheckService"/>
    /// </summary>
    /// <remarks>This ValidationRule is used in the Xml</remarks>
    public class PasswordValidationRule : ValidationRule
    {
        private readonly PasswordCheckService _emailCheckSerice = new PasswordCheckService();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                var isValidPassword = _emailCheckSerice.CheckIfValid((string)value);
                if (!isValidPassword)
                {
                    return new ValidationResult(false, "Invalid Password!");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                return new ValidationResult(false, null);
            }
        }
    }
}
