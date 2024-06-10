using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class ThongBao : UserControl
    {
        int index;
        private string connectionString;
        string host = "localhost";
        string port = "1521";
        string servicename = "project_dbmanagement";
        string userId = Config.username;
        string password = Config.password;
        public OracleConnection connection;
        List<List<string>> thongbaos = new List<List<string>>();
        public ThongBao()
        {
            InitializeComponent();
            connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={servicename})));User Id={userId};Password={password};";
            getData();
            lv_tb.Columns.Add("Ngày").Width = 100;
            lv_tb.Columns.Add("Tiêu đề").Width = 550;
            foreach (List<string> item in thongbaos)
            {
                getViewForItem(item);
            }
        }
        private void getViewForItem(List<string> row)
        {
            ListViewItem item = new ListViewItem();
            item.Text = row[0];
            item.ForeColor = System.Drawing.Color.Aqua;
            item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular, System.Drawing.
                GraphicsUnit.Point, ((byte)(163)));
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[1] });
            lv_tb.Items.Add(item);
        }
        private void getData()
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                OracleCommand command = new OracleCommand("Select * from ADMIN_OLS.PROJECT_OLS_THONGBAO", connection);

                OracleDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string title = reader["CONTENT"].ToString();
                    string date = reader["NGAYTHONGBAO"].ToString();
                    string message = reader["MESSAGE"].ToString();
                    thongbaos.Add(new List<string>() { date, title, message });
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            lv_tb.Visible = true;
            btn_back.Visible = false;
            detail.Visible = false;
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            index--;
            btn_next.Visible = true;
            if (index == 0)
            {
                btn_pre.Visible = false;
            }
            lb_detail.Text = thongbaos[index][2];
            detail.Text = thongbaos[index][1];

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            index++;
            btn_pre.Visible = true;
            if (index == thongbaos.Count - 1)
            {
                btn_next.Visible = false;
            }
            lb_detail.Text = thongbaos[index][2];
            detail.Text = thongbaos[index][1];
        }

        private void lv_tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_tb.SelectedItems.Count > 0)
            {
                index = lv_tb.SelectedItems[0].Index;
                lv_tb.Visible = false;
                btn_back.Visible = true;
                detail.Visible = true;
                lb_detail.Text = thongbaos[index][2];
                detail.Text = thongbaos[index][1];
                btn_pre.Visible = true;
                btn_next.Visible = true;
                if (index == 0)
                {
                    btn_pre.Visible = false;
                }
                else if (index == thongbaos.Count - 1)
                {
                    btn_next.Visible = false;
                }
            }
        }
    }
}
