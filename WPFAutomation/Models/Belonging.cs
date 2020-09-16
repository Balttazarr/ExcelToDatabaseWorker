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
        public string NameOf { get; set; }
        public BelogningType Type { get; set; }
        [Required]
        public PersonModel Person { get; set; }
    }
}
