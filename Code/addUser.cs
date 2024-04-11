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
        List<string> queries = new List<string>();
        DataSource DS = new DataSource();
        string prefix = "PROJECT_U_";

        public addUser()
        {
            InitializeComponent();
            loadListview();
            loadTextBox();


        }

        private void loadRole()
        {
           DS.getAllObject(DataSource.role_query, "ROLE").ForEach(role => listView1.Items.Add(role));
        }

        private void loadTextBox()
        {
            textBox3.ReadOnly = true;
            textBox3.Font = new Font("Consolas", 14, FontStyle.Regular);
            textBox2.Font = new Font("Consolas", 14, FontStyle.Regular);
            textBox1.Font = new Font("Consolas", 14, FontStyle.Regular);

            textBox3.Text = prefix;
        }
 

        private void loadListview()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.Font = new Font("Consolas", 14, FontStyle.Regular);
            listView1.CheckBoxes = true;

            listView1.Columns.Add("Role", listView1.Size.Width);

            loadRole();
        }

        private void createUser()
        {
            connection.connect();
            using (OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }

            using (OracleCommand cmd = new OracleCommand($"CREATE USER {textBox3.Text}{textBox1.Text} IDENTIFIED BY {textBox2.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = new OracleCommand($"GRANT CONNECT TO {textBox3.Text}{textBox1.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = new OracleCommand($"GRANT CREATE SESSION TO {textBox3.Text}{textBox1.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            connection.disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                createUser();
                if(listView1.CheckedItems.Count > 0)
                    addRole();
                MessageBox.Show("User created successfully");
                clearOption();
            }
        }

        private void clearOption()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = prefix;
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        private void addRole()
        {
            connection.connect();
            List<string> ListRoles = new List<string>();
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                ListRoles.Add(item.Text);
            }
            string roles = "";
            foreach (string role in ListRoles)
            {
                roles += role + ",";
            }
            roles = roles.Remove(roles.Length - 1);
            using (OracleCommand cmd = new OracleCommand($"GRANT {roles} TO {textBox3.Text}{textBox1.Text}", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }

            connection.disconnect();
            
        }
    }
}
