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
    public partial class NhanSu : UserControl
    {
        Connection connection = new Connection();

        public NhanSu()
        {
            InitializeComponent();
            load_data();
            loadVaiTro();
            loadMaDV();
        }

        private void loadVaiTro()
        {
            string query = "SELECT * FROM DBA_ROLES WHERE ROLE LIKE 'C##P_%'";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    vaitro_comboBox.Items.Add(dr["ROLE"].ToString());
                }
            }
            connection.disconnect();
        }

        private void loadMaDV()
        {
            string query = "SELECT MADV FROM SYS.PROJECT_DONVI";
            connection.connect();
            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    madv_comboBox.Items.Add(dr["MADV"].ToString());
                }
            }
            connection.disconnect();
        }

        private void load_data()
        {
            string query = "select * from SYS.PROJECT_NHANSU";
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
                dataGridView1.DataSource = data;
            }
        }

        private void manv_textBox_TextChanged(object sender, EventArgs e)
        {
            string manv = manv_textBox.Text;
            if (!string.IsNullOrEmpty(manv))
            {
                username_textBox.Text = $"PROJECT_U_{manv}";
            }
            else
            {
                username_textBox.Text = "";
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            string manv = manv_textBox.Text;
            string hoten = hoten_textBox.Text;
            string phai = nam_radioButton.Checked ? "Nam" : "Nữ";
            DateTime ngaysinh = ngaysinh_dateTimePicker.Value;
            string phuCap = phucap_textBox.Text;
            string dienThoai = dt_textBox.Text;
            string vaitro = vaitro_comboBox.SelectedItem?.ToString();
            string madv = madv_comboBox.SelectedItem?.ToString();
            string username = username_textBox.Text;

            string sql = $"INSERT INTO SYS.PROJECT_NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DT, VAITRO, MADV, USERNAME) VALUES('{manv}', '{hoten}', '{phai}', TO_DATE('{ngaysinh:yyyy-MM-dd}', 'yyyy-mm-dd'), {phuCap}, '{dienThoai}', '{vaitro}', '{madv}', '{username}')";
            Debug.WriteLine(sql);

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân sự thành công");
                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm nhân sự thất bại: " + ex.Message);
            }
            finally
            {
                manv_textBox.Clear();
                hoten_textBox.Clear();
                dt_textBox.Clear();
                phucap_textBox.Clear();
                username_textBox.Clear();
                nam_radioButton.Checked = true;
                ngaysinh_dateTimePicker.Value = DateTime.Today;

                connection.disconnect();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string manv = selectedRow.Cells["MANV"].Value.ToString();
           
                string hoten = hoten_textBox.Text;
                string phai = nam_radioButton.Checked ? "Nam" : "Nữ";
                DateTime ngaysinh = ngaysinh_dateTimePicker.Value;
                string phuCap = phucap_textBox.Text;
                string dienThoai = dt_textBox.Text;
                string vaitro = vaitro_comboBox.SelectedItem?.ToString();
                string madv = madv_comboBox.SelectedItem?.ToString();
                string username = username_textBox.Text; 

                
                string sql = $"UPDATE SYS.PROJECT_NHANSU SET HOTEN = '{hoten}', PHAI = '{phai}', NGSINH = TO_DATE('{ngaysinh:yyyy-MM-dd}', 'yyyy-mm-dd'), PHUCAP = {phuCap}, DT = '{dienThoai}', VAITRO = '{vaitro}', MADV = '{madv}', USERNAME = '{username}' WHERE MANV = '{manv}'";

                connection.connect();
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật nhân sự thành công");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật nhân sự thất bại: " + ex.Message);
                }
                finally
                {
                    manv_textBox.Clear();
                    hoten_textBox.Clear();
                    dt_textBox.Clear();
                    phucap_textBox.Clear();
                    username_textBox.Clear();
                    nam_radioButton.Checked = true;
                    ngaysinh_dateTimePicker.Value = DateTime.Today;

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
                string manv = selectedRow.Cells["MANV"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = $"DELETE FROM SYS.PROJECT_NHANSU WHERE MANV = '{manv}'";

                    connection.connect();
                    try
                    {
                        using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa nhân sự thành công");
                            load_data();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa nhân sự thất bại: " + ex.Message);
                    }
                    finally
                    {
                        manv_textBox.Clear();
                        hoten_textBox.Clear();
                        dt_textBox.Clear();
                        phucap_textBox.Clear();
                        username_textBox.Clear();
                        nam_radioButton.Checked = true;
                        ngaysinh_dateTimePicker.Value = DateTime.Today;

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
                manv_textBox.Text = selectedRow.Cells["MANV"].Value.ToString();
                hoten_textBox.Text = selectedRow.Cells["HOTEN"].Value.ToString();
                string phai = selectedRow.Cells["PHAI"].Value.ToString();
                nam_radioButton.Checked = phai == "Nam";
                nu_radioButton.Checked = phai == "Nữ";
                ngaysinh_dateTimePicker.Value = DateTime.Parse(selectedRow.Cells["NGSINH"].Value.ToString());
                phucap_textBox.Text = selectedRow.Cells["PHUCAP"].Value.ToString();
                dt_textBox.Text = selectedRow.Cells["DT"].Value.ToString();
                vaitro_comboBox.SelectedItem = selectedRow.Cells["VAITRO"].Value.ToString();
                madv_comboBox.SelectedItem = selectedRow.Cells["MADV"].Value.ToString();
                username_textBox.Text = selectedRow.Cells["USERNAME"].Value.ToString();
            }
        }

        private void NhanSu_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hoten_label_Click(object sender, EventArgs e)
        {

        }

        private void phucap_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

