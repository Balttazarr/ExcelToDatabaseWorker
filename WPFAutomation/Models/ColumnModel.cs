using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAutomation.Models
{
    class ColumnModel
    {
        public string ColumnHeader { get; set; }
        public string ColumnValue { get; set; }
        public bool ValidationPassed { get; set; }
        public string FailedReason { get; set; }
    }
}
