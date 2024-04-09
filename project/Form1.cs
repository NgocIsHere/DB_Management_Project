using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        
        int count = 0;
        private bool allcheck = true;
        private bool isadd = false;
        private bool isedit = false;
        private bool ischoose = false;
        private bool ischooseall = false;
        DataSource datasource;
        private Role current_role;
        List<string> roles;
        List<string> privileges = new List<string>() {"Select","Insert","Delete","Update" };
        public Form1()
        {
            InitializeComponent();
            InitializeMyComponent();
            //Form form2 = new Form2();
            //form2.ShowDialog();
        }
        private void InitializeMyComponent()
        {
            current_role = new Role();
            datasource = new DataSource();
            lv_roles.Columns.Add("Role").Width = 150;
            lv_roles.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            //lv_roles.Columns.Add("description").Width = 200;
            lv_roles.View = View.Details;
            roles = getAllRoles();
            foreach (string role in roles)
            {
                getViewForRole(role);
            }
            //lv table
            lv_table.Columns.Add("tablename").Width = 200;
            lv_table.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_table.View = View.Details;
            //lv_privilege
            lv_privilege.Columns.Add("Privilege").Width = 100;
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
            lv_grant.Columns.Add("").Width = 30;
            lv_grant.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_grant.View = View.Details;
            lv_deny.Columns.Add("").Width = 30;
            lv_deny.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_deny.View = View.Details;
            for (int i = 0; i < privileges.Count; i++)
            {
                lv_grant.Items.Add(new ListViewItem());
                lv_deny.Items.Add(new ListViewItem());
            }
            lb_total.Text = "Total: " + roles.Count.ToString();
        }
        private List<string> getAllRoles()
        {
            List<string> my_roles = datasource.getAllObject(DataSource.role_query, "ROLE");
            return my_roles;
        }
        private void getViewForRole(string role)
        {
            ListViewItem item = new ListViewItem();
            item.Text = role;
            item.ForeColor = System.Drawing.Color.Aqua;
            item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            //item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = role.getDescribe() });
            lv_roles.Items.Add(item);
        }
        private void getViewForTable(string table)
        {
            ListViewItem item = new ListViewItem();
            item.Text = table;
            item.ForeColor = System.Drawing.Color.Aqua;
            item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_table.Items.Add(item);
        }
        private bool ExistTableAdded(string table)
        {
            foreach(ListViewItem item in lv_table.Items)
            {
                if (item.Text == table)
                {
                    return true;
                }
            }
            return false;
        }
        private void deleteRoleByName(string rolename)
        {
            datasource.deleteRoleByName(rolename);
        }
        private void getRoleByName(string rolename)
        {
            current_role.Name = rolename;
            current_role.tables.Clear();
            current_role = datasource.getRoleByName(rolename);
        }
        private void clearForm()
        {
            tb_rolename.Text = "";
            //foreach (ListViewItem item in lv_table.Items)
            //{
            //    item.Checked = false;
            //}
            lv_table.Items.Clear();
        }
        private bool existRole(string rolename,string oldrole = "")
        {
            if (!oldrole.Equals(""))
            {
                return !rolename.Equals(oldrole) && roles.Contains(rolename);
            }
            return roles.Contains(rolename);
        }
        public void Form2TPCLoseForm()
        {
            foreach(string item in Form2.mes_from_form2)
            {
                if (!ExistTableAdded(item))
                {
                    getViewForTable(item);
                    current_role.addTablePrivilege(item);
                }
            }
        }
        public void Form3TPCloseForm()
        {
            
            if (addColumn.message.Count > 0)
            {
                string tablename = lv_table.SelectedItems[0].Text;
                Table table = current_role.GetTable(tablename);
                allcheck = false;
                lv_grant.Items[lv_privilege.SelectedItems[0].Index].Checked = true;
                foreach (string col in table.columns)
                {
                    //MessageBox.Show(tablename);
                    int pri = addColumn.message.Contains(col)? Privilege.GRANT:Privilege.NONE;
                    table.editPrivilege(col, lv_privilege.SelectedItems[0].Index, pri);
                }
                allcheck = true;
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!isadd)
            {
                clearForm();
                current_role.Name = "";
                current_role.tables.Clear();
                btn_choose.Visible = false;
                btn_add.Text = "Back";
                isadd = true;
                lb_addrole.Text = "Add Role";
                container_edit.Visible = true;
                btn_col.Visible = false;
                container_privilege.Visible = false;
            }
            else
            {
                btn_add.Text = "Add";
                btn_choose.Visible = true;
                isadd = false;
                lb_addrole.Text = "";
                container_edit.Visible = false;
                btn_col.Visible = false;
                container_privilege.Visible = false;
            }
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            if (!ischoose && roles.Count > 0)
            {
                ischoose = true;
                btn_back.Visible = true;
                btn_add.Visible = false;
                btn_choose.Text = "all";
                lv_roles.CheckBoxes = true;
            }
            else if (roles.Count > 0)
            {
                if (!ischooseall)
                {
                    ischooseall = true;
                    btn_choose.Text = "Clear";
                    foreach (ListViewItem item in lv_roles.Items)
                    {
                        item.Checked = true;

                    }
                }
                else
                {
                    ischooseall = false;
                    btn_choose.Text = "all";
                    foreach (ListViewItem item in lv_roles.Items)
                    {
                        item.Checked = false;

                    }
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lv_roles.Items)
            {
                if (item.Checked)
                {
                    deleteRoleByName(item.SubItems[0].Text);
                    lv_roles.Items.Remove(item);
                }
            }
            lv_roles.CheckBoxes = false;
            ischoose = false;
            ischooseall = false;
            btn_back.Visible = false;
            btn_add.Visible = true;
            btn_choose.Text = "Choose";
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            bool t_check = false;
            current_role.Name = tb_rolename.Text;
            string t = tb_rolename.Text.ToUpper();
            t = t.Contains("C##P_") ? t : "C##P_" + t;
            if (isedit)
            {
                if (!existRole(t, lv_roles.SelectedItems[0].Text))
                {   if(datasource.updateRole(current_role, lv_roles.SelectedItems[0].Text))
                    {
                        isedit = false;
                        //todo
                        lv_roles.SelectedItems[0].Text = t;
                        t_check = true;
                    }
                }
                else
                {
                    MessageBox.Show("Role is conflicted with another role in db");
                }
            }
            else if (isadd)
            {
                //todo
                MessageBox.Show("C##P_" + tb_rolename.Text.ToUpper());
                if (!existRole(t))
                {
                    if (datasource.createRole(current_role))
                    {
                        btn_add.Text = "Add";
                        isadd = false;
                        lb_total.Text = "Total: " + roles.Count.ToString();
                        getViewForRole(current_role.Name);
                        t_check = true;
                        roles.Add(current_role.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Role is conflicted with another role in db");
                }
            }
            if (t_check)
            {
                lb_addrole.Text = "";
                btn_add.Visible = true;
                container_edit.Visible = false;
                btn_choose.Visible = true;
            }
        }

        private void btn_addtable_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void lv_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_table.SelectedItems.Count > 0)
            {
                container_privilege.Visible = true;                   
                Table table = current_role.GetTable(lv_table.SelectedItems[0].Text);
                allcheck = false;
                for (int i = 0; i < lv_privilege.Items.Count; i++)
                {
                    lv_grant.Items[i].Checked = table.checkPrivilege(Table.any, i, Privilege.GRANT);
                    lv_deny.Items[i].Checked = !lv_grant.Items[i].Checked;
                }
                allcheck = true;
            } 
        }
        private void lv_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_roles.SelectedItems.Count > 0 && !ischoose)
            {
                
                btn_choose.Visible = false;
                isadd = false;
                btn_add.Visible = false;
                lb_addrole.Text = "Edit Role";
                container_edit.Visible = true;
                btn_col.Visible = false;
                container_privilege.Visible = false;
                isedit = true;
                ListViewItem item = lv_roles.SelectedItems[0];
                ListViewItem.ListViewSubItemCollection subitem = item.SubItems;
                tb_rolename.Text = item.Text;
                lv_table.Items.Clear();
                getRoleByName(lv_roles.SelectedItems[0].Text);
                for (int i = 0; i < current_role.tables.Count; i++)
                {
                    getViewForTable(current_role.tables[i].Name);
                }
                

            }
        }
        private void lv_grant_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            count++;
            ListViewItem item = e.Item as ListViewItem;
            Table table = current_role.GetTable(lv_table.SelectedItems[0].Text);
            if(count > lv_grant.Items.Count)
            {
                //MessageBox.Show("Oke");
                if (item.Checked)
                {
                    if(item.Index == Privilege.U || item.Index == Privilege.S)
                    {
                        if(allcheck) 
                            table.editPrivilege(Table.all, item.Index, Privilege.GRANT);
                    }
                    else
                    {
                        table.editPrivilege(Table.all, item.Index, Privilege.GRANT);
                    }
                    lv_deny.Items[item.Index].Checked = false;
                }
                else
                {
                    table.editPrivilege(Table.all, item.Index, Privilege.NONE);
                }
            }
            
        }

        private void lv_deny_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            Table table = current_role.GetTable(lv_table.SelectedItems[0].Text);
            if (item.Checked)
            {
                lv_grant.Items[item.Index].Checked = false;
            }
        }

        private void lv_roles_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach(ListViewItem item in lv_roles.Items)
            {
                if (item.Checked)
                {
                    btn_back.Text = "Delete";
                    return;
                }
            }
            btn_back.Text = "Back";
        }

        private void lv_privilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lv_privilege.SelectedItems.Count > 0)
            {
                ListViewItem item = lv_privilege.SelectedItems[0];
                if (item.Index == Privilege.S  || item.Index == Privilege.U)
                {
                    btn_col.Visible = true;
                }
                else
                {
                    btn_col.Visible = false;
                }
            }
        }

        private void btn_col_Click(object sender, EventArgs e)
        {
            string type = lv_privilege.SelectedItems[0].Index == Privilege.U ?
                "UPDATE" : "SELECT"; 
            Role.table_in_select = current_role.GetTable(lv_table.SelectedItems[0].Text);
            
            Form addcolumn = new addColumn(this,type);
            addcolumn.ShowDialog();
        }
    }
}
