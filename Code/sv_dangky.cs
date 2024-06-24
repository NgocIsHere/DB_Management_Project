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
namespace DB_Management
{
    public partial class sv_dangky : UserControl
    {
        private Connection connection;
        string admin = "ADMIN_OLS";
        public sv_dangky()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            /*
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.Name = "Check";
                        checkBoxColumn.HeaderText = "Chọn";
                        dataGridView1.Columns.Add(checkBoxColumn);
                        dataGridView1.DataSource = table1;
                        dataGridView1.Columns["Check"].ReadOnly = false;*/

            //DisplayUserData();
            init();

        }
    
        private void init()
        {
            int quantity1 = 0;
            string query = $"SELECT DISTINCT HK FROM  {admin}.project_dangky"; // Thay your_table và column_name bằng tên bảng và tên cột thực tế
            OracleCommand command1 = new OracleCommand(query, connection.connection);

            // Sử dụng SqlDataReader để đọc dữ liệu từ truy vấn
            OracleDataReader reader1 = command1.ExecuteReader();

            // Xóa dữ liệu cũ khỏi ComboBox trước khi điền dữ liệu mới
            comboBox1.Items.Clear();

            // Điền dữ liệu từ cột vào ComboBox
            while (reader1.Read())
            {
                comboBox1.Items.Add(reader1["HK"].ToString()); // Thay column_name bằng tên cột bạn muốn điền vào ComboBox
            }
            comboBox1.Items.Add("Tất cả");

            string query1 = $"SELECT * FROM {admin}.project_dangky";

            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "Check";
            checkBoxColumn.HeaderText = "Chọn";
            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.DataSource = table1;
            dataGridView1.Columns["Check"].ReadOnly = false;
        }

        private void DisplayUserData()
        {
            
            int quantity1 = 0;
            string query = $"SELECT DISTINCT HK FROM  {admin}.project_dangky"; // Thay your_table và column_name bằng tên bảng và tên cột thực tế
            OracleCommand command1 = new OracleCommand(query, connection.connection);

            // Sử dụng SqlDataReader để đọc dữ liệu từ truy vấn
            OracleDataReader reader1 = command1.ExecuteReader();

            // Xóa dữ liệu cũ khỏi ComboBox trước khi điền dữ liệu mới
            comboBox1.Items.Clear();

            // Điền dữ liệu từ cột vào ComboBox
            while (reader1.Read())
            {
                comboBox1.Items.Add(reader1["HK"].ToString()); // Thay column_name bằng tên cột bạn muốn điền vào ComboBox
            }
            comboBox1.Items.Add("Tất cả");

            string query1 = $"SELECT * FROM {admin}.project_dangky";

            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            dataGridView1.DataSource = table1;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query1;
            if (comboBox1.Text.ToString() == "1")
            {
                query1 = $"SELECT * FROM {admin}.project_dangky where HK = 1";

            }
            else if (comboBox1.Text.ToString() == "2")
            {
                query1 = $"SELECT * FROM {admin}.project_dangky where HK = 2";

            }
            else if (comboBox1.Text.ToString() == "3")
            {
                query1 = $"SELECT * FROM {admin}.project_dangky where HK = 3";
            }
            else
            {
                query1 = $"SELECT * FROM {admin}.project_dangky";
            }
            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
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
                string deleteQuery = $"DELETE FROM {admin}.PROJECT_DANGKY " +
                         "WHERE MAGV = :p_magv " +
                         "AND MAHP = :p_mahp " +
                         "AND HK = :p_hk " +
                         "AND NAM = :p_nam";
                // Check if the checkbox is checked
                if (chk.Value is true)
                {
                    MAHP = row.Cells["MAHP"].Value.ToString();
                    MAGV = row.Cells["MAGV"].Value.ToString();
                    HK = int.TryParse(row.Cells["HK"].Value?.ToString(), out int hkValue) ? hkValue : 0;
                    Nam = int.TryParse(row.Cells["NAM"].Value?.ToString(), out int namValue) ? namValue : 0;
                    try
                    {
                        using (OracleCommand command = new OracleCommand(deleteQuery, connection.connection))
                        {
                            command.Parameters.Add("p_magv", OracleDbType.Varchar2).Value = MAGV;
                            command.Parameters.Add("p_mahp", OracleDbType.Varchar2).Value = MAHP;
                            command.Parameters.Add("p_hk", OracleDbType.Int32).Value = HK;
                            command.Parameters.Add("p_nam", OracleDbType.Int32).Value = Nam;

                            Debug.WriteLine(command.CommandText);

                            // Execute the command
                            command.ExecuteNonQuery();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    

                }
                DisplayUserData();


            }
        }
    }
}
