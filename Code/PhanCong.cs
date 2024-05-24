using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using DB_Management;
using Oracle.ManagedDataAccess.Client;

namespace DB_Management
{
    //1 lay toan bo role
    public partial class PhanCong : UserControl
    {
        List<List<string>> phanCongList = new List<List<string>>();
        List<string> usrolepri = new List<string>();
        List<string> views = new List<string>();
        List<string> viewupdates = new List<string>();
        List<string> viewinserts = new List<string>();
        List<string> viewdeletes = new List<string>();
        string viewGlobal = "";
        int edit_type = 0;
        int insert = 0;
        int update = 1;
        int choose = 2;
        int chooseall = 3;
        public string stringsql;
        public OracleConnection conn;
        public PhanCong()
        {
            InitializeComponent();
            stringsql = $"Data Source=localhost:1521/XE;User Id={Config.username};Password={Config.password};";
            conn = new OracleConnection(stringsql);
            initializeMyComponent();
        }
        private void initializeMyComponent()
        {
            getList();
            getPriView();
            int size = 140;
            lv_pc.Columns.Add("MAGV").Width = size;
            lv_pc.Columns.Add("MAHP").Width = size;
            lv_pc.Columns.Add("HOCKY").Width = size;
            lv_pc.Columns.Add("NAM").Width = size;
            lv_pc.Columns.Add("MACT").Width = size;
            getViewForList();
        }
        private void getPriView()
        {
            viewupdates.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'UPDATE'" +
                    " AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            viewinserts.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'INSERT'" +
                    " AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            viewdeletes.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'DELETE'" +
                    " AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            foreach (string role in usrolepri)
            {
                viewdeletes.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'DELETE'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            }
            foreach (string role in usrolepri)
            {
                viewinserts.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'INSERT'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            }
            foreach (string role in usrolepri)
            {
                viewupdates.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'UPDATE'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            }
        }
        private void getList()
        {
            phanCongList.Clear();
            usrolepri = getObjectv1("SELECT * FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE" +
                " LIKE 'C##P%'", "GRANTED_ROLE");
            foreach (string role in usrolepri)
            {
                views.AddRange(getObjectv1("SELECT * FROM ROLE_TAB_PRIVS WHERE PRIVILEGE = 'SELECT'" +
                    " AND ROLE = '" + role + "' AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            }
            views.AddRange(getObjectv1("SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'SELECT'" +
                    " AND TABLE_NAME LIKE '%PHANCONG%'", "TABLE_NAME"));
            string query = "";
            for (int i = 0; i < views.Count; i++)
            {
                query += "SELECT* FROM C##ADMIN." + views[i];
                if (i != views.Count - 1)
                {
                    query += " UNION ";
                }
            }
            if (!query.Equals(""))
            {
                phanCongList.AddRange(getObjectv2(query, new List<string>()
                { "MAGV", "MAHP", "HK", "NAM", "MACT" }));
            }
            //MessageBox.Show(phanCongList.Count.ToString());
        }
        private void getViewForList()
        {
            foreach (List<string> row in phanCongList)
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
            lv_pc.Items.Add(item);
        }
        private void removeRowAt(int index)
        {
            List<string> row = phanCongList[index];
            OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
            conn.Open();
            command.ExecuteNonQuery();
            for (int i = 0; i < viewdeletes.Count; i++)
            {
                try
                {
                    command.CommandText = "DELETE FROM C##ADMIN." + viewdeletes[i] + " WHERE MAGV = '" + row[0] + "' AND MAHP = '" +
                    row[1] + "' AND HK = '" + row[2] + "' AND NAM = '" + row[3] + "' AND MACT = '" + row[4] + "'";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            conn.Close();
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
                ListViewItem item = lv_pc.SelectedItems[0];
                string wherecluase = "WHERE MAGV ='" + item.SubItems[0].Text + "' AND MAHP = '" + item.SubItems[1].Text +
                    "' AND HK = " + item.SubItems[2].Text + " AND NAM = " + item.SubItems[3].Text +
                    " AND MACT = '" + item.SubItems[4].Text + "'";
                string setclause = " SET ";
                List<string> column = new List<string>();
                if (tb_magv.Enabled) column.Add("MAGV = '" + tb_magv.Text + "' ");
                if (tb_mahp.Enabled) column.Add("MAHP = '" + tb_mahp.Text + "' ");
                if (tb_hk.Enabled) column.Add("HK = " + tb_hk.Text);
                if (tb_nam.Enabled) column.Add(" NAM = " + tb_nam.Text);
                if (tb_mact.Enabled) column.Add(" MACT = '" + tb_mact.Text + "' ");
                for (int i = 0; i < column.Count; i++)
                {
                    setclause += i == column.Count - 1 ? column[i] : column[i] + ", ";
                }
                OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
                conn.Open();
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE C##ADMIN." + viewGlobal + setclause + wherecluase;
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("1 row update!");
            }

        }
        private void insertData()
        {
            if (viewinserts.Count > 0)
            {
                string v = viewinserts[0];
                OracleCommand command = new OracleCommand("alter session set \"_oracle_script\" = TRUE", conn);
                conn.Open();
                command.ExecuteNonQuery();
                try
                {
                    command.CommandText = "INSERT INTO C##ADMIN." + v + "(MAGV,MAHP,HK,NAM,MACT) VALUES(" + tb_magv.Text + "," +
                        tb_mahp.Text + "," + tb_hk.Text + "," + tb_nam.Text + "," + tb_mact.Text + ")";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfull");
                    phanCongList.Add(new List<string>() { tb_magv.Text,tb_mahp.Text,tb_hk.Text,tb_hk.Text,
                    tb_nam.Text,tb_mact.Text});
                    getViewforItem(phanCongList[phanCongList.Count - 1]);
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
        private List<List<string>> getObjectv2(string query, List<string> columns)
        {
            List<List<string>> myobject = new List<List<string>>();
            OracleCommand command = new OracleCommand(query, conn);
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
        private void lv_pc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_pc.SelectedIndices.Count > 0)
            {
                viewGlobal = "";
                ListViewItem item = lv_pc.SelectedItems[0];
                if (edit_type == choose || edit_type == chooseall)
                {
                    item.Checked = !item.Checked;
                }
                else
                {
                    edit_type = update;
                    tb_magv.Text = item.SubItems[0].Text;
                    tb_mahp.Text = item.SubItems[1].Text;
                    tb_hk.Text = item.SubItems[2].Text;
                    tb_nam.Text = item.SubItems[3].Text;
                    tb_mact.Text = item.SubItems[4].Text;
                    //enable false if neccessary
                    tb_magv.Enabled = false;
                    tb_mahp.Enabled = false;
                    tb_hk.Enabled = false;
                    tb_nam.Enabled = false;
                    tb_mact.Enabled = false;
                    foreach (string v in viewupdates)
                    {
                        List<List<string>> list = initTempt(new List<string>() { v });
                        if (checkExist(list, item))
                        {
                            viewGlobal = v;
                        }
                    }
                    if (!viewGlobal.Equals(""))
                    {

                        List<string> columnupdate = getObjectv1("SELECT * FROM ROLE_TAB_PRIVS " +
                            "WHERE TABLE_NAME = '" + viewGlobal + "' AND PRIVILEGE = 'UPDATE'", "COLUMN_NAME");

                        if (columnupdate[0].Equals(""))
                        {
                            tb_magv.Enabled = tb_mahp.Enabled = tb_hk.Enabled = tb_nam.Enabled = tb_mact.Enabled = true;

                        }
                        else
                        {
                            tb_magv.Enabled = columnupdate.Contains("MAGV");
                            tb_mahp.Enabled = columnupdate.Contains("MAHP");
                            tb_hk.Enabled = columnupdate.Contains("HK");
                            tb_nam.Enabled = columnupdate.Contains("NAM");
                            tb_mact.Enabled = columnupdate.Contains("MACT");

                        }
                    }

                    btn_choose.Visible = false;
                    gb_edit.Text = "Update";
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lv_pc.Items.Count; i++)
            {
                if (lv_pc.Items[i].Checked)
                {
                    lv_pc.Items.RemoveAt(i);
                    removeRowAt(i);
                    i--;
                }
            }
            btn_choose.Text = "Choose";
            btn_delete.Visible = false;
            lv_pc.CheckBoxes = false;
            edit_type = 0;
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            if (edit_type != choose && edit_type != chooseall)
            {
                edit_type = choose;
                btn_choose.Text = "All";
                lv_pc.CheckBoxes = true;
                btn_delete.Visible = true;
            }
            else if (edit_type != chooseall)
            {
                edit_type = chooseall;
                btn_choose.Text = "Clear";
                foreach (ListViewItem item in lv_pc.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                edit_type = choose;
                btn_choose.Text = "All";
                foreach (ListViewItem item in lv_pc.Items)
                {
                    item.Checked = false;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (edit_type == update)
            {
                try
                {
                    updateData();

                    ListViewItem item = lv_pc.SelectedItems[0];

                    List<string> row = phanCongList[item.Index];
                    item.SubItems[0].Text = row[0] = tb_magv.Text;
                    item.SubItems[1].Text = row[1] = tb_mahp.Text;
                    item.SubItems[2].Text = row[2] = tb_hk.Text;
                    item.SubItems[3].Text = row[3] = tb_nam.Text;
                    item.SubItems[4].Text = row[4] = tb_mact.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
                tb_magv.Text = "";
                tb_mahp.Text = "";
                tb_hk.Text = "";
                tb_nam.Text = "";
                tb_mact.Text = "";
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
            List<List<string>> tempt = initTempt(viewdeletes);
            //MessageBox.Show(viewdeletes.Count.ToString());
            if (item.Checked)
            {
                if (!checkExist(tempt, item))
                {
                    item.Checked = false;
                }

            }

            if (lv_pc.CheckedItems.Count == 0)
            {
                btn_delete.Text = "Back";
            }
            else
            {
                btn_delete.Text = "Delete";
            }
        }

        private void lv_pc_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
        List<List<string>> initTempt(List<string> v)
        {
            string query = "";
            for (int i = 0; i < v.Count; i++)
            {
                query += "SELECT* FROM C##ADMIN." + v[i];
                if (i != v.Count - 1)
                {
                    query += " UNION ";
                }
            }
            List<List<string>> tempt = new List<List<string>>();
            if (!query.Equals(""))
            {
                tempt.AddRange(getObjectv2(query, new List<string>()
                        { "MAGV", "MAHP", "HK", "NAM", "MACT" }));
            }
            return tempt;
        }
        private bool checkExist(List<List<string>> tempt, ListViewItem item)
        {
            foreach (List<string> row in tempt)
            {
                if (row[0].Equals(item.SubItems[0].Text) && row[1].Equals(item.SubItems[1].Text)
                    && row[2].Equals(item.SubItems[2].Text) && row[3].Equals(item.SubItems[3].Text)
                    && row[4].Equals(item.SubItems[4].Text))
                {

                    return true;
                }
            }
            return false;
        }

        private void PhanCong_Load(object sender, EventArgs e)
        {

        }
    }
}
