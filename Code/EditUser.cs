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
    public partial class EditUser : UserControl
    {
        Connection connection = new Connection();
        List<string> privileges = new List<string>() { "Select", "Insert", "Delete", "Update" };
        List<string> queries = new List<string>();
        List<string> tablenames = new List<string>();
        public string username;
        DataSource ds = new DataSource();
        Role current_user;
        bool block_init = false;
        public EditUser(string usrname)
        {
            InitializeComponent();
            InitializeMyComponet();
            username = usrname;
            MessageBox.Show(username);
        }

        private void InitializeMyComponet()
        {
            //lv_usr_priv_tab
            lv_pri_tab.Columns.Add("Table").Width = 150;
            lv_pri_tab.Columns.Add("Privilege").Width = 100;
            lv_pri_tab.Columns.Add("Column").Width = 70;
            lv_pri_tab.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_pri_tab.View = View.Details;
            getViewUsrPriTab();
            //lv_table
            lv_tab.Columns.Add("table").Width = 200;
            lv_tab.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_tab.View = View.Details;
            tablenames = ds.getAllObject(DataSource.table_query, "TABLE_NAME");
            foreach (string tablename in tablenames)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tablename;
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                lv_tab.Items.Add(item);

            }
            //lv_column
            lv_column.Columns.Add("column").Width = 100;
            lv_column.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_column.View = View.Details;

            //lv_privilege
            lv_privilege.Columns.Add("Privilege").Width = 70;
            lv_privilege.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_privilege.View = View.Details;
            foreach (string privilege in privileges)
            {
                ListViewItem item = new ListViewItem();
                item.Text = privilege;
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                lv_privilege.Items.Add(item);

            }
            //listview grant - deny - withgrantoption
            lv_grant.Columns.Add("").Width = 27;
            lv_grant.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_grant.View = View.Details;
            lv_revoke.Columns.Add("").Width = 27;
            lv_revoke.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_revoke.View = View.Details;
            lv_wgoption.Columns.Add("").Width = 27;
            lv_wgoption.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_wgoption.View = View.Details;
            for (int i = 0; i < privileges.Count; i++)
            {
                lv_grant.Items.Add(new ListViewItem());
                lv_revoke.Items.Add(new ListViewItem());
                lv_wgoption.Items.Add(new ListViewItem());
            }
        }
        private void getViewUsrPriTab()
        {
            lv_pri_tab.Items.Clear();
            List<String> tables = ds.getAllObject(ds.getQueryUserTabPri(username,"TABLE"),"TABLE_NAME");
            List<string> pris = ds.getAllObject(ds.getQueryUserTabPri(username, "TABLE"), "PRIVILEGE");
            List<string> cols = new List<string>();
            for (int i=0;i<tables.Count;i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tables[i];
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = pris[i] });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "all" });
                lv_pri_tab.Items.Add(item);

            }
        }
        private void getViewColumn(string tablename)
        {
            List<string> columns = ds.getAllObject(ds.getQueryTableColumn(tablename), "COLUMN_NAME");
            foreach(string column in columns)
            {
                ListViewItem item = new ListViewItem();
                item.Text = column;
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                lv_column.Items.Add(item);
            }
        }
        private void saveEdit()
        {

        }
        private void lv_column_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_column.SelectedItems.Count > 0)
            {
                lv_column.SelectedItems[0].Checked = ! lv_column.SelectedItems[0].Checked;
            }
        }

        private void lv_tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_tab.SelectedItems.Count > 0)
            {
                Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
                container_pri.Visible = true;
                block_init = true;
                for(int i = 0; i < lv_privilege.Items.Count; i++)
                {
                    //lv_grant.Items[i].Checked = table.checkPrivilege()
                }
            }
            
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lv_privilege.SelectedItems.Count > 0)
            {
                ListViewItem item = lv_privilege.SelectedItems[0];
                if(item.Index == Privilege.S || item.Index == Privilege.U)
                {
                    lv_column.Items.Clear();
                    string tablename = lv_tab.SelectedItems[0].Text;
                    lv_column.Visible = true;
                    getViewColumn(tablename);
                } 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current_user.tables.Clear();
            saveEdit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            userList edt = new userList();
            edt.Show();
        }

    }
}
