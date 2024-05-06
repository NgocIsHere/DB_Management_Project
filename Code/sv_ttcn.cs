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
    public partial class sv_ttcn : UserControl
    {
        private Connection connection; 
        public sv_ttcn()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            DisplayUserData();
        }
    

        private void DisplayUserData()
        {
            int quantity1 = 0;
            string query = "SELECT * FROM c##admin.project_sinhvien";
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
            OracleDataAdapter adapter = new OracleDataAdapter(query, connection.connection);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

       
        
        

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
