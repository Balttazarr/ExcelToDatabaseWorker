using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.Models;

namespace WPFAutomation.RowModelExtensions
{
    public static class RowModelExtension
    {
        public static object GetColumnValue(this RowModel rowModel, string columnName)
        {
            return rowModel.Columns.Where(c => c.ColumnHeader.Equals(columnName)).Select(c => c.ColumnValue).FirstOrDefault();
        }
    }
}
