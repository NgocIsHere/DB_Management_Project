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
    public partial class hocphan : UserControl
    {
        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
        public hocphan()
        {
            InitializeComponent();
            config();
            load_data();
        }

        private void load_data()
        {
            //string sql = $"select * from {admin}.PROJECT_HOCPHAN";
            //connection.connect();
            //try
            //{
            //    using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
            //    {
            //        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
            //        {
            //            DataTable dataTable = new DataTable();
            //            adapter.Fill(dataTable);
            //            hocphan_dataGridView.DataSource = dataTable;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("load thất bại: " + ex.Message);

            //}
            //finally { connection.disconnect(); }
            DataSource ds = new DataSource();
            List<string> viewselects = ds.getAllObject("SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE" +
                " LIKE 'PROJECT_U_%' AND PRIVILEGE = 'SELECT' AND TABLE_NAME NOT LIKE 'PROJECT_U_%'" +
                " AND TABLE_NAME LIKE '%HOCPHAN'", "TABLE_NAME");
            if (viewselects.Count == 0)
            {
                viewselects = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS " +
                    "WHERE TABLE_NAME LIKE '%_HOCPHAN%' AND PRIVILEGE = 'SELECT'", "TABLE_NAME");
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
                    hocphan_dataGridView.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("load data nhân sự thất bại: " + ex.Message);
            }
            finally { connection.disconnect(); }

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


            string sql = $"insert into {admin}.PROJECT_HOCPHAN values('{mahp}', N'{tenhp}', {sotc}, {sotietlt}, {sotietth}, {sosvtd}, '{madv}')";
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
            DataSource ds = new DataSource();
            List<string> table_names = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                " WHERE (TABLE_NAME LIKE '%_HOCPHAN%') " +
                "AND PRIVILEGE = 'UPDATE'", "TABLE_NAME");
            List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                " WHERE TABLE_NAME LIKE '%_HOCPHAN%' " +
                "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
            List<string> column = new List<string>();
            bool all = columns.Contains("");
            if (columns.Contains("MAHP") || all) column.Add(" MAHP = '" + mahp + "' ");
            if (columns.Contains("TENHP") || all) column.Add("TENHP = N'" + tenhp + "' ");
            if (columns.Contains("SOTC") || all) column.Add("SOTC = " + sotc + " ");
            if (columns.Contains("SSLT") || all) column.Add("SSLT = " + sotietlt + " ");
            if (columns.Contains("STTH") || all) column.Add("STTH = " + sotietth + " ");
            if (columns.Contains("SOSVTD") || all) column.Add("SOSVTD = " + sosvtd + " ");
            if (columns.Contains("MADV") || all) column.Add("MADV = '" + madv + "' ");
            string setclause = "SET ";
            for (int i = 0; i < column.Count; i++)
            {
                setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
            }
            string sql = $"UPDATE {admin}.{table_names[0]} " + setclause + $" WHERE MAHP = '{mahp}'";
            connection.connect();
            //string sql = $"UPDATE {admin}.PROJECT_HOCPHAN SET TENHP = N'{tenhp}', SOTC = {sotc}, SSLT = {sotietlt}, STTH = {sotietth}, SOSVTD = {sosvtd}, MADV = '{madv}' WHERE MAHP = '{mahp}' ";
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

        private void hocphan_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (hocphan_dataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = hocphan_dataGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    textBox.Text = hocphan_dataGridView.Columns.Contains("MAHP") ? selectedRow.Cells["MAHP"].Value.ToString():"";
                    textBox2.Text = hocphan_dataGridView.Columns.Contains("TENHP") ? selectedRow.Cells["TENHP"].Value.ToString():"";
                    textBox3.Text = hocphan_dataGridView.Columns.Contains("SOTC") ? selectedRow.Cells["SOTC"].Value.ToString():"";
                    textBox4.Text = hocphan_dataGridView.Columns.Contains("SSLT") ? selectedRow.Cells["SSLT"].Value.ToString():"";
                    textBox5.Text = hocphan_dataGridView.Columns.Contains("STTH") ? selectedRow.Cells["STTH"].Value.ToString():"";
                    textBox6.Text = hocphan_dataGridView.Columns.Contains("SOSVTD") ? selectedRow.Cells["SOSVTD"].Value.ToString():"";
                    textBox7.Text = hocphan_dataGridView.Columns.Contains("MADV") ? selectedRow.Cells["MADV"].Value.ToString():"";

                    DataSource ds = new DataSource();
                    List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                       " WHERE  TABLE_NAME LIKE '%_HOCPHAN%' " +
                       "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                    bool all = columns.Contains("");
                    textBox.Enabled = columns.Contains("MAHP") || all;
                    textBox2.Enabled = columns.Contains("TENHP") || all;
                    textBox3.Enabled = columns.Contains("SOTC") || all;
                    textBox4.Enabled = columns.Contains("SSLT") || all;
                    textBox5.Enabled = columns.Contains("STTH") || all;
                    textBox6.Enabled = columns.Contains("SOSVTD") || all;
                    textBox7.Enabled = columns.Contains("MADV") || all;
                }


            }
        }
    }
}
