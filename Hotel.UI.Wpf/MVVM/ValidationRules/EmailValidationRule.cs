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
    public class EmailValidationRule : ValidationRule
    {
        private readonly EmailCheckService _emailCheckSerice = new EmailCheckService();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                var isEmail = _emailCheckSerice.CheckIfEmailValid((string)value);
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
                return new ValidationResult(false,"Email Required!");
            }
        }
    }
}
