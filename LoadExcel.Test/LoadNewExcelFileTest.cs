using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using WPFAutomation.ExcelExtensions;
using WPFAutomation.Models;
using WPFAutomation.RowModelExtensions;
using Xunit;

namespace LoadExcel.Test
{
    
    public class LoadNewExcelFileTest
    {
        private const string correctFilePath = @".\Resources\People.xlsx";

        public LoadNewExcelFileTest() {}

        [Fact]
        public void ExcelLoad_LoadRecordsFromSpreadsheet_AllCellsCorrect()
        {
            // Arrange        
            var loadExcel = new ExcelLoad();

            // Act
            var result = loadExcel.LoadExcelFile(correctFilePath);

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public void asd()
        {
            // Arrange
            var path = new FileInfo(correctFilePath);

            var package = new ExcelPackage(path)
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            // Act


            // Assert
    }
}
