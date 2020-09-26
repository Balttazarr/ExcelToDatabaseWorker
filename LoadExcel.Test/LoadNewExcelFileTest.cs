using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.ExcelExtensions;
using WPFAutomation.Models;
using Xunit;

namespace LoadExcel.Test
{
    
    public class LoadNewExcelFileTest
    {
        private const string correctFilePath = @"./Resources/People.xlsx";

        [Fact]
        public void GetOnlyPeopleFromOneExcel()
        {

            //arrange
            var loadExcel = new ExcelLoad();
            //act
            var result = loadExcel.LoadExcelFile(correctFilePath);

            //assert
            Assert.Equal(10, result.Count());
        }
    }
}
