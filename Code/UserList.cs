using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPHONGKHAM
{
    public partial class UserList : UserControl
    {
        public string backup;
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHONGKHAM_DBConnectionString"].ConnectionString);
        public UserList(string role)
        {
            InitializeComponent();
            backup = role;
        }

        private void QuanLyBenhNhan_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "insert into BENHAN(HOTEN,NGAYSINH,DIACHI,SDT,GIOITINH) values (@HOTEN, @NGAYSINH, @DIACHI, @SDT, @GIOITINH);";
            string gender;
            if(listBoxGender.SelectedItem.ToString() == "Nam")
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            using (var cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("@HOTEN", textBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@NGAYSINH", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@DIACHI", textBox3.Text.ToString());
                cmd.Parameters.AddWithValue("@SDT", textBox4.Text.ToString());
                cmd.Parameters.AddWithValue("@GIOITINH", gender);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Đã thêm bệnh nhân!");
            con.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select ID, HOTEN, NGAYSINH, DIACHI, SDT, GIOITINH from BENHAN BN where BN.HOTEN LIKE  N'%"+ textBox1.Text.ToString()+"%'; ";
            con.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
            {
                // Create a new DataTable
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the results of the query
                adapter.Fill(dataTable);

                // Set the DataGridView's DataSource to the DataTable
                dataGridView1.DataSource = dataTable;
            }
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.ToString()!=null)
            {
                con.Open();
                string query = "SELECT ID FROM BENHAN BN WHERE BN.ID = " + textBox5.Text.ToString() + ";";
                SqlCommand command = new SqlCommand(query, con);
                object data = command.ExecuteScalar();
                if (data != null)
                {
                    this.Hide();
                    /*ChiTietBN newinterf = new ChiTietBN(textBox5.Text.ToString(), backup);
                    newinterf.Show();*/
                }
                else
                {
                    MessageBox.Show("Không có bệnh nhân có ID " + textBox5.Text.ToString());
                }
                con.Close();
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home hm = new Home(backup);
            this.Hide();
            hm.Show();
            
        }
    }
}
