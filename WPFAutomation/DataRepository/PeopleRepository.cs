using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WPFAutomation.Models;

namespace WPFAutomation.DataRepository
{
    public class PeopleRepository : IPeopleRepository
    {
        private IDbConnection db;

        public PeopleRepository(string connString)
        {
            db = new SqlConnection(connString);
        }


        public PersonModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
