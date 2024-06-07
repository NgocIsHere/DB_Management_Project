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
            string query = $"SELECT MADV FROM {admin}.PROJECT_DONVI";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    manganh_comboBox.Items.Add(dr["MADV"].ToString());
                }
            }
            connection.disconnect();
        }
        private void load_data()
        {
            string query = $"select * from {admin}.PROJECT_SINHVIEN";
            connection.connect();
            /*using (OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", connection.connection))
            {
                cmd.ExecuteNonQuery();
            }*/
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                dataGridView1.DataSource = data;
            }           
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
            string manganh = manganh_comboBox.SelectedItem?.ToString();
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
                string manganh = manganh_comboBox.SelectedItem?.ToString();
                int sotctl = int.Parse(stctl_textBox.Text);
                float dtbtl = float.Parse(dtbtl_textBox.Text);

                string sql = $"UPDATE {admin}.PROJECT_SINHVIEN SET HOTEN = :hoten, PHAI = :phai, NGSINH = TO_DATE(:ngaysinh, 'yyyy-MM-dd'), DCHI = :diaChi, DT = :dienThoai, MACT = :mact, MANGANH = :manganh, SOTCTL = :sotctl, DTBTL = :dtbtl WHERE MASV = :masv";

                connection.connect();
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                    {
                        cmd.Parameters.Add("hoten", hoten);
                        cmd.Parameters.Add("phai", phai);
                        cmd.Parameters.Add("ngaysinh", ngaysinh);
                        cmd.Parameters.Add("diaChi", diaChi);
                        cmd.Parameters.Add("dienThoai", dienThoai);
                        cmd.Parameters.Add("mact", mact);
                        cmd.Parameters.Add("manganh", manganh);
                        cmd.Parameters.Add("sotctl", sotctl);
                        cmd.Parameters.Add("dtbtl", dtbtl);
                        cmd.Parameters.Add("masv", masv);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật sinh viên thành công");
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
                        using (OracleCommand cmd = new OracleCommand($"DELETE FROM {admin}.PROJECT_DANGKY WHERE MASV = :masv", connection.connection))
                        {
                            cmd.Transaction = transaction; 
                            cmd.Parameters.Add("masv", masv);
                            cmd.ExecuteNonQuery();
                        }

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
                masv_textBox.Text = selectedRow.Cells["MASV"].Value.ToString();
                hoten_textBox.Text = selectedRow.Cells["HOTEN"].Value.ToString();

                string phai = selectedRow.Cells["PHAI"].Value.ToString();
                nam_radioButton.Checked = phai == "Nam";
                nu_radioButton.Checked = phai == "Nữ";

                ngaysinh_dateTimePicker.Value = DateTime.Parse(selectedRow.Cells["NGSINH"].Value.ToString());

                diachi_textBox.Text = selectedRow.Cells["DCHI"].Value.ToString();
                dt_textBox.Text = selectedRow.Cells["DT"].Value.ToString();

                mact_comboBox.Text = selectedRow.Cells["MACT"].Value.ToString();
                manganh_comboBox.SelectedItem = selectedRow.Cells["MANGANH"].Value.ToString();

                stctl_textBox.Text = selectedRow.Cells["SOTCTL"].Value.ToString();
                dtbtl_textBox.Text = selectedRow.Cells["DTBTL"].Value.ToString();
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

