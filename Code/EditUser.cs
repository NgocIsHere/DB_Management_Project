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
using System.Windows.Documents;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class EditUser : UserControl
    {
        Connection connection = new Connection();
        List<string> privileges = new List<string>() { "Select", "Insert", "Delete", "Update" };
        List<string> queries = new List<string>();
        List<string> tablenames = new List<string>();
        public static string username = "PROJECT_U_TEST";
        DataSource ds = new DataSource();
        Role current_user;
        bool block1 = false;
        bool block2 = false;
        public EditUser()
        {
            InitializeComponent();
            tablenames = ds.getAllObject(DataSource.table_query, "TABLE_NAME");
            current_user = getUser();
            InitializeMyComponet();
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
            List<string> tables = ds.getAllObject(ds.getQueryUserTabPri(username,"TABLE"),"TABLE_NAME");
            List<string> pris = ds.getAllObject(ds.getQueryUserTabPri(username, "TABLE"), "PRIVILEGE");
            List<string> cols = new List<string>();
            // can xu ly cho view
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
        private Role getUser()
        {
            //List<string> tablename = ds.getAllObject(ds.getQueryUserTabPriV2(username, "TABLE"), "TABLE_NAME");
            //foreach(string table in tablename)
            //{
            //    List<string> columns = ds.getAllObject(ds.getQueryTableColumn(table), "COLUMNNAME");
            //    current_user.add
            //}
            Role user = new Role(username);
            foreach(string table in tablenames)
            {
                List<string> columns = ds.getAllObject(ds.getQueryTableColumn(table), "COLUMN_NAME");
                Table mytable = new Table(table, columns);
                user.tables.Add(mytable);
                List<string> Pris = ds.getAllObject(ds.getPriUsrFromTab(username, table),"PRIVILEGE");
                List<string>option = ds.getAllObject(ds.getPriUsrFromTab(username, table), "GRANTABLE");
                for(int i =0;i<Pris.Count;i++)
                {
                    int privi = Pris[i].Equals("INSERT") ? Privilege.I : Pris[i].Equals("UPDATE") ? Privilege.U : Privilege.D;
                    int op = option[i].Equals("YES") ? Privilege.WITH_GRANT_OPTION : Privilege.GRANT;
                    mytable.editPrivilege(Table.all, privi, op);
                }
            }
            return user;
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
                block1 = true;
                container_pri.Visible = true;
                for(int i = 0; i < lv_privilege.Items.Count; i++)
                {
                    lv_revoke.Items[i].Checked = true;
                    lv_grant.Items[i].Checked = table.checkPrivilege(Table.any, i, Privilege.GRANT);
                    lv_wgoption.Items[i].Checked = table.checkPrivilege(Table.any, i, Privilege.WITH_GRANT_OPTION);
                }
                block1 = false;
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
            //update screen
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lv_grant_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
            ListViewItem item = e.Item as ListViewItem;
            if (item.Checked)
            {
                if (!block1)
                {
                    table.editPrivilege(Table.all, item.Index, Privilege.GRANT);
                }
                block2 = true;
                lv_revoke.Items[item.Index].Checked = false;
                lv_wgoption.Items[item.Index].Checked = false;
                block2 = false;
            }
            else if (!block2 && !block1)
            {
                table.editPrivilege(Table.all, item.Index, Privilege.NONE);
            }
        }

        private void lv_revoke_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            if (item.Checked)
            {
                lv_grant.Items[item.Index].Checked = false;
                lv_wgoption.Items[item.Index].Checked = false;

            }
        }

        private void lv_wgoption_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
            if (item.Checked)
            {
                if (!block1)
                {
                    table.editPrivilege(Table.all, item.Index, Privilege.WITH_GRANT_OPTION);
                }
                block2 = true;
                lv_grant.Items[item.Index].Checked = false;
                lv_revoke.Items[item.Index].Checked = false;
                block2 = false;
            }
            else if (!block2 && !block1)
            {
                table.editPrivilege(Table.all, item.Index, Privilege.NONE);
            }
        }
    }
}
