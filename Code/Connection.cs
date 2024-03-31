using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLPHONGKHAM
{
    internal class Connection
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;
        public SqlDataAdapter adapter;
        public string connectionStr = ConfigurationManager.ConnectionStrings["PHONGKHAM_DBConnectionString"].ConnectionString;
        public void connect()
        {
            try
            {
                connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Open)
                {
                    //do nothing
                }
                else
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            else
            {
                //do nothing
            }
        }

        public void CheckConnect()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    this.connect();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insert (string query)
        {
            this.CheckConnect();
            
            try
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void delete (string query)
        {
            this.CheckConnect();
            
            try
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void update (string query)
        {
            this.CheckConnect();
            try
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExecuteStoredProcedureWithoutParams(string storedProcedureName)
        {
            this.CheckConnect();

            try
            {
                command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int ExecuteStoredProcedureWithParams(string storedProcedureName, SqlParameter[] parameters)
        {
            this.CheckConnect();
            int returnValue = int.MinValue; // Default value for error

            try
            {
                command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                // Adding parameters if there are any
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                // Adding a return parameter to get the stored procedure's return value
                SqlParameter returnParameter = command.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                // Get the return value from the stored procedure
                returnValue = (int)returnParameter.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return returnValue;
        }

        public DataTable dataTable (string query)
        {
            CheckConnect();
            DataTable dt = new DataTable();
            try
            {
                command = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return (dt);
        }

        public DataTable dataTableWithParams(string storedProcedureName, SqlParameter[] parameters)
        {
            CheckConnect();
            DataTable dt = new DataTable();
            try
            {
                command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dt;
        }
    }
}
