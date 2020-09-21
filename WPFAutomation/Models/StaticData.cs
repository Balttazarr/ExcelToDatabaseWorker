using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.Models.Interfaces;

namespace WPFAutomation.Models
{
    public class StaticData : IStaticData
    {
        public List<RowModel> RowModel { get; set; }
    }
}
