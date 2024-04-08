using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace DB_Management
{
    internal class Connection
    {
        public OracleConnection connection;
        public OracleCommand command;
        public OracleDataReader reader;
        string host = "localhost";
        string port = "1521";
        string sid = "xe";
        string userId = "SYS";
        string password = "Kurumilove<3";

        string connectionString;

        public Connection()
        {
            connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})))(CONNECT_DATA=(SERVER=DEDICATED)(SID={sid})));User Id={userId};Password={password};DBA Privilege=SYSDBA;";
        }

        public void connect()
        {
            connection = new OracleConnection(connectionString);
            try
            {
                connection.Open();       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }

        public void disconnect()
        {
            connection.Close();
        }

        
       
    }
}
