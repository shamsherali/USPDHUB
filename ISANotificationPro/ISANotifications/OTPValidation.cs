using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ISANotifications
{
    public class OTPValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string MatchPhoneNumberPattern = "^\\(?([0-9]{4})$";
            if (Regex.IsMatch(value.ToString(), MatchPhoneNumberPattern))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Please enter a valid OTP.");
            }

        }
    }
}
