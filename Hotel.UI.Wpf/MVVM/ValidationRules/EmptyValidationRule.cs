using System.Globalization;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.ValidationRules
{
    public class EmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(true, "the email or password are invalid");
        }
    }
}
