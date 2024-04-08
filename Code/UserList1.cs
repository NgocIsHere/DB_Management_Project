using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace DB_Management
{
    public partial class UserList1 : UserControl
    {
        string host = "localhost";
        string port = "1521";
        string sid = "xe";
        string userId = "SYS";
        string password = "ngoc123";
        Connection Cnnt;
        public UserList1()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                Cnnt.connect();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
