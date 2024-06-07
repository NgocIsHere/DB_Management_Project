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
using DB_Management;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_Management
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
            stringsql = $"Data Source=localhost:1521/PROJECT_DBMANAGEMENT;User Id={Config.username};Password={Config.password};";
            conn = new OracleConnection(stringsql);
        }
        public List<string> getAllObject(string query, string column)
        {
            List<string> myobject = new List<string>();
            OracleCommand command = new OracleCommand(query, conn);
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
            //MessageBox.Show(command.CommandText);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string viewtable = reader["TABLE_NAME"].ToString();
                if (viewtable.Contains("PROJECT_UV"))
                { // day la view cho select tren cot
                    OracleDataReader reader1 = new OracleCommand("SELECT * FROM ALL_VIEWS" +
                        " WHERE VIEW_NAME ='" + viewtable + "'", conn).ExecuteReader();
                    reader1.Read();
                    string text = reader1["TEXT_VC"].ToString();
                    string tablename = text.Substring(text.IndexOf("FROM ") + 5);
                    string[] columnselect = text.Substring(7, text.IndexOf(" FROM " + tablename) - 7).Split(',');
                    if (!role.existTable(tablename))
                    {
                        List<string> columnnames = new List<string>();
                        //get all column from table
                        OracleDataReader reader2 = new OracleCommand(getQueryTableColumn(
                            tablename), conn).ExecuteReader();
                        while (reader2.Read())
                        {
                            columnnames.Add(reader2["COLUMN_NAME"].ToString());
                        }
                        //create table
                        role.tables.Add(new Table(tablename, columnnames));
                    }
                    Table table = role.GetTable(tablename);
                    foreach (string col in columnselect)
                    {
                        table.editPrivilege(col, Privilege.S, Privilege.GRANT);
                    }
                }
                else
                { // day la table
                    if (!role.existTable(viewtable))
                    {
                        List<string> columnnames = new List<string>();
                        //get all column from table
                        OracleDataReader reader1 = new OracleCommand(getQueryTableColumn(
                            viewtable), conn).ExecuteReader();
                        while (reader1.Read())
                        {
                            columnnames.Add(reader1["COLUMN_NAME"].ToString());
                        }
                        //create table
                        role.tables.Add(new Table(reader["TABLE_NAME"].ToString(), columnnames));
                    }
                    //add privilege to table
                    Table table = role.GetTable(reader["TABLE_NAME"].ToString());
                    if (reader["PRIVILEGE"].ToString().Equals("SELECT"))
                    {
                        table.editPrivilege(Table.all, Privilege.S, Privilege.GRANT);
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
                }
            }
            conn.Close();
            return role;
        }
        public string[] getColumnView(string viewname)
        {
            conn.Open();
            OracleDataReader reader1 = new OracleCommand("SELECT * FROM ALL_VIEWS" +
                        " WHERE VIEW_NAME ='" + viewname + "'", conn).ExecuteReader();
            reader1.Read();
            string text = reader1["TEXT_VC"].ToString().ToUpper();
            string tablename = text.Substring(text.IndexOf("FROM ") + 5);
            string[] columnselect = text.Substring(7, text.IndexOf(" FROM " + tablename) - 7).Split(',');
            conn.Close();
            return columnselect;
        }
        public string getQueryTableColumn(string tablename)
        {
            string result = "SELECT column_name " +
                "FROM USER_TAB_COLUMNS WHERE table_name = '" + tablename + "'";
            //MessageBox.Show(result);
            return result;
        }
        public string getQueryTableRole(string rolename)
        {
            return "SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "'";
        }
        public string getQueryTableRoledistinct(string rolename)
        {
            return "SELECT DISTINCT PRIVILEGE,TABLE_NAME FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "'";
        }
        public string getQueryColumnForm(string tablename, string rolename, string type)
        {
            //MessageBox.Show("SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "' AND " +
            //    "PRIVILEGE = '" + type + "' AND TABLE_NAME = '" + tablename + "'");
            return "SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "' AND " +
                "PRIVILEGE = '" + type + "' AND TABLE_NAME = '" + tablename + "'";
        }
        public string getQueryUserTabPri(string username, string type)
        {
            return "SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE = '" +
                username + "' AND TYPE = '" + type + "'";
        }
        public string getQueryUserTabPriV2(string username, string type)
        {
            return "SELECT DISTINCT TABLE_NAME FROM USER_TAB_PRIVS WHERE GRANTEE = '" +
                username + "' AND TYPE = '" + type + "'";
        }
        public string getPriUsrFromTab(string username, string tablename)
        {
            return "SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE = '" +
                username + "' AND TABLE_NAME = '" + tablename + "'";
        }
        public string getQueryPriOfUsr(string usr)
        {
            return "SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE = '" + usr + "'";
        }
        public string getQueryRoleMember(string role)
        {
            return "SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE = '" + role + "'";
        }
        public string getQueryRoleUser(string user)
        {
            return "SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = '" + user + "'";
        }
        public bool createRole(Role role)
        {
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            conn.Open();
            command.ExecuteNonQuery();
            role.Name = role.Name.ToUpper();
            role.Name = role.Name.Contains("C##P_") ? role.Name : "C##P_" + role.Name;
            command.CommandText = "CREATE ROLE " + role.Name;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid role name! Check and try again!");
                return false;
            }
            finally
            {
                conn.Close();
            }
            return updateRole(role);
        }
        public bool updateRole(Role role, string oldrolename = "")
        {
            conn.Open();
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            command.ExecuteNonQuery();
            if (!oldrolename.Equals(""))
            {
                bool isdelete = false;
                role.Name = role.Name.ToUpper();
                role.Name = role.Name.Contains("C##P_") ? role.Name : "C##P_" + role.Name;
                if (role.Name.Equals(oldrolename))
                {
                    command.CommandText = "DROP ROLE " + oldrolename;
                    command.ExecuteNonQuery();
                    isdelete = true;
                }
                command.CommandText = "CREATE ROLE " + role.Name;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Invalid role name! Check and try again!");
                    conn.Close();
                    return false;
                }
                if (!isdelete)
                {
                    command.CommandText = "DROP ROLE " + oldrolename;
                    command.ExecuteNonQuery();
                }
            }
            string rolename = role.Name;
            List<string> privileges = new List<string> { "SELECT", "INSERT", "DELETE", "UPDATE" };

            foreach (Table table in role.tables)
            {
                //grant privilige select on table
                List<string> column_select = table.getAllColumnSelect();

                if (column_select.Count > 0)
                {
                    string newView = "PROJECT_UV_" + role.Name.Substring(5) + "_" + table.Name.Substring(8);
                    string selectquery = string.Join(",", column_select);
                    command.CommandText = "CREATE OR REPLACE VIEW " + newView
                        + " AS SELECT " + selectquery + " FROM " + table.Name;
                    command.ExecuteNonQuery();
                    command.CommandText = " GRANT SELECT ON " + newView + " TO " + role.Name;
                    command.ExecuteNonQuery();
                }
                //grant privilige on table
                for (int i = 1; i < privileges.Count; i++)
                {
                    if (table.checkPrivilege(Table.all, i, Privilege.GRANT))
                    {
                        command.CommandText = "GRANT " + privileges[i]
                            + " ON " + table.Name + " TO " + rolename;
                        command.ExecuteNonQuery();
                    }
                }
                if (table.checkPrivilege(Table.any, Privilege.U, Privilege.GRANT))
                {
                    //grant privilige update on column
                    foreach (string column in table.columns)
                    {
                        if (table.checkPrivilege(column, Privilege.U, Privilege.GRANT))
                        {
                            command.CommandText = "GRANT UPDATE(" + column
                            + ") ON " + table.Name + " TO " + rolename;
                            command.ExecuteNonQuery();
                        }
                    }
                }

            }
            conn.Close();
            return true;
        }
        public bool updateUser(Role user,ListView lv_role)
        {
            List<string> oldpris = getAllObject(getQueryPriOfUsr(user.Name), "PRIVILEGE");
            List<string> oldtabs = getAllObject(getQueryPriOfUsr(user.Name), "TABLE_NAME");
            conn.Open();
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            command.ExecuteNonQuery();
            List<string> Pris = new List<string>() { "SELECT", "INSERT", "DELETE", "UPDATE" };
            for (int i = 0; i < oldpris.Count; i++)
            {
                command.CommandText = "REVOKE " + oldpris[i] + " ON " + oldtabs[i] + " FROM " + user.Name;
                command.ExecuteNonQuery();
            }
            foreach (Table table in user.tables)
            {
                for (int i = 0; i < Pris.Count; i++)
                {
                    if (i == Privilege.S || i == Privilege.U)
                    {
                        if (table.checkPrivilege(Table.any, i, Privilege.GRANT))
                        {
                            string ch = i == Privilege.S ? "S_" : "U_";
                            string username = user.Name.Substring(10).ToUpper();
                            string tablename = table.Name.Substring(8).ToUpper();
                            string viewname;
                            List<string> columngrant = table.getAllColumnCheck(i, Privilege.GRANT);
                            List<string> columnwgo = table.getAllColumnCheck(i, Privilege.WITH_GRANT_OPTION);
                            if (columngrant.Count > 0)
                            {
                                viewname = "PROJECT_" + ch + username + "_" + tablename;
                                command.CommandText = "CREATE OR REPLACE VIEW " + viewname +
                                    " AS SELECT " + string.Join(",", columngrant)
                                    + " FROM " + table.Name;
                                command.ExecuteNonQuery();
                                //MessageBox.Show(command.CommandText);
                                command.CommandText = "GRANT " + Pris[i] + " ON " + viewname + " TO " + user.Name;
                                //MessageBox.Show(command.CommandText);
                                command.ExecuteNonQuery();
                            }
                            if (columnwgo.Count > 0)
                            {
                                viewname = "PROJECT_" + ch + username + "_WGO_" + tablename;
                                command.CommandText = "CREATE OR REPLACE VIEW " + viewname +
                                    " AS SELECT " + string.Join(",", columnwgo)
                                    + " FROM " + table.Name;
                                command.ExecuteNonQuery();
                                //MessageBox.Show(command.CommandText);
                                command.CommandText = "GRANT " + Pris[i] + " ON " + viewname + " TO " + user.Name
                                    + " WITH GRANT OPTION";
                                //MessageBox.Show(command.CommandText);
                                command.ExecuteNonQuery();
                            }

                        }
                    }
                    else
                    {
                        if (table.checkPrivilege(Table.all, i, Privilege.GRANT))
                        {
                            command.CommandText = "GRANT " + Pris[i] + " ON " + table.Name + " TO " + user.Name;
                            if (table.checkPrivilege(Table.all, i, Privilege.WITH_GRANT_OPTION))
                            {
                                command.CommandText += " WITH GRANT OPTION";
                            }
                            //MessageBox.Show(command.CommandText);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            conn.Close();
            return grantRoleUsr(lv_role, user.Name);
        }
        private bool grantRoleUsr(ListView lv_role,string username)
        {
            List<string> role_usr = getAllObject(getQueryRoleUser(username), "GRANTED_ROLE");
            conn.Open();
            try
            {
                OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
                command.ExecuteNonQuery();
                
                foreach(ListViewItem item in lv_role.Items)
                {
                    if(!item.Checked && role_usr.Contains(item.Text))
                    {
                        command.CommandText = "REVOKE " + item.Text + " FROM " + username;
                        command.ExecuteNonQuery();
                    }
                    else if(item.Checked && !role_usr.Contains(username))
                    {
                        command.CommandText = "GRANT " + item.Text + " TO " + username;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public void deleteRoleByName(string rolename)
        {
            conn.Open();
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            command.ExecuteNonQuery();
            command.CommandText = "DROP ROLE " + rolename;
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteUserByName(string usrname)
        {
            conn.Open();
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            command.ExecuteNonQuery();
            command.CommandText = "DROP USER " + usrname + " CASCADE" ;
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
