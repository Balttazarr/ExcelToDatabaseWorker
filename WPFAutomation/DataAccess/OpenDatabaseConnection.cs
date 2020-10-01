using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFAutomation
{
    public  class OpenDatabaseConnection
    {

        public static IDbConnection GetConnection(string connString)
        { 
            try
            {
                var connection = new SqlConnection(ConnectionStringHelper.ConnectionValue(connString));
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot connect to database :c", e.Message);
                return null;
            }
        }
    }
}
