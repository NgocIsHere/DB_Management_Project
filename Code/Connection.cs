<<<<<<< HEAD
﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;
=======
﻿
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
>>>>>>> userlist
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
<<<<<<< HEAD
        string password = "Kurumilove<3";
=======
        string password = "ngoc123";
>>>>>>> userlist

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
<<<<<<< HEAD
                connection.Open();       
=======
                connection.Open();
                Console.WriteLine("Kết nối thành công");
                ExecuteQueryAndPrintResults("SELECT * FROM NHANVIEN");

                MessageBox.Show("Kết nối thành công");


>>>>>>> userlist
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }
<<<<<<< HEAD

        public void disconnect()
        {
            connection.Close();
        }

        
       
=======
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
>>>>>>> userlist
    }
}
