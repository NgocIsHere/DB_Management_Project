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
        string admin = "ADMIN_OLS";
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
            DateTime deadline = new DateTime(2024,6,6);
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "Check";
            checkBoxColumn.HeaderText ="Đăng ký";
            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.Columns.Add("MaGV", "Mã GV");
            dataGridView1.Columns.Add("Mã học phần", "Mã học phần");
            dataGridView1.Columns.Add("Tên học phần", "Tên học phần");
            dataGridView1.Columns.Add("HK", "HK");
            dataGridView1.Columns.Add("Năm", "Năm");
            dataGridView1.Columns.Add("Số TC", "Số TC");

            // Optionally set column types, widths, etc.
            dataGridView1.Columns["Mã học phần"].Width = 100;
            dataGridView1.Columns["Tên học phần"].Width = 150;
            dataGridView1.Columns["Số TC"].Width = 200;
            dataGridView1.Columns["Mã học phần"].ReadOnly = true;
            dataGridView1.Columns["Tên học phần"].ReadOnly = true;
            dataGridView1.Columns["Số TC"].ReadOnly = true;
            dataGridView1.Columns["Check"].ReadOnly = false;
            dataGridView1.Columns["MaGV"].ReadOnly = true;
            if (now < deadline)
            {
                string query1 = $"SELECT * FROM {admin}.V_PROJECT_DKHP WHERE NAM =" + now.Year.ToString() +" AND MAHP NOT IN (SELECT MAHP FROM C##ADMIN.PROJECT_DANGKY WHERE NAM="+ now.Year.ToString()+")";
                label2.Hide();
                OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
                System.Data.DataTable table1 = new System.Data.DataTable();
                adapter1.Fill(table1);

                foreach (DataRow row in table1.Rows)
                {
                    
                        dataGridView1.Rows.Add(0, row["MAGV"].ToString(), row["MAHP"].ToString(), row["TENHP"].ToString(), row["HK"].ToString(), row["NAM"].ToString(), row["SOTC"].ToString());
                    
                }
                flowLayoutPanel1.Show();
            }
            else
            {
                label2.Show();
                flowLayoutPanel1.Hide();
            }
            
        }



        private void userList_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Check"];
                string result = "";
                string MAHP = "";
                string MAGV = "";
                int HK;
                int Nam;
                // Check if the checkbox is checked
                if (chk.Value is true)
                {
                    MAHP = row.Cells["Mã học phần"].Value.ToString();
                    MAGV = row.Cells["MaGV"].Value.ToString();
                    HK = int.TryParse(row.Cells["HK"].Value?.ToString(), out int hkValue) ? hkValue : 0;
                    Nam = int.TryParse(row.Cells["Năm"].Value?.ToString(), out int namValue) ? namValue : 0;
                    using (OracleCommand command = new OracleCommand("C##ADMIN.InsertProjectDangKy", connection.connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = '1';
                        command.Parameters.Add("p_magv", OracleDbType.Varchar2).Value = MAGV;
                        command.Parameters.Add("p_mahp", OracleDbType.Varchar2).Value = MAHP;
                        command.Parameters.Add("p_hk", OracleDbType.Int32).Value = HK;
                        command.Parameters.Add("p_nam", OracleDbType.Int32).Value = Nam;
                        command.Parameters.Add("p_mact", OracleDbType.Varchar2).Value = "CTTT";

                        // Execute the command
                        command.ExecuteNonQuery();
                        DisplayUserData();

                    }

                }

            }
        }
    }
}
