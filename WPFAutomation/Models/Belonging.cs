using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAutomation.Models
{
    public class Belonging
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

        internal bool IsNew => (this.Id == default(int));
    }
}
