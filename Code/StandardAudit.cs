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
    public partial class StandardAudit : UserControl
    {
        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
        List<string> donvis = new List<string>();

        public StandardAudit()
        {
            InitializeComponent();
            loadAudit();
            config();
        }

        private void config()
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeColumnHeadersHeight();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 12, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Aqua;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dataGridView1.BackgroundColor = Color.FromArgb(0, 0, 64);
        }

        private void loadAudit()
        {
            string query = $"SELECT USERNAME, OBJ_NAME, ACTION_NAME, RETURNCODE, TIMESTAMP FROM DBA_AUDIT_TRAIL " +
                $" WHERE USERNAME != 'ADMIN_OLS'  ORDER BY TIMESTAMP DESC";
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(dr);
                    dataGridView1.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("xem đơn vị : " + ex.Message);
            }
            finally { connection.disconnect(); }
        }

        private void StandardAudit_Load(object sender, EventArgs e)
        {

        }
    }
}
