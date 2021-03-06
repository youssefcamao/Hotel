using Hotel.Core.CheckServices;
using System.Globalization;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.ValidationRules
{
    /// <summary>
    /// This Validation validates on the field by using the logic of <see cref="EmailCheckService"/>
    /// </summary>
    /// <remarks>This ValidationRule is used in the Xml</remarks>
    public class EmailValidationRule : ValidationRule
    {
        private readonly EmailCheckService _emailCheckSerice = new EmailCheckService();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                var isEmail = _emailCheckSerice.CheckIfValid((string)value);
                if (!isEmail)
                {
                    return new ValidationResult(false, "Invalid Email!");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                return new ValidationResult(false, "");
            }
        }
    }
}
