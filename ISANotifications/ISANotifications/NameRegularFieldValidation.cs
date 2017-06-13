using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ISANotifications 
{
    public class NameRegularFieldValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            
            string NamePattern = "^([a-zA-Z0-9\\s]*)$";
            if (Regex.IsMatch(value.ToString(), NamePattern))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Please enter a valid name.");
            }

        }
    }
}
