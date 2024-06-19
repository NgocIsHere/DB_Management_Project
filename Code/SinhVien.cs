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
    public partial class SinhVien : UserControl
    {
        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
        public SinhVien()
        {
            InitializeComponent();
            load_data();
            config();
            loadMaCT();
            loadMaNganh();
        }

        private void config()
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeColumnHeadersHeight();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 14, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Aqua;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dataGridView1.BackgroundColor = Color.FromArgb(0, 0, 64);
        }

        private void loadMaCT()
        {
            mact_comboBox.Items.Add("CQ");
            mact_comboBox.Items.Add("CTTT");
            mact_comboBox.Items.Add("CLC");
            mact_comboBox.Items.Add("VP");
        }
        private void loadMaNganh()
        {
            //string query = $"SELECT MADV FROM {admin}.PROJECT_DONVI";
            //connection.connect();
            //try
            //{
            //    using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            //    {
            //        OracleDataReader dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            manganh_comboBox.Items.Add(dr["MADV"].ToString());
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("bang sinh vien load manganh thất bại: " + ex.Message);  
            //}
            //finally { connection.disconnect(); }   
        }
        private void load_data()
        {
            //string query = $"select * from {admin}.PROJECT_SINHVIEN";
            //connection.connect();
            ///*using (OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", connection.connection))
            //{
            //    cmd.ExecuteNonQuery();
            //}*/
            //try
            //{
            //    using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            //    {
            //        OracleDataReader dr = cmd.ExecuteReader();
            //        DataTable data = new DataTable();
            //        data.Load(dr);
            //        dataGridView1.DataSource = data;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("bang sinh vien load manganh thất bại: " + ex.Message);
            //}
            //finally { connection.disconnect(); }
            DataSource ds = new DataSource();
            List<string> viewselects = ds.getAllObject("SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE" +
                " LIKE 'PROJECT_U_%' AND PRIVILEGE = 'SELECT' AND TABLE_NAME NOT LIKE 'PROJECT_U_%'" +
                " AND TABLE_NAME LIKE '%SINHVIEN'", "TABLE_NAME");
            if (viewselects.Count == 0)
            {
                viewselects = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS " +
                    "WHERE TABLE_NAME LIKE '%_SINHVIEN%' AND PRIVILEGE = 'SELECT'", "TABLE_NAME");
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
                    dataGridView1.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("load data nhân sự thất bại: " + ex.Message);
            }
            finally { connection.disconnect(); }

        }   

        private void InsertSV_Click(object sender, EventArgs e)
        {
            string masv = masv_textBox.Text;
            string hoten = hoten_textBox.Text;
            string phai = nam_radioButton.Checked ? "Nam" : "Nữ";
            string ngaysinh = ngaysinh_dateTimePicker.Value.ToString("yyyy-MM-dd");
            string diaChi = diachi_textBox.Text;
            string dienThoai = dt_textBox.Text;
            string mact = mact_comboBox.SelectedItem?.ToString();
            string manganh = tb_manganh.Text;
            string sotctl = stctl_textBox.Text;
            string dtbtl = dtbtl_textBox.Text;


            string sql = $"INSERT INTO {admin}.PROJECT_SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DCHI, DT, MACT, MANGANH, SOTCTL, DTBTL) " +
             "VALUES (:masv, :hoten, :phai, TO_DATE(:ngaysinh, 'yyyy-MM-dd'), :diaChi, :dienThoai, :mact, :manganh, :sotctl, :dtbtl)";

            Debug.WriteLine(sql);
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.Parameters.Add("masv", masv);
                    cmd.Parameters.Add("hoten", hoten);
                    cmd.Parameters.Add("phai", phai);
                    cmd.Parameters.Add("ngaysinh", ngaysinh);
                    cmd.Parameters.Add("diaChi", diaChi);
                    cmd.Parameters.Add("dienThoai", dienThoai);
                    cmd.Parameters.Add("mact", mact);
                    cmd.Parameters.Add("manganh", manganh);
                    cmd.Parameters.Add("sotctl", sotctl);
                    cmd.Parameters.Add("dtbtl", dtbtl);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm sinh viên thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm sinh viên thất bại: " + ex.Message);
            }
            finally
            {
                clearForm();
                connection.disconnect();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string masv = selectedRow.Cells["MASV"].Value.ToString();

                string hoten = hoten_textBox.Text;
                string phai = nam_radioButton.Checked ? "Nam" : "Nữ";
                string ngaysinh = ngaysinh_dateTimePicker.Value.ToString("yyyy-MM-dd");
                string diaChi = diachi_textBox.Text;
                string dienThoai = dt_textBox.Text;
                string mact = mact_comboBox.SelectedItem?.ToString();
                string manganh = tb_manganh.Text;
                int sotctl = int.Parse(stctl_textBox.Text);
                float dtbtl = float.Parse(dtbtl_textBox.Text);
                DataSource ds = new DataSource();
                List<string> table_names = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                    " WHERE (TABLE_NAME LIKE '%_SINHVIEN%') " +
                    "AND PRIVILEGE = 'UPDATE'", "TABLE_NAME");
                List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                    " WHERE (TABLE_NAME LIKE '%_NVCOBAN_%' OR TABLE_NAME LIKE '%_NHANSU%') " +
                    "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                List<string> column = new List<string>();
                bool all = columns.Contains("");
                if (columns.Contains("MASV") || all) column.Add(" MASV = '" + masv + "' ");
                if (columns.Contains("HOTEN") || all) column.Add("HOTEN = N'" + hoten + "' ");
                if (columns.Contains("PHAI") || all) column.Add("PHAI = N'" + phai + "' ");
                if (columns.Contains("NGSINH") || all) column.Add($"NGSINH = TO_DATE('{ngaysinh:yyyy-MM-dd}', 'yyyy-mm-dd')");
                if (columns.Contains("DT") || all) column.Add(" DT = " + dienThoai);
                if (columns.Contains("MACT") || all) column.Add(" MADV = " + mact);
                if (columns.Contains("MANGANH") || all) column.Add(" USERNAME = " + manganh);
                if (columns.Contains("SOTCTL") || all) column.Add(" SOTCTL = " + sotctl);
                if (columns.Contains("DTBTL") || all) column.Add(" DTBTL = " + dtbtl);

                string setclause = "SET ";
                for (int i = 0; i < column.Count; i++)
                {
                    setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
                }
                string sql = $"UPDATE {admin}.{table_names[0]} " + setclause + $" WHERE MASV = '{masv}'";
                connection.connect();
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("cập nhật sinh viên thành công");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật sinh viên thất bại: " + ex.Message);
                }
                finally
                {
                    clearForm();
                    connection.disconnect();
                    hoten_textBox.Enabled = nam_radioButton.Enabled = ngaysinh_dateTimePicker.Enabled = 
                    nu_radioButton.Enabled =dt_textBox.Enabled = 
                    diachi_textBox.Enabled =  mact_comboBox.Enabled = tb_manganh.Enabled = masv_textBox.Enabled =
                    stctl_textBox.Enabled = dtbtl_textBox.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.");
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string masv = selectedRow.Cells["MASV"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên có mã số {masv}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.connect();
                    OracleTransaction transaction = connection.connection.BeginTransaction();
                    try
                    {   
                        using (OracleCommand cmd = new OracleCommand($"DELETE FROM {admin}.PROJECT_SINHVIEN WHERE MASV = :masv", connection.connection))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.Add("masv", masv);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Xóa sinh viên thành công");
                        load_data();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Xóa sinh viên thất bại: " + ex.Message);
                    }
                    finally
                    {
                        clearForm();
                        connection.disconnect();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                masv_textBox.Text = dataGridView1.Columns.Contains("MASV") ? selectedRow.Cells["MASV"].Value.ToString() : "";
                hoten_textBox.Text = dataGridView1.Columns.Contains("HOTEN") ? selectedRow.Cells["HOTEN"].Value.ToString() : "";

                string phai = dataGridView1.Columns.Contains("PHAI") ? selectedRow.Cells["PHAI"].Value.ToString() : "";
                if (!phai.Equals(""))
                {
                    nam_radioButton.Checked = phai.Equals("Nam");
                    nu_radioButton.Checked = phai.Equals("Nữ");
                }

                ngaysinh_dateTimePicker.Value = dataGridView1.Columns.Contains("NGSINH") ? DateTime.Parse(selectedRow.Cells["NGSINH"].Value.ToString()) :
                    DateTime.Parse("1/1/1990");
                diachi_textBox.Text = dataGridView1.Columns.Contains("DCHI") ? selectedRow.Cells["DCHI"].Value.ToString() : "";
                dt_textBox.Text = dataGridView1.Columns.Contains("DT") ? selectedRow.Cells["DT"].Value.ToString() : "";

                mact_comboBox.Text = dataGridView1.Columns.Contains("MACT") ? selectedRow.Cells["MACT"].Value.ToString() : "";
                tb_manganh.Text = dataGridView1.Columns.Contains("MANGANH") ? selectedRow.Cells["MANGANH"].Value.ToString() : "";

                stctl_textBox.Text = dataGridView1.Columns.Contains("SOTCTL") ? selectedRow.Cells["SOTCTL"].Value.ToString() : "";
                dtbtl_textBox.Text = dataGridView1.Columns.Contains("DTBTL") ? selectedRow.Cells["DTBTL"].Value.ToString() : "";
                DataSource ds = new DataSource();
                List<string> columns = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                   " WHERE (TABLE_NAME LIKE '%_NVCOBAN_%' OR TABLE_NAME LIKE '%_NHANSU%') " +
                   "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                bool all = columns.Contains("");
                masv_textBox.Enabled = columns.Contains("MASV") || all;
                hoten_textBox.Enabled = columns.Contains("HOTEN") || all;
                nam_radioButton.Enabled = nu_radioButton.Enabled = columns.Contains("PHAI") || all;
                ngaysinh_dateTimePicker.Enabled = columns.Contains("NGSINH") || all;
                diachi_textBox.Enabled = columns.Contains("DIACHI") || all;
                dt_textBox.Enabled = columns.Contains("DT") || all;
                mact_comboBox.Enabled = columns.Contains("MACT") || all;
                tb_manganh.Enabled = columns.Contains("MANGANH") || all;
                stctl_textBox.Enabled = columns.Contains("SOTCTL") || all;
                dtbtl_textBox.Enabled = columns.Contains("DTBTL") || all;
            }
        }

        private void clearForm()
        {
            masv_textBox.Clear();
            hoten_textBox.Clear();
            diachi_textBox.Clear();
            dt_textBox.Clear();
            stctl_textBox.Clear();
            dtbtl_textBox.Clear();
            nam_radioButton.Checked = true;
            ngaysinh_dateTimePicker.Value = DateTime.Today;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}

