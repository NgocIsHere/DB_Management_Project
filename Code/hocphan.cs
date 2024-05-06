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
    public partial class hocphan : Form
    {
        Connection connection = new Connection();

        public hocphan()
        {
            InitializeComponent();
            config();
            load_data();
        }

        private void load_data()
        {
            string sql = "select * C##ADMIN.from PROJECT_HOCPHAN";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
            {
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    hocphan_dataGridView.DataSource = dataTable;
                }
            }

        }
        private void config()
        {
            hocphan_dataGridView.AutoResizeColumns();
            hocphan_dataGridView.AutoResizeColumnHeadersHeight();
            hocphan_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            hocphan_dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            hocphan_dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            hocphan_dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            hocphan_dataGridView.DefaultCellStyle.Font = new Font("Consolas", 14, FontStyle.Regular);
            hocphan_dataGridView.DefaultCellStyle.ForeColor = Color.Aqua;

            hocphan_dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            hocphan_dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            hocphan_dataGridView.BackgroundColor = Color.FromArgb(0, 0, 64);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string mahp = textBox.Text;
            string tenhp = textBox2.Text;
            string sotc = textBox3.Text;
            string sotietlt = textBox4.Text;
            string sotietth = textBox5.Text;
            string sosvtd = textBox6.Text;
            string madv = textBox7.Text;


            string sql = $"insert into C##ADMIN.PROJECT_HOCPHAN values('{mahp}', '{tenhp}', {sotc}, {sotietlt}, {sotietth}, {sosvtd}, '{madv}')";
            Debug.WriteLine(sql);

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm học phần thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                MessageBox.Show("Thêm học phần thất bại: " + ex.Message);
            }
            finally
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                connection.disconnect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mahp = textBox.Text;
            string tenhp = textBox2.Text;
            string sotc = textBox3.Text;
            string sotietlt = textBox4.Text;
            string sotietth = textBox5.Text;
            string sosvtd = textBox6.Text;
            string madv = textBox7.Text;


            string sql = $"UPDATE C##ADMIN.PROJECT_HOCPHAN SET TENHP = '{tenhp}', SOTC = {sotc}, SSLT = {sotietlt}, STTH = {sotietth}, SOSVTD = {sosvtd}, MADV = '{madv}' WHERE MAHP = '{mahp}' ";
            Debug.WriteLine(sql);

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật học phần thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                MessageBox.Show("Cập nhật học phần thất bại: " + ex.Message);
            }
            finally
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                connection.disconnect();
            }
        }




    }
}
