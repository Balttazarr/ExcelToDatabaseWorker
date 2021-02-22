using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFAutomation.DataGridValidations
{
    public class WeightValidation : ValidationRule
    {


        public WeightValidation()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value != null)
            {
                int number;
                bool resultInt = int.TryParse(value.ToString(), out number);
                if (resultInt == false)
                {
                    return new ValidationResult(false, "Weight must be a number between 1-200kg.");
                }
                else if (number < 1 || number > 200)
                {
                    return new ValidationResult(false, "Weight cannot be less than 1kg or bigger than 200kg");
                }

                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Unknown error");
        }
    }
}
