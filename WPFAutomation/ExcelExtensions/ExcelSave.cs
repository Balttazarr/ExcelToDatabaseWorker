using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.Models;
using WPFAutomation.ViewModel;


namespace WPFAutomation
{
    public class ExcelSave
    {
        public ExcelSave()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }


        public void SaveToExcel(List<PersonModel> listToSave)
        {
            //think about splitting code below into more methods - MD
            ExcelPackage pck;
            List<string> lstHeader;
            ExcelWorksheet ws;
            ExcelConfig(out pck, out lstHeader, out ws);


            //Header Section
            for (int i = 0; i < lstHeader.Count; i++)
            {
                ws.Cells[1, i + 1].Value = lstHeader[i];
                ws.Cells[1, i + 1].Style.Font.Bold = true;
            }
            //Column value section
            for (int i = 0; i < listToSave.Count(); i++)
            {
                ws.Cells[i + 2, 1].Value = listToSave[i].ID;
                ws.Cells[i + 2, 2].Value = listToSave[i].FirstName;
                ws.Cells[i + 2, 3].Value = listToSave[i].LastName;
                ws.Cells[i + 2, 4].Value = listToSave[i].DateOfBirth;
                ws.Cells[i + 2, 4].Style.Numberformat.Format = "dd-mm-yyyy";
                //ws.Cells[i + 2, 5].Value = listToSave[i].Height;
                //ws.Cells[i + 2, 6].Value = listToSave[i].Weight;
                //ws.Cells[i + 2, 7].Value = listToSave[i].Sex;
                //ws.Cells[i + 2, 8].Value = listToSave[i].Race;
                //ws.Cells[i + 2, 9].Value = listToSave[i].Nationality;

            }

            byte[] fileText = pck.GetAsByteArray();

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Excel Worksheets (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllBytes(dialog.FileName, fileText);
            }
        }

        private static void ExcelConfig(out ExcelPackage pck, out List<string> lstHeader, out ExcelWorksheet ws)
        {
            pck = new ExcelPackage();

            //think about saving those strings into consts or into some config
            pck.Workbook.Properties.Author = "Ladek Ryzwa";

            lstHeader = new List<string>() { "ID", "First Name", "Last Name", "Date of Birth" };
            ws = pck.Workbook.Worksheets.Add("Worksheet1");
            ws.Column(2).Width = 10;
            ws.Column(3).Width = 10;
            ws.Column(4).Width = 15;
        }
    }
}
