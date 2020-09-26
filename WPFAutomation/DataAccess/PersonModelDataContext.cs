using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAutomation
{
    public class PersonModelDataContext
    {
        private string connectionString = ConfigurationManager.AppSettings["ConnectionString"]; // const?

        public void InsertToDb(string ID, string FirstName, string lastName, DateTime date)
        {
            var param = new DynamicParameters();
            param.Add("@Id", ID);
            param.Add("@firstName", FirstName);
            param.Add("@lastName", lastName);
            param.Add("@date", date);


            var sql = "INSERT INTO test (ID,FirstName,LastName,DateOfBirth) " +
                      "VALUES (@Id, @firstName, @lastName, @date)";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(sql,param);
            }
        }
    }
}
