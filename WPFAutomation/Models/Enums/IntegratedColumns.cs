using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAutomation.Models.Enums
{
    public enum IntegratedColumns
    {
        [Description("ID")]
        IdColumn = 0,
        [Description("FirstName")]
        FirstNameColumn = 1,
        [Description("LastName")]
        LastNameColumn = 2,
        [Description("DateOfBirth")]
        DateOfBirthColumn = 3
    }
}
