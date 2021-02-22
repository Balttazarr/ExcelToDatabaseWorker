using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFAutomation.DataGridValidations
{
    public class NameValidation : ValidationRule
    {
        public NameValidation()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if ((value is string))
                {
                    string givenString = value.ToString();

                    if (string.IsNullOrWhiteSpace(givenString))
                    {
                        return new ValidationResult(false, "Cell cannot be empty");
                    }
                    else if (!givenString.All(Char.IsLetter))
                    {
                        return new ValidationResult(false, "This cell can contain only letters");
                    }
                    else if (givenString.Length < 2 && givenString.Length > 30)
                    {
                        return new ValidationResult(false, "Cell should be the length of 2 to 30 characters");
                    }
                    //Regex.IsMatch(input, @"^[a-zA-Z]+$");

                    // All good.
                    return new ValidationResult(true, null);
                }       
            }

            return new ValidationResult(false, "Unknown error");

        }
    }
}
