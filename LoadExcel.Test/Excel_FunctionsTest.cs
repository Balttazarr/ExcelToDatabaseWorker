using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using WPFAutomation;
using WPFAutomation.ExcelExtensions;
using WPFAutomation.Models;
using WPFAutomation.RowModelExtensions;
using Xunit;

namespace LoadExcel.Test
{
    
    public class Excel_FunctionsTest
    {
        private const string correctFilePath = @"./Resources/People.xlsx";
        private const string testName = "Peter";

        public Excel_FunctionsTest() {}

        [Fact]
        public void ExcelLoad_LoadRecordsFromSpreadsheet_AllCellsCorrect()
        {

            //arrange
            var loadExcel = new ExcelLoad();
            //act
            var result = loadExcel.LoadExcelFile(correctFilePath);
            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public void asd()
        {
            // Arrange
            var path = new FileInfo(correctFilePath);

            var package = new ExcelPackage(path);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            // Act
            var result = worksheet.ToRowModel();
            // Assert
            Assert.Equal(10, result.Count());

        }

        [Fact]
        public void ExcelLoad()
        {

            //arrange
            var loadExcel = new ExcelLoad();
            //act
            var result = loadExcel.LoadExcelFile(correctFilePath);
            var foundName = result.Where(w => w.FirstName == testName).FirstOrDefault();
            // Assert
            Assert.Equal(testName, foundName.FirstName);
        }

        [Fact]
        public void GetConnection_CheckDbConnection_True()
        {
            //arrange
            var testConnectionString = "ConnectionString";
            //act

            var conn = newOpenDb.GetConnection(testConnectionString);
            //assert
            Assert.NotNull(conn);
        }

    }
}
