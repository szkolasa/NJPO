using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NJPO.Database
{
    public class DBConnector
    {
        private static DBConnector _instance;
        private string _connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NJPO;Integrated Security=True";

        public static DBConnector Instance
        {
            get { return _instance ?? new DBConnector(); }
        }

        private DBConnector()
        {

        }

        public SqlDataReader Query(string query)
        {
            using (var connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                return command.ExecuteReader();
            }
        }
    }
}
