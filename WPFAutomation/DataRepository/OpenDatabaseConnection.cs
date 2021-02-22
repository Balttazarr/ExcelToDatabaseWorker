using System.Data;
using System.Data.SqlClient;

namespace WPFAutomation
{
    public class OpenDatabaseConnection
    {

        public static IDbConnection GetConnection(string connString)
        {


            var connection = new SqlConnection(connString);
            connection.Open();
            return connection;



        }
    }
}
