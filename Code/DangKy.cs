using DB_Management;
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
    public partial class DangKy : UserControl
    {
        bool my = false;
        List<List<string>> temptable;
        List<List<string>> dangkyList = new List<List<string>>();
        List<string> usrolepri = new List<string>();
        List<string> views = new List<string>();
        List<string> viewupdates = new List<string>();
        List<string> viewinserts = new List<string>();
        List<string> viewdeletes = new List<string>();
        string viewGlobal = "";
        string admin = "ADMIN_OLS";
        int edit_type = 0; //0 due to insert and 1 due to update;
        int insert = 0;
        int update = 1;
        int choose = 2;
        int chooseall = 3;
        public string stringsql;
        public OracleConnection conn;
        public DangKy()
        {
            InitializeComponent();
            stringsql = $"Data Source=localhost:1521/PROJECT_DBMANAGEMENT;User Id={Config.username};Password={Config.password};";
            conn = new OracleConnection(stringsql);
            initializeMyComponent();
        }
        private void initializeMyComponent()
        {

            int size = 70;
            lv_dk.Columns.Add("MASV").Width = size;
            lv_dk.Columns.Add("MAGV").Width = size;
            lv_dk.Columns.Add("MAHP").Width = size;
            lv_dk.Columns.Add("HOCKY").Width = size;
            lv_dk.Columns.Add("NAM").Width = size;
            lv_dk.Columns.Add("MACT").Width = size;
            lv_dk.Columns.Add("DIEMTH").Width = size;
            lv_dk.Columns.Add("DIEMQT").Width = size;
            lv_dk.Columns.Add("DIEMCK").Width = size;
            lv_dk.Columns.Add("DIEMTK").Width = size;
            temptable = initTempt(viewdeletes);
        }
        public void load()
        {
            if (dangkyList.Count == 0)
            {
                getList();
                getPriView();
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }

        }
        private void getPriView()
        {
            viewupdates.AddRange(getObjectv1("SELECT DISTINCT TABLE_NAME FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'UPDATE'" +
                    " AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            viewinserts.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'INSERT'" +
                    " AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            viewdeletes.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'DELETE'" +
                    " AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            foreach (string role in usrolepri)
            {
                viewdeletes.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'DELETE'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            }
            foreach (string role in usrolepri)
            {
                viewinserts.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'INSERT'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            }
            foreach (string role in usrolepri)
            {
                viewupdates.AddRange(getObjectv1("SELECT DISTINCT TABLE_NAME FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'UPDATE'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            }
        }
        private void getList()
        {
            dangkyList.Clear();
            usrolepri = getObjectv1("SELECT * FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE" +
                " LIKE 'P%'", "GRANTED_ROLE");
            if (usrolepri.Contains("P_TRUONGDONVI") || usrolepri.Contains("P_TRUONGKHOA"))
            {
                usrolepri.Add("P_GIANGVIEN");
            }
            foreach (string role in usrolepri)
            {
                views.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'SELECT'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            }
            views.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'SELECT'" +
                    " AND TABLE_NAME LIKE '%DANGKY%'", "TABLE_NAME"));
            string query = "";
            for (int i = 0; i < views.Count; i++)
            {
                query += $"SELECT* FROM {admin}." + views[i];
                if (i != views.Count - 1)
                {
                    query += " UNION ";
                }
            }
            if (!query.Equals(""))
            {
                dangkyList.AddRange(getObjectv2(query, new List<string>()
                { "MASV","MAGV", "MAHP", "HK", "NAM", "MACT","DIEMTH","DIEMQT","DIEMCK","DIEMTK" }));
            }

        }
        private void getViewForList()
        {
            foreach (List<string> row in dangkyList)
            {
                getViewforItem(row);
            }
        }
        private void getViewforItem(List<string> row)
        {
            ListViewItem item = new ListViewItem();
            item.Text = row[0];
            item.ForeColor = System.Drawing.Color.Aqua;
            item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular, System.Drawing.
                GraphicsUnit.Point, ((byte)(163)));
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[1] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[2] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[3] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[4] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[5] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[6] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[7] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[8] });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = row[9] });
            lv_dk.Items.Add(item);
        }
        private void removeRowAt(int index)
        {

        }
        private void insertData()
        {
            if (viewinserts.Count > 0)
            {
                string v = viewinserts[0];
                OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
                conn.Open();
                //command.ExecuteNonQuery();
                try
                {
                    command.CommandText = $"INSERT INTO {admin}." + v + "(MASV,MAGV,MAHP,HK,NAM,MACT,DIEMTH,DIEMQT,DIEMTCK,DIEMTK)" +
                        " VALUES(" + tb_masv.Text + "," + tb_magv.Text + ",'" + tb_mahp.Text + "'," + tb_hk.Text + "," +
                        tb_nam.Text + ",'" + tb_mact.Text + "'," + tb_DT.Text + "," + tb_DQT.Text + "," + tb_DCK.Text + "," + tb_DTK.Text + ")";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfull");
                    dangkyList.Add(new List<string>() { tb_masv.Text,tb_magv.Text,tb_mahp.Text,
                        tb_hk.Text,tb_hk.Text,tb_nam.Text,tb_mact.Text,tb_DT.Text,tb_DQT.Text,
                    tb_DCK.Text,tb_DTK.Text});
                    getViewforItem(dangkyList[dangkyList.Count - 1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Cannot insert because you dont't have permission!");
            }
        }
        private void updateData()
        {
            if (viewupdates.Count == 0 || (!tb_magv.Enabled && !tb_mahp.Enabled &&
                !tb_hk.Enabled && !tb_nam.Enabled && !tb_mact.Enabled))
            {
                return;
            }
            else
            {
                ListViewItem item = lv_dk.SelectedItems[0];
                string wherecluase = "WHERE MASV ='" + item.SubItems[0].Text + "' AND MAGV ='" + item.SubItems[1].Text + "' AND MAHP = '" + item.SubItems[2].Text +
                    "' AND HK = " + item.SubItems[3].Text + " AND NAM = " + item.SubItems[4].Text +
                    " AND MACT = '" + item.SubItems[5].Text + "'";
                string setclause = " SET ";
                List<string> column = new List<string>();
                if (tb_masv.Enabled) column.Add(" MASV = '" + tb_masv.Text + "' ");
                if (tb_magv.Enabled) column.Add("MAGV = '" + tb_magv.Text + "' ");
                if (tb_mahp.Enabled) column.Add("MAHP = '" + tb_mahp.Text + "' ");
                if (tb_hk.Enabled) column.Add("HK = " + tb_hk.Text);
                if (tb_nam.Enabled) column.Add(" NAM = " + tb_nam.Text);
                if (tb_mact.Enabled) column.Add(" MACT = '" + tb_mact.Text + "' ");
                if (tb_DT.Enabled) column.Add(" DIEMTH = '" + tb_DT.Text + "' ");
                if (tb_DQT.Enabled) column.Add(" DIEMQT = '" + tb_DQT.Text + "' ");
                if (tb_DCK.Enabled) column.Add(" DIEMCK = '" + tb_DCK.Text + "' ");
                if (tb_DTK.Enabled) column.Add(" DIEMTK = '" + tb_DTK.Text + "' ");
                for (int i = 0; i < column.Count; i++)
                {
                    setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
                }
                OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
                conn.Open();
                //command.ExecuteNonQuery();
                command.CommandText = $"UPDATE {admin}." + viewGlobal + setclause + wherecluase;
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("1 row update!");
            }
        }
        private void lv_pc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_dk.SelectedIndices.Count > 0)
            {
                viewGlobal = "";
                ListViewItem item = lv_dk.SelectedItems[0];
                if (edit_type == choose || edit_type == chooseall)
                {
                    item.Checked = !item.Checked;

                }
                else
                {
                    edit_type = update;
                    tb_masv.Text = item.SubItems[0].Text;
                    tb_magv.Text = item.SubItems[1].Text;
                    tb_mahp.Text = item.SubItems[2].Text;
                    tb_hk.Text = item.SubItems[3].Text;
                    tb_nam.Text = item.SubItems[4].Text;
                    tb_mact.Text = item.SubItems[5].Text;
                    tb_DT.Text = item.SubItems[6].Text;
                    tb_DQT.Text = item.SubItems[7].Text;
                    tb_DCK.Text = item.SubItems[8].Text;
                    tb_DTK.Text = item.SubItems[9].Text;
                    //enable false if neccessary
                    tb_magv.Enabled = false; tb_mahp.Enabled = false; tb_hk.Enabled = false;
                    tb_nam.Enabled = false; tb_mact.Enabled = false; tb_masv.Enabled = false;
                    tb_DT.Enabled = false; tb_DQT.Enabled = false; tb_DCK.Enabled = false;
                    tb_DTK.Enabled = false;
                    foreach (string v in viewupdates)
                    {
                        List<List<string>> list = initTempt(new List<string>() { v });
                        if (checkExist(list, item))
                        {
                            viewGlobal = v;
                            break;
                        }
                    }
                    if (!viewGlobal.Equals(""))
                    {

                        List<string> columnupdate = getObjectv1("SELECT * FROM ROLE_TAB_PRIVS " +
                            "WHERE TABLE_NAME = '" + viewGlobal + "' AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");
                        tb_mact.Enabled = columnupdate.Contains("MACT");
                        //MessageBox.Show(columnupdate.Count.ToString());
                        Debug.WriteLine(columnupdate);
                        if (columnupdate[0].Equals(""))
                        {
                            tb_magv.Enabled = tb_mahp.Enabled = tb_hk.Enabled = tb_nam.Enabled = tb_mact.Enabled
                             = tb_masv.Enabled = tb_DT.Enabled = tb_DQT.Enabled = tb_DCK.Enabled = tb_DTK.Enabled = true;

                        }

                        else
                        {
                            tb_magv.Enabled = columnupdate.Contains("MAGV");
                            tb_mahp.Enabled = columnupdate.Contains("MAHP");
                            tb_hk.Enabled = columnupdate.Contains("HK");
                            tb_nam.Enabled = columnupdate.Contains("NAM");
                            tb_mact.Enabled = columnupdate.Contains("MACT");
                            tb_masv.Enabled = columnupdate.Contains("MASV");
                            tb_DT.Enabled = columnupdate.Contains("DIEMTH");
                            tb_DQT.Enabled = columnupdate.Contains("DIEMQT");
                            tb_DCK.Enabled = columnupdate.Contains("DIEMCK");
                            tb_DTK.Enabled = columnupdate.Contains("DIEMTK");

                        }
                    }

                    btn_choose.Visible = false;
                    gb_edit.Text = "Update";
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lv_dk.Items.Count; i++)
            {
                if (lv_dk.Items[i].Checked)
                {
                    lv_dk.Items.RemoveAt(i);
                    removeRowAt(i);
                    dangkyList.RemoveAt(i);
                    i--;
                }
            }
            btn_choose.Text = "Choose";
            btn_delete.Visible = false;
            lv_dk.CheckBoxes = false;
            edit_type = 0;
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            if (edit_type != choose && edit_type != chooseall)
            {
                edit_type = choose;
                btn_choose.Text = "All";
                lv_dk.CheckBoxes = true;
                btn_delete.Visible = true;
            }
            else if (edit_type != chooseall)
            {
                edit_type = chooseall;
                btn_choose.Text = "Clear";
                foreach (ListViewItem item in lv_dk.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                edit_type = choose;
                btn_choose.Text = "All";
                foreach (ListViewItem item in lv_dk.Items)
                {
                    item.Checked = false;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (edit_type == update)
            {
                //
                try
                {
                    updateData();

                    ListViewItem item = lv_dk.SelectedItems[0];
                    List<string> row = dangkyList[item.Index];
                    item.SubItems[0].Text = row[0] = tb_masv.Text;
                    item.SubItems[1].Text = row[1] = tb_magv.Text;
                    item.SubItems[2].Text = row[2] = tb_mahp.Text;
                    item.SubItems[3].Text = row[3] = tb_hk.Text;
                    item.SubItems[4].Text = row[3] = tb_nam.Text;
                    item.SubItems[5].Text = row[4] = tb_mact.Text;
                    item.SubItems[6].Text = row[4] = tb_DT.Text;
                    item.SubItems[7].Text = row[4] = tb_DQT.Text;
                    item.SubItems[8].Text = row[4] = tb_DCK.Text;
                    item.SubItems[9].Text = row[4] = tb_DTK.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
                tb_masv.Text = "";
                tb_magv.Text = "";
                tb_mahp.Text = "";
                tb_hk.Text = "";
                tb_nam.Text = "";
                tb_mact.Text = "";
                tb_DT.Text = "";
                tb_DQT.Text = "";
                tb_DCK.Text = "";
                tb_DTK.Text = "";
                btn_choose.Visible = true;
                gb_edit.Text = "Insert";
            }
            else
            {
                insertData();
            }
        }

        private void lv_pc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item;

            if (item.Checked)
            {
                if (!checkExist(temptable, item))
                {
                    item.Checked = false;
                }

            }

            if (lv_dk.CheckedItems.Count == 0)
            {
                btn_delete.Text = "Back";
            }
            else
            {
                btn_delete.Text = "Delete";
            }
        }
        private List<List<string>> getObjectv2(string query, List<string> columns)
        {
            List<List<string>> myobject = new List<List<string>>();
            OracleCommand command = new OracleCommand(query, conn);
            Debug.WriteLine(query);
            conn.Open();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> row = new List<string>();
                foreach (string column in columns)
                {
                    row.Add(reader[column].ToString());
                }

                myobject.Add(row);
            }
            conn.Close();
            return myobject;
        }
        public List<string> getObjectv1(string query, string column)
        {
            List<string> myobject = new List<string>();
            OracleCommand command = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string result = reader[column].ToString();
                myobject.Add(result);
            }
            conn.Close();
            return myobject;
        }
        List<List<string>> initTempt(List<string> v)
        {
            string query = "";
            for (int i = 0; i < v.Count; i++)
            {
                query += $"SELECT* FROM {admin}." + v[i];
                if (i != v.Count - 1)
                {
                    query += " UNION ";
                }
            }
            List<List<string>> tempt = new List<List<string>>();
            if (!query.Equals(""))
            {
                tempt.AddRange(getObjectv2(query, new List<string>()
                        { "MASV","MAGV", "MAHP", "HK", "NAM", "MACT","DIEMTH","DIEMQT","DIEMCK","DIEMTK" }));
            }
            return tempt;
        }
        private bool checkExist(List<List<string>> tempt, ListViewItem item)
        {
            foreach (List<string> row in tempt)
            {
                if (row[0].Equals(item.SubItems[0].Text) && row[1].Equals(item.SubItems[1].Text)
                    && row[2].Equals(item.SubItems[2].Text) && row[3].Equals(item.SubItems[3].Text)
                    && row[4].Equals(item.SubItems[4].Text) && row[5].Equals(item.SubItems[5].Text))
                {

                    return true;
                }
            }
            return false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            getViewForList();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
