using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace Update
{
    internal class Connection
    {
        public OracleConnection connection;
        public OracleCommand command;
        public OracleDataReader reader;
        string host = "DESKTOP-TSRDGQV";
        string port = "1521";
        string sid = "xe";
        string userId = "sys";
        string password = "123";

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
                Console.WriteLine("Kết nối thành công");
                //MessageBox.Show("Kết nối thành công");               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }

        public void print()
        {
            MessageBox.Show(connectionString);
        }
        public void ExecuteQueryAndPrintResults(string query)
        {
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                try
                {
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Query execution failed: " + ex.Message);
                }
            }
        }
    }
}
