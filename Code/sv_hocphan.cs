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
    public partial class sv_hocphan : UserControl
    {
        private Connection connection; 
        public sv_hocphan()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            DisplayUserData();
        }
    

        private void DisplayUserData()
        {
            string query = "SELECT DISTINCT HK FROM  c##admin.project_khmo"; // Thay your_table và column_name bằng tên bảng và tên cột thực tế
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
            string query1 = "SELECT * FROM c##admin.project_khmo kh join c##admin.project_hocphan hp on kh.mahp = hp.mahp";
            if (comboBox1.Text.ToString() == "1")
            {
                query1 = "SELECT * FROM c##admin.project_khmo kh join c##admin.project_hocphan hp on kh.mahp = hp.mahp where HK = 1";

            }
            else if (comboBox1.Text.ToString() == "2")
            {
                query1 = "SELECT * FROM c##admin.project_khmo kh join c##admin.project_hocphan hp on kh.mahp = hp.mahp where HK = 2";

            }
            else
            {
                query1 = "SELECT * FROM c##admin.project_khmo kh join c##admin.project_hocphan hp on kh.mahp = hp.mahp where HK = 3";
            }
            int quantity1 = 0;
            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
            string query2 = "SELECT * FROM c##admin.project_khmo";
           
            OracleDataAdapter adapter2 = new OracleDataAdapter(query2, connection.connection);
/*          System.Data.DataTable table2 = new System.Data.DataTable();
            adapter2.Fill(table2);

*/        }

       
        
        

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
    }
}
