using System.Globalization;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.ValidationRules
{
    /// <summary>
    /// This Validation used as an empty validation to throw a validation error
    /// </summary>
    public class EmptyValidationRule : ValidationRule
    {
        private readonly string _validationError;

        public EmptyValidationRule(string validationError)
        {
            _validationError = validationError;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(true, _validationError);
        }
    }
}
