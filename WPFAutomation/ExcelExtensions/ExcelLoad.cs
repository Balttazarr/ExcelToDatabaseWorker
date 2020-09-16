using OfficeOpenXml;
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

        public List<string> excelData = new List<string>();
        public ExcelLoad()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public IEnumerable<PersonModel> LoadExcelFile(string selectedFileNamePath)
        {

            // path to your excel file
            FileInfo fileInfo = new FileInfo(selectedFileNamePath);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();


            IEnumerable<PersonModel> newCollection = ConvertSheetToObjectsExtension.ReadFromExcel<List<PersonModel>>(worksheet,true);

            return newCollection;

        }



    }
}
