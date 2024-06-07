using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;﻿
using System.Collections.Generic;
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
        string serviceName = "PROJECT_DBMANAGEMENT";
        string userId = Config.username;
        string password = Config.password;

        string connectionString;

        public Connection()
        {
            connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={serviceName})));User Id={userId};Password={password};";
        }

        public string connect()
        {
            connection = new OracleConnection(connectionString);
            string msg;
            try
            {
                connection.Open();
                msg = "complete";
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Kết nối thất bại: " + ex.Message);*/
                msg = "error";
            }
            return msg;
        }

        public void disconnect()
        {
            connection.Close();
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
