using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class EditUser : Form
    {
        Connection connection = new Connection();
        List<string> privileges = new List<string>() { "Select", "Insert", "Delete", "Update" };
        List<string> queries = new List<string>();
        List<string> tablenames = new List<string>();
        private string username = "PROJECT_U_TEST";
        DataSource ds = new DataSource();
        Role current_user;
        bool block1 = false;
        bool block2 = false;
        public EditUser(string username)
        {
            InitializeComponent();
            this.username = username;
            tablenames = ds.getAllObject(DataSource.table_query, "TABLE_NAME");
            Username_Box.Text = username;
            current_user = getUser();
            InitializeMyComponet();

            //MessageBox.Show(fomatPriUsr(Privilege.S, "PROJECT_dangky", "PROJECT_U_test"));
            //MessageBox.Show(desformatPriUsr("PROJECT_S_test_dangky")[1]);
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

            lv_g.Columns.Add("").Width = 27;
            lv_g.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_r.Columns.Add("").Width = 27;
            lv_r.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_wgo.Columns.Add("").Width = 27;
            lv_wgo.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
        }
        private void getViewUsrPriTab()
        {
            lv_pri_tab.Items.Clear();
            List<string> tables = ds.getAllObject(ds.getQueryUserTabPri(username, "TABLE"), "TABLE_NAME");
            List<string> pris = ds.getAllObject(ds.getQueryUserTabPri(username, "TABLE"), "PRIVILEGE");
            // can xu ly cho view
            for (int i = 0; i < tables.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tables[i];
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = pris[i] });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "ALL" });
                lv_pri_tab.Items.Add(item);
            }
            foreach (Table table in current_user.tables)
            {
                List<string> selects = table.getAllColumnSelect2();
                List<string> updates = table.getAllColumnUpdate2();
                if (selects.Count > 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = table.Name;
                    item.ForeColor = System.Drawing.Color.Aqua;
                    item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                        9F, System.Drawing.FontStyle.Regular, System.Drawing.
                        GraphicsUnit.Point, ((byte)(163)));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "SELECT" });
                    if (selects.Count == table.columns.Count)
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "ALL" });
                    }
                    else
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = string.Join(",", selects) });
                    }
                    lv_pri_tab.Items.Add(item);
                }
                if (updates.Count > 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = table.Name;
                    item.ForeColor = System.Drawing.Color.Aqua;
                    item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                        9F, System.Drawing.FontStyle.Regular, System.Drawing.
                        GraphicsUnit.Point, ((byte)(163)));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "UPDATE" });
                    if (updates.Count == table.columns.Count)
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "ALL" });
                    }
                    else
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = string.Join(",", updates) });
                    }
                    lv_pri_tab.Items.Add(item);
                }
            }
        }
        private void getViewColumn(string tablename)
        {
            List<string> columns = ds.getAllObject(ds.getQueryTableColumn(tablename), "COLUMN_NAME");
            foreach (string column in columns)
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
        private void DisplayColumn()
        {
            block1 = true;
            lv_column.Items.Clear();
            lv_g.Items.Clear();
            lv_r.Items.Clear();
            lv_wgo.Items.Clear();
            string tablename = lv_tab.SelectedItems[0].Text;
            lv_column.Visible = true;
            gb1.Visible = true;
            getViewColumn(tablename);
            int pri = lv_privilege.SelectedItems[0].Index;
            int i = 0;
            Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
            foreach (ListViewItem item in lv_column.Items)
            {
                lv_r.Items.Add(new ListViewItem());
                lv_g.Items.Add(new ListViewItem());
                lv_wgo.Items.Add(new ListViewItem());
                lv_r.Items[i].Checked = true;
                lv_g.Items[i].Checked = table.checkPrivilege(item.Text, pri, Privilege.GRANT);
                lv_wgo.Items[i].Checked = table.checkPrivilege(item.Text, pri, Privilege.WITH_GRANT_OPTION);
                i++;
                //item.Checked = current_user.GetTable(lv_tab.SelectedItems[0].Text).checkPrivilege(item.Text, pri, Privilege.GRANT)
                //    || current_user.GetTable(lv_tab.SelectedItems[0].Text).checkPrivilege(item.Text, pri, Privilege.WITH_GRANT_OPTION);
            }
            block1 = false;
        }
        private void saveEdit()
        {
            ds.updateUser(current_user);
        }
        private Role getUser()
        {
            //List<string> tablename = ds.getAllObject(ds.getQueryUserTabPriV2(username, "TABLE"), "TABLE_NAME");
            //foreach(string table in tablename)
            //{
            //    List<string> columns = ds.getAllObject(ds.getQueryTableColumn(table), "COLUMNNAME");
            //    current_user.add
            //}

            //lay quyen insert delete tren table cua user
            Role user = new Role(username);
            foreach (string table in tablenames)
            {
                List<string> columns = ds.getAllObject(ds.getQueryTableColumn(table), "COLUMN_NAME");
                Table mytable = new Table(table, columns);
                user.tables.Add(mytable);
                List<string> Pris = ds.getAllObject(ds.getPriUsrFromTab(username, table), "PRIVILEGE");
                List<string> option = ds.getAllObject(ds.getPriUsrFromTab(username, table), "GRANTABLE");
                for (int i = 0; i < Pris.Count; i++)
                {
                    int privi = Pris[i].Equals("INSERT") ? Privilege.I : Pris[i].Equals("DELETE") ? Privilege.D :
                        Pris[i].Equals("UPDATE") ? Privilege.U : Privilege.S;
                    int op = option[i].Equals("YES") ? Privilege.WITH_GRANT_OPTION : Privilege.GRANT;
                    mytable.editPrivilege(Table.all, privi, op);
                }
            }
            //lay quyen S U tren view
            List<string> views = ds.getAllObject(ds.getQueryUserTabPri(username, "VIEW"), "TABLE_NAME");
            List<string> options = ds.getAllObject(ds.getQueryUserTabPri(username, "VIEW"), "GRANTABLE");
            for (int i = 0; i < views.Count; i++)
            {
                int pri = desformatPriUsr(views[i])[0].Equals("S") ? Privilege.S : Privilege.U;
                string tablename = desformatPriUsr(views[i])[2];
                string[] columns = ds.getColumnView(views[i]);
                Table table = user.GetTable(tablename);
                foreach (string column in columns)
                {
                    int op = options[i].Equals("YES") ? Privilege.WITH_GRANT_OPTION : Privilege.GRANT;
                    //MessageBox.Show(op.ToString());
                    table.editPrivilege(column, pri, op);
                }
            }
            return user;
        }
        private string fomatPriUsr(int privilege, string tablename, string usrname)
        {
            string pri = Privilege.S == privilege ? "S" : "U";
            usrname = usrname.Contains("PROJECT_U_") ? usrname.Substring(10) : usrname;
            tablename = tablename.Contains("PROJECT_") ? tablename.Substring(8) : tablename;
            return "PROJECT_" + pri + "_" + usrname.ToUpper() + "_" + tablename.ToUpper();
        }
        private List<string> desformatPriUsr(string viewname)
        {
            viewname = viewname.ToUpper();
            List<string> result = new List<string>();
            result.Add(viewname.Substring(viewname.IndexOf("_") + 1, 1));
            result.Add("PROJECT_U_" + viewname.Substring(10, viewname.LastIndexOf('_') - 10));
            result.Add("PROJECT_" + viewname.Substring(viewname.LastIndexOf('_') + 1));
            return result;
        }
        private void lv_column_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_column.SelectedItems.Count > 0)
            {
                lv_column.SelectedItems[0].Checked = !lv_column.SelectedItems[0].Checked;
            }
        }

        private void lv_tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_tab.SelectedItems.Count > 0)
            {
                Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
                block1 = true;
                container_pri.Visible = true;
                for (int i = 0; i < lv_privilege.Items.Count; i++)
                {
                    lv_revoke.Items[i].Checked = true;
                    lv_grant.Items[i].Checked = table.checkPrivilege(Table.any, i, Privilege.GRANT);
                    lv_wgoption.Items[i].Checked = table.checkPrivilege(Table.any, i, Privilege.WITH_GRANT_OPTION);
                }
                block1 = false;
                if (lv_column.Visible)
                {
                    DisplayColumn();
                }
            }

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lv_privilege.SelectedItems.Count > 0)
            {
                ListViewItem item = lv_privilege.SelectedItems[0];
                if (item.Index == Privilege.S || item.Index == Privilege.U)
                {
                    DisplayColumn();
                    lv_grant.Visible = false;
                    lv_wgoption.Visible = false;
                    lv_revoke.Visible = false;
                }
                else
                {
                    lv_column.Visible = false;
                    gb1.Visible = false;
                    lv_grant.Visible = true;
                    lv_wgoption.Visible = true;
                    lv_revoke.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveEdit();
            //current_user.tables.Clear();
            MessageBox.Show("All changes have been saved!");
            container_pri.Visible = false;
            lv_column.Visible = false;
            gb1.Visible = false;
            //update screen
            getViewUsrPriTab();
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

        private void lv_column_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            block1 = true;
            if (item.Checked)
            {
                Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
                int pri = lv_privilege.SelectedItems[0].Index;
                //int op = lv_wgop.SelectedItems[0].Checked
            }
            block1 = false;
        }

        private void lv_g_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_g_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
            if (item.Checked)
            {
                if (!block1)
                {
                    table.editPrivilege(lv_column.Items[item.Index].Text,
                        lv_privilege.SelectedItems[0].Index, Privilege.GRANT);
                }
                block2 = true;
                lv_r.Items[item.Index].Checked = false;
                lv_wgo.Items[item.Index].Checked = false;
                block2 = false;
            }
            else if (!block2 && !block1)
            {
                table.editPrivilege(lv_column.Items[item.Index].Text,
                        lv_privilege.SelectedItems[0].Index, Privilege.NONE);

            }
        }

        private void lv_r_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            if (item.Checked)
            {
                lv_g.Items[item.Index].Checked = false;
                lv_wgo.Items[item.Index].Checked = false;
            }

        }

        private void lv_wgo_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            Table table = current_user.GetTable(lv_tab.SelectedItems[0].Text);
            if (item.Checked)
            {
                if (!block1)
                {
                    table.editPrivilege(lv_column.Items[item.Index].Text,
                        lv_privilege.SelectedItems[0].Index, Privilege.WITH_GRANT_OPTION);
                }
                block2 = true;
                lv_r.Items[item.Index].Checked = false;
                lv_g.Items[item.Index].Checked = false;
                block2 = false;
            }
            else if (!block2 && !block1)
            {
                table.editPrivilege(lv_column.Items[item.Index].Text,
                        lv_privilege.SelectedItems[0].Index, Privilege.NONE);
            }
        }
    }
}
