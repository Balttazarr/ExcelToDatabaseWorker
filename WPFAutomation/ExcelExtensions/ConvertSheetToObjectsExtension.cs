﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using WPFAutomation.EnumExtensions;
using WPFAutomation.Models;
using WPFAutomation.Models.Enums;

namespace WPFAutomation.ExcelExtensions
{
    static class ConvertSheetToObjectsExtension
    {
        private static List<RowModel> RowData { get; set; } = new List<RowModel>();
        private static List<ColumnModel> ColumnData;

        public static List<RowModel> ToRowModel(this ExcelWorksheet worksheet)
        {
            var staticData = new StaticData();
            var worksheetCellValues = (object[,])worksheet.Cells.Value;

            for (int i = 1; i < worksheetCellValues.GetUpperBound(0); i++)
            {
                ColumnData = new List<ColumnModel>();

                for (int j = 0; j < worksheetCellValues.GetUpperBound(1) + 1; j++)
                {
                    //here you should create some logic to casting types
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
