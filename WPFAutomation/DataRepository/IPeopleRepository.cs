using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.Models;

namespace WPFAutomation.DataRepository
{
    interface IPeopleRepository
    {
        
        List<PersonModel> GetAll();
        PersonModel Find(int id);

    }
}
