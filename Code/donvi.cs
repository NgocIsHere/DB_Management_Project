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
using System.Windows.Media.Media3D.Converters;

namespace DB_Management
{
    public partial class donvi : UserControl
    {

        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
        List<string> donvis = new List<string>();

        public donvi()
        {
            InitializeComponent();
            load_data(); 
            config();
            loadmadonvi();
        }

        private void config()
        {
            donvi_dataGridView.AutoResizeColumns();
            donvi_dataGridView.AutoResizeColumnHeadersHeight();
            donvi_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            donvi_dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            donvi_dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            donvi_dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            donvi_dataGridView.DefaultCellStyle.Font = new Font("Consolas", 14, FontStyle.Regular);
            donvi_dataGridView.DefaultCellStyle.ForeColor = Color.Aqua;
            donvi_dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            donvi_dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            donvi_dataGridView.BackgroundColor = Color.FromArgb(0, 0, 64);
        }


        private void load_data()
        {
            string query = $"select * from {admin}.PROJECT_DONVI";
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(dr);
                    donvi_dataGridView.DataSource = data;

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("xem đơn vị : " + ex.Message);
            }
            finally { connection.disconnect(); }

        }

        private void loadmadonvi()
        {
            string query = $"select MADV from {admin}.PROJECT_DONVI";
            connection.connect();

            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donvis.Add(dr.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("xem mã đơn vị : " + ex.Message);
            }
            finally { connection.disconnect(); }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  madv = textBox1.Text;
            string tendv = textBox2.Text;
            string trdv = textBox3.Text;

            string sql = $"insert into {admin}.PROJECT_DONVI values({madv}, N'{tendv}', {trdv})";
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm đơn vị thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Thêm đơn vị thất bại: "+ ex.Message);
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                connection.disconnect();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string madv = textBox1.Text;
            string tendv = textBox2.Text;
            string trdv = textBox3.Text;

            string sql = $"update {admin}.PROJECT_DONVI SET TENDV = N'{tendv}', TRGDV = {trdv} WHERE MADV = '{madv}'";

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thay đổi đơn vị thành công");
                    load_data();
                }

            }
            catch (Exception ex)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("thay đổi đơn vị thất bại: " + ex.Message);
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                connection.disconnect();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void donvi_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void donvi_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
