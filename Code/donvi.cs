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
using System.Windows.Shapes;

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
                    "WHERE TABLE_NAME LIKE '%_DONVI%' AND TABLE_NAME NOT LIKE '%TRUONGDONVI%' AND PRIVILEGE = 'SELECT'", "TABLE_NAME");
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
                    donvi_dataGridView.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("load data nhân sự thất bại: " + ex.Message);
            }
            finally { connection.disconnect(); }
            //finally { connection.disconnect(); }

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

            string sql = $"insert into {admin}.PROJECT_DONVI values('{madv}', N'{tendv}', '{trdv}')";
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
                MessageBox.Show("Thêm đơn vị thất bại: "+ ex.Message+sql);
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

            DataSource ds = new DataSource();
            List<string> table_names = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                " WHERE (TABLE_NAME LIKE '%_DONVI%') " +
                "AND PRIVILEGE = 'UPDATE'", "TABLE_NAME");
            List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                " WHERE TABLE_NAME LIKE '%_DONVI%' " +
                "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
            List<string> column = new List<string>();
            bool all = columns.Contains("");
            if (columns.Contains("MADV") || all) column.Add(" MADV = '" + madv + "' ");
            if (columns.Contains("TENDV") || all) column.Add("TENDV = N'" + tendv + "' ");
            if (columns.Contains("TRGDV") || all) column.Add("TRGDV = N'" + trdv + "' ");
            string setclause = "SET ";
            for (int i = 0; i < column.Count; i++)
            {
                setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
            }

            try
            {
                string sql = $"UPDATE {admin}.{table_names[0]} " + setclause + $" WHERE MADV = '{madv}'";
                Debug.WriteLine(sql);

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
                    MessageBox.Show("thay đổi đơn vị thất bại: " + ex.Message);
                }
                finally
                {
                    textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    connection.disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("thay đổi đơn vị thất bại: " + "insufficient privilege");
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

        private void donvi_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (donvi_dataGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = donvi_dataGridView.SelectedRows[0]; 
                if (selectedRow != null)
                {
                    textBox1.Text =donvi_dataGridView.Columns.Contains("MADV")? selectedRow.Cells["MADV"].Value.ToString():"";
                    textBox2.Text = donvi_dataGridView.Columns.Contains("TENDV") ? selectedRow.Cells["TENDV"].Value.ToString():"";
                    textBox3.Text = donvi_dataGridView.Columns.Contains("TRGDV") ? selectedRow.Cells["TRGDV"].Value.ToString():"";

                    DataSource ds = new DataSource();
                    List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                       " WHERE  TABLE_NAME LIKE '%_DONVI%' " + " AND TABLE_NAME NOT LIKE '%TRUONGDONVI%' " +
                       "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                    bool all = columns.Contains("");
                    textBox1.Enabled = columns.Contains("MADV") || all;
                    textBox2.Enabled = columns.Contains("TENDV") || all;
                    textBox3.Enabled = columns.Contains("TRGDV") || all;
                }
            }
        }
    }
}
