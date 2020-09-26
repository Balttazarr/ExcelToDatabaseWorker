using OfficeOpenXml;
using System;
using System.IO;
using Xunit;
using System.Linq;

namespace XUnit.Test
{
    public class MyProgramTests : IDisposable
    {
        private ExcelPackage package;
        private ExcelWorksheet worksheet;
        private readonly FileInfo Path = new FileInfo(@"\People.xlsx");

        public MyProgramTests()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (package = new ExcelPackage(Path))
            {
                var workbook = package.Workbook;
                worksheet = workbook.Worksheets.First();
            }

        }

        public void Dispose()
        {
            package.Dispose();
        }

        [Fact]
        public void ToRowModel_Test()
        {
            //ConvertRowDataToPersonModel(worksheet.ToRowModel());
        }

        [Fact]
        public void Test2()
        {

        }
    }
}
