using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class Login : Form
    {
        private Connection connection;
        public static string role;
        public static bool exit = false;
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
                string sql = "SELECT granted_role FROM user_role_privs ORDER BY granted_role DESC";
                string roleSV = "P_SINHVIEN";
                string roleDBA = "DBA";
                role = null;
                List<string> roles = new List<string>();
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader.GetString(0));
                        }
                        /*                    MessageBox.Show("Bạn đã đăng nhập với vai trò: " +role);
                        */
                        
                        if (roles.Equals(roleDBA))
                        {
                            role = roleDBA;
                        }
                        else if(roles.Contains(roleSV))
                        {
                            role = "SINHVIEN";
                        }   
                        else if (username.ToLower().Equals("sys") )
                        {
                            role = "SYSDBA";
                        }
                        else
                        {
                            role = "NHANVIEN";
                        }


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
