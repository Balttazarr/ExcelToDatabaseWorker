using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPFAutomation.EnumExtensions;
using WPFAutomation.Models;
using WPFAutomation.Models.Enums;
using WPFAutomation.RowModelExtensions;

namespace WPFAutomation.ExcelExtensions
{
    public class ExcelLoad
    {
        //why was it public? - MD
        //and why is it declared in here if you do not use it anywhere?
        //don't always make 'new' for every variable at the start of declaration - sometimes it does not have to be fully declared at the certain time
        //and is gonna be used somewhere far in the code

        public List<ExcelWorksheet> Worksheets { get; set; }

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

                return ConvertRowDataToPersonModel(worksheet.ToRowModel());
            }
        }

        private IEnumerable<PersonModel> ConvertRowDataToPersonModel(List<RowModel> rowData)
        {
            var personModelList = new List<PersonModel>();
            DateTime converted = new DateTime();
            foreach (var row in rowData)
            {
                //double to DateTime conversion
                foreach (var nextRow in row.Columns)
                {
                    if (nextRow.ColumnHeader == "DateOfBirth")
                    {
                        converted = DateTime.FromOADate((double)nextRow.ColumnValue);
                    }
                }
                personModelList.Add
                    (
                        new PersonModel()
                        {
                            ID = Convert.ToInt32(row.GetColumnValue(EnumHelper.GetDescription((IntegratedColumns)0))),
                            FirstName = (string)row.GetColumnValue(EnumHelper.GetDescription((IntegratedColumns)1)),
                            LastName = (string)row.GetColumnValue(EnumHelper.GetDescription((IntegratedColumns)2)),
                            DateOfBirth = converted
                        }
                    );
            }

            return personModelList;
        }
    }
}
