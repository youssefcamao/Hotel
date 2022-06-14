using Hotel.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.ValidationRules
{
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
                return new ValidationResult(false,null);
            }
        }
    }
}
