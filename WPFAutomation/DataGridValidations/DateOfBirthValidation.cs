using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFAutomation.DataGridValidations
{
    public class DateOfBirthValidation : ValidationRule
    {
        public DateOfBirthValidation()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime exit;
                if (!DateTime.TryParseExact(value.ToString(),"dd-MM-yyyy", new CultureInfo("pl-PL"), DateTimeStyles.None, out exit))
                {
                    return new ValidationResult(false, "This isn't a DateTime format. Please use:\n dd-mm-yyyy");
                }
            }
            
            return new ValidationResult(true, null);
        }
    }
}
