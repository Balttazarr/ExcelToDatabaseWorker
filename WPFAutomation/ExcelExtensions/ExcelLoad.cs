using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFAutomation.Models;

namespace WPFAutomation.ExcelExtensions
{
    public class ExcelLoad
    {
        //why was it public? - MD
        //and why is it declared in here if you do not use it anywhere?
        //don't always make 'new' for every variable at the start of declaration - sometimes it does not have to be fully declared at the certain time
        //and is gonna be used somewhere far in the code

        private List<string> excelData = new List<string>();

        public ExcelLoad()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public IEnumerable<PersonModel> LoadExcelFile(string selectedFileNamePath)
        {

            // path to your excel file
            //vars for the win - MD
            var path = new FileInfo(selectedFileNamePath);

            using (var package = new ExcelPackage(path))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.First();
                var col = worksheet.ToRowModel();

                //var newCollection = ConvertSheetToObjectsExtension.ReadFromExcel<List<PersonModel>>(worksheet, true);

                return new List<PersonModel>();
            }
        }
    }
}
