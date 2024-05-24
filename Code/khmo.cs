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
using System.Windows.Forms;

namespace DB_Management
{
    public partial class khmo : UserControl
    {
        Connection connection = new Connection();

        public khmo()
        {
            InitializeComponent();
            config();
            load_data();
        }

        private void load_data()
        {
            string sql = "select * from C##ADMIN.PROJECT_KHMO";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
            {
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    khmo_dataGridView.DataSource = dataTable;
                }
            }

        }

        private void config()
        {
            khmo_dataGridView.AutoResizeColumns();
            khmo_dataGridView.AutoResizeColumnHeadersHeight();
            khmo_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            khmo_dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            khmo_dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            khmo_dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            khmo_dataGridView.DefaultCellStyle.Font = new Font("Consolas", 14, FontStyle.Regular);
            khmo_dataGridView.DefaultCellStyle.ForeColor = Color.Aqua;

            khmo_dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            khmo_dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            khmo_dataGridView.BackgroundColor = Color.FromArgb(0, 0, 64);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mahp = textBox.Text;
            string hk = textBox2.Text;
            string nam = textBox3.Text;
            string mact = textBox4.Text;

            string sql = $"insert into C##ADMIN.PROJECT_KHMO values('{mahp}', {hk}, {nam}, '{mact}')";
            Debug.WriteLine(sql);

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm khmo thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


                MessageBox.Show("Thêm khmo thất bại: " + ex.Message);
            }
            finally
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                connection.disconnect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mahp = textBox.Text;
            string hk = textBox2.Text;
            string nam = textBox3.Text;
            string mact = textBox4.Text;


            string sql = $"UPDATE C##ADMIN.PROJECT_KHMO SET HK = {hk}, NAM = {nam}, MACT = '{mact}' WHERE MAHP = '{mahp}' ";
            Debug.WriteLine(sql);

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật khmo thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
               

                MessageBox.Show("Cập nhật khmo thất bại: " + ex.Message);
            }
            finally
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
        
                connection.disconnect();
            }
        }

        private void khmo_Load(object sender, EventArgs e)
        {

        }
    }
}
