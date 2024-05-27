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
        public static string role;
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
            if (!connection.connect().Equals("complete")) {
                MessageBox.Show("Thông tin đăng nhập không đúng!");
            }
            else
            {
                // Do nothing
                string sql = "SELECT granted_role FROM user_role_privs";
                string roleSV = "C##P_SINHVIEN";
                string roleDBA = "DBA";
                role = null;
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0).Equals(roleSV))
                            {
                                role = "SINHVIEN";
                                break;
                            }
                            else if (reader.GetString(0).Equals(roleDBA))
                            {
                                role = "DBA";
                                break;

                            }
                            else
                            {
                                role = "NHANVIEN";
                                break;

                            }
                        }
                        /*                    MessageBox.Show("Bạn đã đăng nhập với vai trò: " +role);
                        */
                        this.Close();
                    }
                }
            }
            
    
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
