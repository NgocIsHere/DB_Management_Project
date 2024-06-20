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
        string admin = "ADMIN_OLS";
        public khmo()
        {
            InitializeComponent();
            config();
            load_data();

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

        private void load_data()
        {
            //string query = $"select * from {admin}.PROJECT_DONVI";
            //connection.connect();
            //try
            //{
            //    using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            //    {
            //        OracleDataReader dr = cmd.ExecuteReader();
            //        DataTable data = new DataTable();
            //        data.Load(dr);
            //        donvi_dataGridView.DataSource = data;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("xem đơn vị : " + ex.Message);
            //}
            DataSource ds = new DataSource();
            List<string> viewselects = ds.getAllObject("SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE" +
                " LIKE 'PROJECT_U_%' AND PRIVILEGE = 'SELECT' AND TABLE_NAME NOT LIKE 'PROJECT_U_%'" +
                " AND TABLE_NAME LIKE '%DONVI'", "TABLE_NAME");
            if (viewselects.Count == 0)
            {
                viewselects = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS " +
                    "WHERE TABLE_NAME LIKE '%_KHMO%' AND PRIVILEGE = 'SELECT'", "TABLE_NAME");
            }
            string query = "";
            for (int i = 0; i < viewselects.Count; i++)
            {
                query += $"SELECT* FROM {admin}." + viewselects[i];
                if (i != viewselects.Count - 1)
                {
                    query += " UNION ";
                }
            }
            Debug.WriteLine(query);
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(dr);
                    khmo_dataGridView.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("load data KHMO thất bại: " + ex.Message);
            }
            finally { connection.disconnect(); }
            //finally { connection.disconnect(); }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string mahp = textBox.Text;
            string hk = textBox2.Text;
            string nam = textBox3.Text;
            string mact = textBox4.Text;

            string sql = $"insert into {admin}.PROJECT_KHMO values('{mahp}', {hk}, {nam}, '{mact}')";
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


            DataSource ds = new DataSource();
            List<string> table_names = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                " WHERE (TABLE_NAME LIKE '%_DONVI%') " +
                "AND PRIVILEGE = 'UPDATE'", "TABLE_NAME");
            List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                " WHERE TABLE_NAME LIKE '%_DONVI%' " +
                "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
            List<string> column = new List<string>();
            bool all = columns.Contains("");
            if (columns.Contains("MAHP") || all) column.Add(" MAHP = '" + mahp + "' ");
            if (columns.Contains("HK") || all) column.Add("HK = " + hk + " ");
            if (columns.Contains("NAM") || all) column.Add("NAM = " + nam + " ");
            if (columns.Contains("MACT") || all) column.Add("MACT = '" + mact + "' ");

            string setclause = "SET ";
            for (int i = 0; i < column.Count; i++)
            {
                setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
            }


            string sql = $"UPDATE {admin}.{table_names[0]} " + setclause + $" WHERE MAHP = '{mahp}'" +
                $" AND HK = {hk} AND NAM = {nam} AND MACT = '{mact}' ";
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

        private void khmo_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (khmo_dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = khmo_dataGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    textBox.Text = khmo_dataGridView.Columns.Contains("MAHP") ? selectedRow.Cells["MAHP"].Value.ToString() : "";
                    textBox2.Text = khmo_dataGridView.Columns.Contains("HK") ? selectedRow.Cells["HK"].Value.ToString() : "";
                    textBox3.Text = khmo_dataGridView.Columns.Contains("NAM") ? selectedRow.Cells["NAM"].Value.ToString() : "";
                    textBox4.Text = khmo_dataGridView.Columns.Contains("MACT") ? selectedRow.Cells["MACT"].Value.ToString() : "";

                    DataSource ds = new DataSource();
                    List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                       " WHERE  TABLE_NAME LIKE '%_KHMO%' " +
                       "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                    bool all = columns.Contains("");
                    textBox.Enabled = columns.Contains("MAHP") || all;
                    textBox2.Enabled = columns.Contains("HK") || all;
                    textBox3.Enabled = columns.Contains("NAM") || all;
                    textBox4.Enabled = columns.Contains("MACT") || all;

                }
            }
        }
    }
}
