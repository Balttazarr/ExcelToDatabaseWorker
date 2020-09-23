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


        [Fact]
        public void GetOnlyPeopleFromOneExcel()
        {
            var PersonListTest = new List<PersonModel>();
            //arrange
            var loadExcel = new ExcelLoad();
            //act
            var loaded = loadExcel.LoadExcelFile(@"C:\Users\CzarnyPotwor\Desktop\People.xlsx");
            var loaded2 = loadExcel.LoadExcelFile(@"C:\Users\CzarnyPotwor\Desktop\People.xlsx");
            foreach (var person in loaded)
            {
                PersonListTest.Add(person);
            }
            var loadedCount = loaded.Count();
            //assert
            Assert.Equal(10, loadedCount);
        }
    }
}
