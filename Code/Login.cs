using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class Login : Form
    {
        private Connection connection;
        public Login()
        {
            InitializeComponent();
        }

        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.ToString();
            string password = textBoxPassword.Text.ToString();
            if(username != null && password != null) {
                Config.username = username;
                Config.password = password;
            }
            connection = new Connection();
            if (connection.connect() != "complete") {
                MessageBox.Show("Thông tin đăng nhập không đúng!");
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công!");
            }
            string sql = "SELECT granted_role FROM user_role_privs";
            string roleSV = "C##P_SINHVIEN";
            string roleDBA = "DBA";
            string role = null;
            using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == roleSV)
                        {
                            role = "SINHVIEN";
                            break;
                        }
                        else if (reader.GetString(0) == roleDBA)
                        {
                            role = "DBA";
                        }
                        else
                        {
                            role = "NHANVIEN";
                        }
                    }
/*                    MessageBox.Show("Bạn đã đăng nhập với vai trò: " +role);
*/                    this.Hide();
                    if(role != null) {
                        if(role == "DBA")
                        {
                            Home dba_home = new Home();
                            dba_home.Show();
                        }
                        else if(role == "SINHVIEN")
                        {
                            HomeSV sv_home = new HomeSV();
                            sv_home.Show();
                        }
                    }
                }
            }
            
    
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
