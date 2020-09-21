using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAutomation.Models
{
    public class ColumnModel
    {
        public string ColumnHeader { get; set; }
        public object ColumnValue { get; set; }
        public bool ValidationPassed { get; set; }
        public string FailedReason { get; set; }
    }
}
