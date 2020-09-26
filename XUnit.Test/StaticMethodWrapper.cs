using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnit.Test
{
    public class StaticMethodWrapper : IWrapper
    {
        ExcelWorksheet _worksheet = null;
        public StaticMethodWrapper(ExcelWorksheet worksheet)
        {
            _worksheet = worksheet;
        }
        public void LoadData(ExcelWorksheet worksheet)
        {
            _worksheet = worksheet;
            //ConvertSheetToObjectExtension(worksheet.ToRowModel());
        }
    }

    public interface IWrapper
    {
        void LoadData(ExcelWorksheet worksheet);
    }
}
