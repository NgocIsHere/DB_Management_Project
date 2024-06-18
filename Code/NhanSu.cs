using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
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
        DataSource DS = new DataSource();
        string admin = "ADMIN_OLS";
        bool isTruongkhoa = false;

        public NhanSu()
        {
            InitializeComponent();
            config();
            if (DS.getAllObject("SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE 'P%'", "ROLE").Contains("P_TRUONGKHOA"))
            {
                isTruongkhoa = true;
            }
            else
            {
              
            }  
            load_data();    
            loadVaiTro();
            loadMaDV();
            
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

        private void loadVaiTro()
        {
            //string query = "SELECT * FROM DBA_ROLES WHERE ROLE LIKE 'P_%'";
  /*          string query = "SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE 'P%'";

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        vaitro_comboBox.Items.Add(dr["ROLE"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("load role thất bại: " + ex.Message);

            }
            finally { connection.disconnect(); }*/


            vaitro_comboBox.Items.Add("P_NVCOBAN");
            vaitro_comboBox.Items.Add("P_GIANGVIEN");
            vaitro_comboBox.Items.Add("P_GIAOVU");
            vaitro_comboBox.Items.Add("P_TRUONGDONVI");


        }

        private void loadMaDV()
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
            //            madv_comboBox.Items.Add(dr["MADV"].ToString());
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("load madv thất bại: " + ex.Message);
            //}
            //finally { connection.disconnect(); }



        }

        private void load_data()
        {
            //string query = "";
            //if (isTruongkhoa)
            //{
            //    query = $"select * from {admin}.PROJECT_NHANSU";
            //}
            //else
            //{
            //    query = $"select * from {admin}.PROJECT_NVCOBAN_XEMTHONGTINCANHAN";
            //}
            //connection.connect();
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
            //    //MessageBox.Show("load data nhân sự thất bại: " + ex.Message);
            //}
            //finally { connection.disconnect(); }
            DataSource ds = new DataSource();
            List<string> viewselects = ds.getAllObject("SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE" +
                " LIKE 'PROJECT_U_%' AND PRIVILEGE = 'SELECT' AND TABLE_NAME NOT LIKE 'PROJECT_U_%'", "TABLE_NAME");
            if (viewselects.Count == 0)
            {
                viewselects = ds.getAllObject("SELECT * FROM ROLE_TAB_PRIVS WHERE (TABLE_NAME LIKE '%_NVCOBAN_%' " +
                    "OR TABLE_NAME LIKE '%_NHANSU%') AND PRIVILEGE = 'SELECT'", "TABLE_NAME");
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
            string madv = tb_madv.Text;
            string username = username_textBox.Text;

            string sql = $"INSERT INTO {admin}.PROJECT_NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DT, VAITRO, MADV, USERNAME) VALUES('{manv}', '{hoten}', '{phai}', TO_DATE('{ngaysinh:yyyy-MM-dd}', 'yyyy-mm-dd'), {phuCap}, '{dienThoai}', '{vaitro}', '{madv}', '{username}')";
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
                string madv = tb_madv.Text;
                string username = username_textBox.Text;
                string sql = "";

                List<string> table_names = DS.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                    " WHERE (TABLE_NAME LIKE '%_NVCOBAN_%' OR TABLE_NAME LIKE '%_NHANSU%') " +
                    "AND PRIVILEGE = 'UPDATE'", "TABLE_NAME");
                List<string> columns = DS.getAllObject("SELECT * FROM ROLE_TAB_PRIVS" +
                    " WHERE (TABLE_NAME LIKE '%_NVCOBAN_%' OR TABLE_NAME LIKE '%_NHANSU%') " +
                    "AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                List<string> column = new List<string>();
                if (columns.Contains("MANV")) column.Add(" MANV = '" + manv + "' ");
                if (columns.Contains("HOTEN")) column.Add("HOTEN = N'" + hoten + "' ");
                if (columns.Contains("PHAI")) column.Add("PHAI = N'" + phai + "' ");
                if (columns.Contains("NGSINH")) column.Add($"NGSINH = TO_DATE('{ngaysinh:yyyy-MM-dd}', 'yyyy-mm-dd')");
                if (columns.Contains("PHUCAP")) column.Add(" PHUCAP = " + phuCap + "' ");
                if (columns.Contains("DT")) column.Add(" DT = " + dienThoai);
                if (columns.Contains("VAITRO")) column.Add(" VAITRO = " + vaitro);
                if (columns.Contains("MADV")) column.Add(" MADV = " + madv);
                if (columns.Contains("USERNAME")) column.Add(" USERNAME = " + username);
                string setclause = "SET ";
                for (int i = 0; i < column.Count; i++)
                {
                    setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
                }
                if (!isTruongkhoa)
                {
                    sql = $"UPDATE {admin}.{table_names[0]} "+setclause+ $" WHERE MANV = '{manv}'";
                }
                else
                {
                    sql = $"UPDATE {admin}.PROJECT_NHANSU SET HOTEN = '{hoten}', PHAI = '{phai}', NGSINH = TO_DATE('{ngaysinh:yyyy-MM-dd}', 'yyyy-mm-dd'), PHUCAP = {phuCap}, DT = '{dienThoai}', VAITRO = '{vaitro}', MADV = '{madv}', USERNAME = '{username}' WHERE MANV = '{manv}'";
                }
                connection.connect();
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("cập nhật nhân sự thành công");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(sql);
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
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string manv = selectedRow.Cells["MANV"].Value.ToString();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = $"DELETE FROM {admin}.PROJECT_NHANSU WHERE MANV = '{manv}'";

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
            catch(Exception ex)
            {
                MessageBox.Show("Khong doc duoc ma nv de xoa!");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                
                manv_textBox.Text = dataGridView1.Columns.Contains("MANV") ? selectedRow.Cells["MANV"].Value.ToString():"";
                hoten_textBox.Text = dataGridView1.Columns.Contains("HOTEN") ? selectedRow.Cells["HOTEN"].Value.ToString() : "";
                string phai = dataGridView1.Columns.Contains("PHAI") ? selectedRow.Cells["PHAI"].Value.ToString() : "";
                if (!phai.Equals(""))
                {
                    nam_radioButton.Checked = phai.Equals("Nam");
                    nu_radioButton.Checked = phai.Equals("Nữ");
                }

                ngaysinh_dateTimePicker.Value = dataGridView1.Columns.Contains("NGSINH") ? DateTime.Parse(selectedRow.Cells["NGSINH"].Value.ToString()):
                    DateTime.Parse("1/1/1990");
                phucap_textBox.Text = dataGridView1.Columns.Contains("PHUCAP") ? selectedRow.Cells["PHUCAP"].Value.ToString() : "";
                dt_textBox.Text = dataGridView1.Columns.Contains("DT") ? selectedRow.Cells["DT"].Value.ToString() : "";
                vaitro_comboBox.SelectedItem = dataGridView1.Columns.Contains("VAITRO") ? selectedRow.Cells["VAITRO"].Value.ToString() : ""; ;
                tb_madv.Text = dataGridView1.Columns.Contains("MADV") ? selectedRow.Cells["MADV"].Value.ToString() : ""; ;
                username_textBox.Text = dataGridView1.Columns.Contains("USERNAME") ? selectedRow.Cells["USERNAME"].Value.ToString() : "";
                Debug.WriteLine(selectedRow.Cells["MADV"].Value.ToString());
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

