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
    public class HeightValidation : ValidationRule
    {


        public HeightValidation()
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
                    return new ValidationResult(false, "Height must be a number between 20-300cm.");
                }
                else if (number < 20 || number > 300)
                {
                    return new ValidationResult(false, "Height cannot be less than 20cm or bigger than 300cm");
                }

                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Unknown error");
        }
    }
}
