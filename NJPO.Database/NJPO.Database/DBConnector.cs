using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

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

        public DbDataReader Query(string query)
        {
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connection;

                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = query;

                return command.ExecuteReader();
            }
        }
    }
}
