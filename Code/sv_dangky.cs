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
    public partial class sv_dangky : UserControl
    {
        private Connection connection; 
        public sv_dangky()
        {
            InitializeComponent();
            connection = new Connection(); 
            connection.connect();
            DisplayUserData();
        }
    

        private void DisplayUserData()
        {
            
            int quantity1 = 0;
            string query1 = "SELECT * FROM c##admin.project_dangky";

            OracleDataAdapter adapter1 = new OracleDataAdapter(query1, connection.connection);
            System.Data.DataTable table1 = new System.Data.DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
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
