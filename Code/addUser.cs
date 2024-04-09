using DB_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace DB_Management
{
    public partial class addUser : UserControl
    {
        Connection connection = new Connection();
        List<string> privileges = new List<string>();
        List<string> queries = new List<string>();
        DataSource DS = new DataSource();
        
        public addUser()
        {
            InitializeComponent();
            loadListView();
            connection.connect();
            loadRole();
            loadPrivileges();


        }

        private void loadRole()
        {
            //SELECT * FROM USER_ROLE_PRIVS;
            using (OracleCommand cmd = new OracleCommand("SELECT * FROM DBA_ROLES WHERE ROLE LIKE 'C##%'", connection.connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string role = reader.GetString(0);
                        comboBox1.Items.Add(role);
                    }
                }
            }
        }

        private void loadPrivileges()
        {
            listView3.Font = new Font("Consolas", 14);
            listView3.Columns.Add("Privileges", 180);
            listView3.View = View.Details;
            listView3.CheckBoxes = true;
            List<string> privileges = new List<string>() { Privilege.Select, Privilege.Update, Privilege.Insert, Privilege.Delete };
            foreach (string privilege in privileges)
            {
                ListViewItem item = new ListViewItem(privilege);
                listView3.Items.Add(item);
            }
        }

        private void loadListView2(string name)
        {
            
            connection.connect();
            List<string> columns = DS.getAllObject(DS.getQueryTableColumn(name), "COLUMN_NAME");
            foreach (string column in columns)
            {
                ListViewItem item = new ListViewItem(column);
                listView2.Items.Add(item);
                Debug.WriteLine(1);
            }
            connection.disconnect();
        }


        private void loadListView()
        {
            listView1.Font = new Font("Consolas", 14);
            listView1.Columns.Add("Table", 180);
            listView1.View = View.Details;

            listView2.View = View.Details;
            listView2.Columns.Add("Column Names", -2, HorizontalAlignment.Left);
            listView2.Font = new Font("Consolas", 14);


            connection.connect();
            List<string> Tables = DS.getAllObject(DataSource.table_query, "TABLE_NAME");
            foreach (string table in Tables)
            {
                ListViewItem item = new ListViewItem(table);
                listView1.Items.Add(item);
            }
            connection.disconnect();

        }


        
        private void createUser()
        {
            using (OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }

            using (OracleCommand cmd = new OracleCommand($"CREATE USER {textBox1.Text} IDENTIFIED BY {textBox2.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            using  (OracleCommand cmd = new OracleCommand($"GRANT CONNECT TO {textBox1.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = new OracleCommand($"GRANT CREATE SESSION TO {textBox1.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createUser();



            for (int i = 0; i < listView3.Items.Count; i++)
            {
                if (listView3.Items[i].Checked)
                {
                    privileges.Add(listView3.Items[i].Text);
                }
                else if (listView3.Items[i].Checked == false)
                {
                    privileges.Remove(listView3.Items[i].Text);
                }
            }

            privileges = privileges.Distinct().ToList();
            for (int i = 0; i < privileges.Count; i++)
            {
                Debug.WriteLine(privileges[i]);
            }

            for (int i = 0; i< listView1.Items.Count;i++)
            {
                if (listView2.Items.Count == 0)
                {
                    if (listView1.Items[i].Selected)
                    {
                        string tableName = listView1.Items[i].Text;

                        queries.Add($"GRANT {string.Join(", ", privileges)} ON {tableName} TO {textBox1.Text}");
                    }
                }
            }    

            if (listView2.Items.Count > 0)
            {
                List<string> tables = new List<string>();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        tables.Add(listView1.Items[i].Text);
                    }
                }
                List<string> columns = new List<string>();
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Selected)
                    {
                        columns.Add(listView2.Items[i].Text);
                    }
                }
                if(privileges.Contains("SELECT"))
                {
                    string query = $"CREATE OR REPLACE VIEW {textBox1.Text}_SELECT AS SELECT {string.Join(", ", columns)} FROM {string.Join(", ", tables)}";
                    queries.Add(query);
                    string grant = $"GRANT SELECT ON {textBox1.Text}_SELECT TO {textBox1.Text}";
                    queries.Add(grant);
                }

            }
          

            if (comboBox1.SelectedItem != null)
            {
                if(checkBox1.Checked)
                {
                    using (OracleCommand cmd = new OracleCommand($"GRANT {comboBox1.SelectedItem.ToString()} TO {textBox1.Text} WITH ADMIN OPTION", connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (OracleCommand cmd = new OracleCommand($"GRANT {comboBox1.SelectedItem.ToString()} TO {textBox1.Text}", connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                for (int i = 0; i < queries.Count; i++)
                {
                    using (OracleCommand cmd = new OracleCommand(queries[i], connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            connection.disconnect();
            /*this.Close();*/
        }



        private void addUser_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
/*            if (checkedListBox1.GetItemChecked(0) == true || checkedListBox1.GetItemChecked(1) == true)
            {
                loadListView2(listView1.SelectedItems[0].Text);
            }*/
        }

         
       

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < privileges.Count; i++)
            {
                Debug.WriteLine(privileges[i]);
            }

            listView1.SelectedItems.Clear();
            listView2.Items.Clear();
            //checkedListBox1.ClearSelected();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = listView3.SelectedItems[0];

        }
    }
}
