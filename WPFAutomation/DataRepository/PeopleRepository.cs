using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public List<PersonModel> GetAll()
        {
            var selectStarCommand = db.Query<PersonModel>("SELECT * FROM People").ToList();
            return selectStarCommand;
        }

        public PersonModel Update(PersonModel personModel)
        {
            var sql = "UPDATE People " +
                "SET FirstName   = @FirstName, " +
                "    LastName    = @LastName, " +
                "    DateOfBirth = @DateOfBirth, " +
                "    Height   = @Height, " +
                "    Weight     = @Weight " +
                "WHERE Id = @Id";
            db.Execute(sql, personModel);
            return personModel;
        }

        public PersonModel Find(int id)
        {
            return db.Query<PersonModel>("SELECT * FROM People WHERE Id = @Id", new { id }).SingleOrDefault();
        }
    }
}
