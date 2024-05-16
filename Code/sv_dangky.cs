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
        public sv_dangky()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            DisplayUserData();
        }
    

        private void DisplayUserData()
        {
            
            int quantity1 = 0;
            string query = "SELECT DISTINCT HK FROM  c##admin.project_dangky"; // Thay your_table và column_name bằng tên bảng và tên cột thực tế
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

            string query1 = "SELECT * FROM c##admin.project_dangky";

            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
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
                query1 = "SELECT * FROM c##admin.project_dangky where HK = 1";

            }
            else if (comboBox1.Text.ToString() == "2")
            {
                query1 = "SELECT * FROM c##admin.project_dangky where HK = 2";

            }
            else if (comboBox1.Text.ToString() == "3")
            {
                query1 = "SELECT * FROM c##admin.project_dangky where HK = 3";
            }
            else
            {
                query1 = "SELECT * FROM c##admin.project_dangky";
            }
            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }
    }
}
