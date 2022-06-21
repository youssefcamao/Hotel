using System;
using System.Globalization;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.ValidationRules
{
    /// <summary>
    /// This validation validate the datepicker to only allow futur dates
    /// </summary>
    /// <remarks>This ValidationRule is used in the Xml</remarks>
    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out time)) return new ValidationResult(false, "Invalid date");

            return time.Date <= DateTime.Now.Date
                ? new ValidationResult(false, "Future date required")
                : ValidationResult.ValidResult;
        }
    }
}
