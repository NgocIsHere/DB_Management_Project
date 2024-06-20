using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace DB_Management
{
    public partial class sv_ttcn : UserControl
    {
        private Connection connection;
        string admin = "ADMIN_OLS";
        public sv_ttcn()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            DisplayUserData();
        }
    

        private void DisplayUserData()
        {
            int quantity1 = 0;
            string query = $"SELECT * FROM {admin}.project_sinhvien";
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                            {
                                using (OracleDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        quantity1 += 1;
                                    }
                    
                                }
                            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            OracleDataAdapter adapter = new OracleDataAdapter(query, connection.connection);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

       
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlquery;
            if (textBox1.Text != "")
            {
                sqlquery = $"UPDATE {admin}.PROJECT_SINHVIEN SET DCHI = :DIACHI";
                using (OracleCommand cmd = new OracleCommand(sqlquery, connection.connection))
                {
                    cmd.Parameters.Add(new OracleParameter("DIACHI", textBox1.Text.ToString()));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} row(s) updated in DIACHI");
                }
            }
            if (textBox2.Text != "")
            {
                sqlquery = $"UPDATE {admin}.PROJECT_SINHVIEN SET DT = :SDT";
                using (OracleCommand cmd = new OracleCommand(sqlquery, connection.connection))
                {
                    cmd.Parameters.Add(new OracleParameter("SDT", textBox2.Text.ToString()));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} row(s) updated in SDT.");
                }
            }
            
            DisplayUserData();
        }

     
        
        private void userList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
