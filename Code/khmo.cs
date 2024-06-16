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

            initializeLV();
        }

        private void initializeLV()
        {            
            lv_khmo.View = View.Details;
            int size = 70;
            lv_khmo.Columns.Add("MAHP").Width = size;
            lv_khmo.Columns.Add("HK").Width = size;
            lv_khmo.Columns.Add("NAM").Width = size;
            lv_khmo.Columns.Add("MACT").Width = size;

            loadLV();
            
        }

        private void loadLV()
        {
            lv_khmo.Items.Clear();

            string query = $"select * from {admin}.PROJECT_KHMO";
            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                   using(OracleDataReader reader = cmd.ExecuteReader())
                    {
                    
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem();
                            for (int i = 0;i < reader.FieldCount;i++)
                            {
                                if (i == 0)
                                {
                                    item.Text = reader[i].ToString();
                                }
                                else
                                {
                                    item.SubItems.Add(reader[i].ToString());
                                }
                            }
                            lv_khmo.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("load khmo thất bại: " + ex.Message);
            }
            finally { connection.disconnect(); }
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
                    loadLV();
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


            string sql = $"UPDATE {admin}.PROJECT_KHMO SET HK = {hk}, NAM = {nam}, MACT = '{mact}' WHERE MAHP = '{mahp}' ";
            Debug.WriteLine(sql);

            connection.connect();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật khmo thành công");
                    loadLV();
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
    }
}
