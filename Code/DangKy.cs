using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class DangKy : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHONGKHAM_DBConnectionString"].ConnectionString);
        public string role;
        public DateTime selectedDateTime;
        public DangKy()
        {
            InitializeComponent();
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;

            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet.NHASI' table. You can move, or remove it, as needed.

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            selectedDateTime = dateTimePicker1.Value;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                role = "NS";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                role = "QTV";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                role = "NV";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null && textBox3 != null && textBox4 != null && (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked) && listBoxGender.SelectedIndex != -1)
            {
                string sql = null;
                string number = null;
                if (textBox4.Text.ToString() != textBox5.Text.ToString())
                {
                    MessageBox.Show("2 lần nhập mật khẩu không khớp với nhau, vui lòng nhập lại");
                }
                else
                {
                    con.Open();
                    if (role == "NV")
                    {
                        sql = "insert into [NHANVIEN] values (@ID, @HOTEN, @NGAYSINH, @DIACHI, @SDT, @GIOITINH, @MATKHAU);";
                        number = "select count(*) from NHANVIEN";
                    }
                    else if (role == "NS")
                    {
                        sql = "insert into [NHASI] values (@ID, @HOTEN, @NGAYSINH, @DIACHI, @SDT, @GIOITINH, @MATKHAU);";
                        number = "select count(*) from NHASI";
                    }
                    else if (role == "QTV")
                    {
                        sql = "insert into [QTV] values (@ID, @HOTEN, @NGAYSINH, @DIACHI, @SDT, @GIOITINH, @MATKHAU);";
                        number = "select count(*) from QTV";
                    }
                    if (sql != null && number != null)
                    {
                        
                        SqlCommand commandCount = new SqlCommand(number, con);
                        string gender;
                        if (listBoxGender.SelectedItem.ToString() == "Nam")
                        {
                            gender = "Male";
                        }
                        else
                        {
                            gender = "Female";
                        }
                        int count = (int)commandCount.ExecuteScalar() + 1;
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@ID", role + count.ToString("D6"));
                            cmd.Parameters.AddWithValue("@HOTEN", textBox1.Text.ToString());
                            cmd.Parameters.AddWithValue("@NGAYSINH", selectedDateTime.ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@DIACHI", textBox2.Text.ToString());
                            cmd.Parameters.AddWithValue("@SDT", textBox3.Text.ToString());
                            cmd.Parameters.AddWithValue("@GIOITINH", gender);
                            cmd.Parameters.AddWithValue("@MATKHAU", textBox4.Text.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Tài khoản tạo thành công, vui lòng nhớ ID của bạn để đăng nhập: "+ role + count.ToString("D6"));
                        con.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap strt = new DangNhap();
            strt.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
