using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QLPHONGKHAM;

namespace QLPHONGKHAM
{
    public partial class DangNhap : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHONGKHAM_DBConnectionString"].ConnectionString);
        public DangNhap()
        {
            InitializeComponent();
        }

        private void userId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlCommand cmd = new SqlCommand("SP_DangNhap", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (userId.Text.ToString() != null && password.Text.ToString() != null)
                {
                    cmd.Parameters.AddWithValue("@ID", userId.Text.ToString());
                    cmd.Parameters.AddWithValue("@Password", password.Text.ToString());
                    cmd.Parameters.Add("@Home", SqlDbType.NChar, 3).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string home = cmd.Parameters["@Home"].Value.ToString();
                    string message = cmd.Parameters["@Message"].Value.ToString();
                    con.Close();
                    MessageBox.Show(message);
                    MessageBox.Show(home);
                    if (home.ToLower() == "nv "|| home.ToLower() == "ns "||  home.ToLower() == "qtv")
                    {
                        Home hm = new Home(home.ToLower());
                        this.Hide();
                        hm.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
            }

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy neef = new DangKy();
            neef.Show();
        }
    }
}
