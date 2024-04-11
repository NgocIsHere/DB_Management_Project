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
    public partial class userList : UserControl
    {
        private Connection connection; 
        public userList()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            fillcolumn();
            DisplayUserData();
        }
        private void fillcolumn()
        {
            int quantity1 = 0;
            string query = "SELECT * FROM all_users";
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        comboBox1.Items.Add(reader.GetName(i));
                    }
                    while (reader.Read())
                    {
                        quantity1 += 1;
                    }

                }
            }

            string query1 = "SELECT USERNAME FROM all_users"; // Thay your_table và column_name bằng tên bảng và tên cột thực tế
            OracleCommand command1 = new OracleCommand(query1, connection.connection);

            // Sử dụng SqlDataReader để đọc dữ liệu từ truy vấn
            OracleDataReader reader1 = command1.ExecuteReader();

            // Xóa dữ liệu cũ khỏi ComboBox trước khi điền dữ liệu mới
            comboBox2.Items.Clear();

            // Điền dữ liệu từ cột vào ComboBox
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1["USERNAME"].ToString()); // Thay column_name bằng tên cột bạn muốn điền vào ComboBox
            }

        }

        private void DisplayUserData()
        {
            int quantity1 = 0;
            string query = "SELECT * FROM all_users";
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
            label1.Text = "Danh sách user: " + quantity1;
            OracleDataAdapter adapter = new OracleDataAdapter(query, connection.connection);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            int quantity = 0;
            string query = "SELECT * FROM all_users WHERE " + comboBox1.Text + " LIKE '%" + textBox1.Text + "%'";
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
         
                    while (reader.Read())
                    {
                        quantity += 1;
                    }
                    label1.Text = "Danh sách user: " + quantity;
                    OracleDataAdapter adapter = new OracleDataAdapter(query, connection.connection);
                    System.Data.DataTable table = new System.Data.DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 0 && textBox1.Text.Length>0)
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Chọn và điền thông tin user tìm kiếm");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            textBox1.Text = null;
            DisplayUserData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length > 0)
            {
            }
        }
    }
}
