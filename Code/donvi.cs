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
            string query = "select * from C##ADMIN.PROJECT_DONVI";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                donvi_dataGridView.DataSource = data;
            }
        }

        private void loadmadonvi()
        {
            string query = "select MADV from C##ADMIN.PROJECT_DONVI";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   donvis.Add(dr.GetString(0));
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  madv = textBox1.Text;
            string tendv = textBox2.Text;
            string trdv = textBox3.Text;

            string sql = "insert into C##ADMIN.PROJECT_DONVI values(:madv, :tendv, :trdv)";
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.Parameters.Add("madv", OracleDbType.Varchar2).Value = madv;
                    cmd.Parameters.Add("tendv", OracleDbType.Varchar2).Value = tendv;
                    cmd.Parameters.Add("trdv", OracleDbType.Varchar2).Value = trdv;
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

            string sql = $"update C##ADMIN.PROJECT_DONVI SET TENDV = '{tendv}', TRGDV = {trdv} WHERE MADV = '{madv}'";

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
