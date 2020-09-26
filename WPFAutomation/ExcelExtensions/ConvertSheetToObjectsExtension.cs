using OfficeOpenXml;
using System;
using System.Collections.Generic;
using WPFAutomation.EnumExtensions;
using WPFAutomation.Models;
using WPFAutomation.Models.Enums;

namespace WPFAutomation.ExcelExtensions
{
    public static class ConvertSheetToObjectsExtension
    {
        private static List<RowModel> RowData { get; set; } = new List<RowModel>();
        private static List<ColumnModel> ColumnData;

        public static List<RowModel> ToRowModel(this ExcelWorksheet worksheet)
        {
            RowData = new List<RowModel>();

            var staticData = new StaticData();
            var worksheetCellValues = (object[,])worksheet.Cells.Value;

            for (int i = 1; i < worksheetCellValues.GetUpperBound(0) + 1; i++)
            {     
                ColumnData = new List<ColumnModel>();
                for (int j = 0; j < worksheetCellValues.GetUpperBound(1) + 1; j++)
                {
                    ColumnData.Add
                        (
                            new ColumnModel()
                            {
                                ColumnHeader = EnumHelper.GetDescription((IntegratedColumns)j),
                                ColumnValue = worksheetCellValues[i, j],
                                ValidationPassed = true,
                                FailedReason = ""
                            }

                        );
                    if (ColumnData[j].ColumnHeader == EnumHelper.GetDescription((IntegratedColumns)3))
                    {
                        ColumnData[j].ColumnValue = DateTime.FromOADate((double)ColumnData[j].ColumnValue);
                    }
                }

                RowData.Add
                    (
                        new RowModel()
                        {
                            Columns = ColumnData,
                            ValidationPassed = true,
                            FailedReason = ""
                        }
                    );
            }

            staticData.RowModel = RowData;

            return RowData;
        }
    }
}
