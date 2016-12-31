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

        /// <summary>
        /// Executes Query statements like Select
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DbDataReader Query(string query)
        {
            DbConnection connection = new SqlConnection();
            connection.ConnectionString = _connection;

            connection.Open();

            DbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = query;

            return command.ExecuteReader();
        }


        /// <summary>
        /// Executes NonQuery statements like Insert, Update, Delete
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int NonQuery(string query)
        {
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connection;

                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = query;

                return command.ExecuteNonQuery();
            }
        }
    }
}
