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
using System.Windows.Markup;
namespace DB_Management
{
    public partial class sv_dangkyhp : UserControl
    {
        private Connection connection; 
        public sv_dangkyhp()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            DisplayUserData();
        }
    

        private void DisplayUserData()
        {
            DateTime now = DateTime.Now;
            DateTime deadline = new DateTime(2024,5,17);
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "Check";
            checkBoxColumn.HeaderText ="Đăng ký";
            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.Columns.Add("Mã học phần", "Mã học phần");
            dataGridView1.Columns.Add("Tên học phần", "Tên học phần");
            dataGridView1.Columns.Add("Số TC", "Số TC");

            // Optionally set column types, widths, etc.
            dataGridView1.Columns["Mã học phần"].Width = 100;
            dataGridView1.Columns["Tên học phần"].Width = 150;
            dataGridView1.Columns["Số TC"].Width = 200;
            dataGridView1.Columns["Mã học phần"].ReadOnly = true;
            dataGridView1.Columns["Tên học phần"].ReadOnly = true;
            dataGridView1.Columns["Số TC"].ReadOnly = true;
            dataGridView1.Columns["Check"].ReadOnly = false;
            if (now < deadline)
            {
                string query1 = "SELECT * FROM C##ADMIN.V_PROJECT_DKHP WHERE NAM =" + now.Year.ToString() +" AND MAHP NOT IN (SELECT MAHP FROM C##ADMIN.PROJECT_DANGKY WHERE NAM="+ now.Year.ToString()+")";
                label2.Hide();
                OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
                System.Data.DataTable table1 = new System.Data.DataTable();
                adapter1.Fill(table1);

                foreach (DataRow row in table1.Rows)
                {
                    
                        dataGridView1.Rows.Add(0, row["MAHP"].ToString(), row["TENHP"].ToString(), row["SOTC"].ToString());
                    
                }
                flowLayoutPanel1.Show();
            }
            else
            {
                label2.Show();
                flowLayoutPanel1.Hide();
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            DisplayUserData();
        }

     
        
        private void userList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
