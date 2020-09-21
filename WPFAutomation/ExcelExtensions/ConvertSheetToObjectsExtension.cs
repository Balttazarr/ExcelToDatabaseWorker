using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.EnumExtensions;
using WPFAutomation.Models;
using WPFAutomation.Models.Enums;

namespace WPFAutomation.ExcelExtensions
{
    static class ConvertSheetToObjectsExtension
    {
        private static List<RowModel> RowData { get; set; } = new List<RowModel>();
        private static List<ColumnModel> columnData;       

        public static List<RowModel> ToRowModel(this ExcelWorksheet worksheet)
        {
            var worksheetCellValues = (object[,])worksheet.Cells.Value;

            for (int i = 1; i < worksheetCellValues.GetUpperBound(0); i++)
            {
                columnData = new List<ColumnModel>();

                for (int j = 0; j < worksheetCellValues.GetUpperBound(1) + 1; j++)
                {
                    columnData.Add
                        (
                            new ColumnModel()
                            {
                                ColumnHeader = EnumHelper.GetDescription((IntegratedColumns)j),
                                ColumnValue = worksheetCellValues[i, j].ToString(),
                                ValidationPassed = true,
                                FailedReason = ""
                            }
                        );
                }

                RowData.Add
                    (
                        new RowModel()
                        {
                            Columns = columnData,
                            ValidationPassed = true,
                            FailedReason = ""
                        }
                    );
            }

            return RowData;
        }

        //public static T ReadFromExcel<T>(ExcelWorksheet excelWorksheet, bool hasHeader = true)
        //{
        //    //I'd implement in here RowModel and ColumnModel logic - code below is hard to read - MD
        //    using (var excelPack = new ExcelPackage())
        //    {
        //        //Get all details as DataTable -because Datatable make life easy :)
        //        DataTable excelasTable = new DataTable();

        //        //lambdas for the win! - MD
        //        foreach (var firstRowCell in excelWorksheet.Cells[1, 1, 1, excelWorksheet.Dimension.End.Column]
        //            .Where(firstRowCell => !string.IsNullOrEmpty(firstRowCell.Text)))
        //        {
        //            string firstColumn = string.Format("Column {0}", firstRowCell.Start.Column);
        //            excelasTable.Columns.Add(hasHeader ? firstRowCell.Text : firstColumn);
        //        }

        //        var startRow = hasHeader ? 2 : 1;

        //        //Get row details
        //        for (int rowNum = startRow; rowNum <= excelWorksheet.Dimension.End.Row; rowNum++)
        //        {
        //            var wsRow = excelWorksheet.Cells[rowNum, 1, rowNum, excelasTable.Columns.Count];
        //            DataRow row = excelasTable.Rows.Add();
        //            foreach (var cell in wsRow)
        //            {
        //                row[cell.Start.Column - 1] = cell.Text;
        //            }
        //        }
        //        //Get everything as generics and let end user decides on casting to required type
        //        var generatedType = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(excelasTable));
        //        return (T)Convert.ChangeType(generatedType, typeof(T));
        //    }
        //}
    }
}
