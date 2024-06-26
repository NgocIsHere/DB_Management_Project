using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class history_recover : UserControl
    {
        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
        public history_recover()
        {
            InitializeComponent();
            load_data();
        }
        private void load_data()
        {
            try
            {

                string query = "SELECT COMMAND_ID, OPERATION, STATUS FROM V_$RMAN_STATUS WHERE OPERATION like '%RECOVER%'";
                connection.connect();
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                }
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                    {
                        OracleDataReader dr = cmd.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(dr);
                        dataGridViewHistory.DataSource = data;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("load thất bại: " + ex.Message);
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show("Oracle Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
