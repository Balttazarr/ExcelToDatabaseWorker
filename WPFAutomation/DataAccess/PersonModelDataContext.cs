using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAutomation.Models;

namespace WPFAutomation
{
    public class PersonModelDataContext
    {
        //private readonly string connectionString = ConnectionStringHelper.ConnectionValue("ConnectionString");

        internal void InsertToDb(IDbConnection connection, List<PersonModel> listOfPeople )
        {
            //string ID, string FirstName, string lastName, DateTime date
            //var param = new DynamicParameters();
            //param.Add("@Id", ID);
            //param.Add("@firstName", FirstName);
            //param.Add("@lastName", lastName);
            //param.Add("@date", date);

            connection.Execute("dbo.spPeople_InsertBulk @ID, @FirstName, @LastName, @DateOfBirth", listOfPeople);
            
        }

        internal List<PersonModel> GetAllFromDb(IDbConnection conn)
        {
            return conn.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
        }
    }
}
