using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace project
{
    internal class DataSource
    {
        public string stringsql;
        public OracleConnection conn;
        public static string role_query = "SELECT * FROM DBA_ROLES WHERE ROLE LIKE 'C##P_%'";
        public static string table_query = "select table_name from all_tables where table_name like 'PROJECT_%'";
        public static string role_table_query = "SELECT * FROM ROLE_TAB_PRIVS";
        public DataSource()
        {
            stringsql = "Data Source=localhost:1521/XE;User Id=C##ADProject;Password=123;";
            conn = new OracleConnection(stringsql);
        }
        public List<string> getAllObject(string query, string column)
        {
            List<string> myobject = new List<string>();
            OracleCommand command = new OracleCommand(query,conn);
            conn.Open();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string result = reader[column].ToString();
                myobject.Add(result);
            }
            conn.Close();
            return myobject;
        }
        public Role getRoleByName(string name)
        {
            Role role = new Role(name);
            OracleCommand command = new OracleCommand(getQueryTableRole(name), conn);
            conn.Open();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!role.existTable(reader["TABLE_NAME"].ToString()))
                {
                    List<string> columnnames = new List<string>();
                    //get all column from table
                    OracleDataReader reader1 = new OracleCommand(getQueryTableColumn(
                        reader["TABLE_NAME"].ToString()),conn).ExecuteReader();
                    while (reader1.Read())
                    {
                        columnnames.Add(reader1["COLUMN_NAME"].ToString());
                    }
                    //create table
                    Table table = new Table(reader["TABLE_NAME"].ToString(), columnnames);
                    
                    //add privilege to table
                    if (reader["PRIVILEGE"].ToString().Equals("SELECT"))
                    {
                        table.editPrivilege(Table.all,Privilege.S, Privilege.GRANT);
                    }
                    else if (reader["PRIVILEGE"].ToString().Equals("INSERT"))
                    {
                        table.editPrivilege(Table.all, Privilege.I, Privilege.GRANT);
                    }
                    else if (reader["PRIVILEGE"].ToString().Equals("DELETE"))
                    {
                        table.editPrivilege(Table.all, Privilege.D, Privilege.GRANT);
                    }
                    else if (reader["PRIVILEGE"].ToString().Equals("UPDATE"))
                    {
                        string column = reader["COLUMN_NAME"].ToString()
                            .Equals("(null)") ? Table.all : reader["COLUMN_NAME"].ToString();
                        table.editPrivilege(column, Privilege.U, Privilege.GRANT);
                    }
                    role.tables.Add(table);
                }
            }
            conn.Close();
            return role;
        }
        public string getQueryTableColumn(string tablename)
        {
            string result=  "SELECT column_name " +
                "FROM USER_TAB_COLUMNS WHERE table_name = '" + tablename+"'";
            //MessageBox.Show(result);
            return result;
        }
        public string getQueryTableRole(string rolename)
        {
            return "SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename+"'";
        }
        public void createRole(Role role)
        {
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            conn.Open();
            command.ExecuteNonQuery();
            command.CommandText = "CREATE ROLE C##P_" + role.Name;
            role.Name = "C##P_"+role.Name;
            command.ExecuteNonQuery();
            conn.Close();
            updateRole(role);
            
        }
        public void updateRole(Role role)
        {
            List<string> privileges = getAllObject(getQueryTableRole(role.Name), "PRIVILEGE");
            List<string> tablenames = getAllObject(getQueryTableRole(role.Name), "TABLE_NAME");
            conn.Open();
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            command.ExecuteNonQuery();
            // delete all privilege
            string rolename = role.Name;
            for(int i =0;i<privileges.Count;i++)
            {
                command.CommandText = "REVOKE " + privileges[i] +" ON " + tablenames[i] +" FROM "+rolename;
                command.ExecuteNonQuery();
            }
            // add all privilge
            privileges = new List<string> { "SELECT","INSERT","DELETE","UPDATE" };
            
            foreach(Table table in role.tables)
            {
                
                //grant privilige on table
                for (int i = 0; i < privileges.Count; i++)
                {
                    if (table.checkPrivilege(Table.all, i, Privilege.GRANT))
                    {
                        command.CommandText = "GRANT " + privileges[i] 
                            + " ON " + table.Name + " TO "+ rolename;
                        command.ExecuteNonQuery();
                    }
                }
                if(table.checkPrivilege(Table.all, Privilege.U, Privilege.GRANT))
                {
                    //grant privilige update on column
                    foreach (string column in table.columns)
                    {
                        if (table.checkPrivilege(column, Privilege.U, Privilege.GRANT))
                        {
                            command.CommandText = "GRANT UPDATE(" +column
                            + ") ON " + table.Name + " TO "+rolename;
                            command.ExecuteNonQuery();
                        }
                    }
                }
                
            }
            conn.Close();
        }
    }
}
