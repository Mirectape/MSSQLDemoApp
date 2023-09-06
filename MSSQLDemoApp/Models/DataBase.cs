using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MSSQLDemoApp.Models
{
    public class DataBase
    {
        private static SqlConnectionStringBuilder _strCon;

        static DataBase()
        {
            _strCon = new SqlConnectionStringBuilder()
            {
                DataSource = @"DESKTOP-ECEJ6EC\SQLEXPRESS",
                InitialCatalog = "WorkersDB",
                IntegratedSecurity = true,
                //Pooling = false
            };
        }

        private SqlConnection _sqlConnection;

        public DataBase()
        {
            _sqlConnection = new SqlConnection(_strCon.ConnectionString);
        }


        public void OpenConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return _sqlConnection;
        }
    }
}
