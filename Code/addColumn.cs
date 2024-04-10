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
    public partial class addColumn : Form
    {
        addRole form;
        public static List<string> message = new List<string>();
        private List<string> columns;
        private DataSource ds;
        private Table table;
        private string option;
        public addColumn(addRole form, string option)
        {
            InitializeComponent();
            this.form = form;
            this.table = Role.table_in_select;
            this.option = option;
            InitializeMyComponent();
        }
        private void InitializeMyComponent()
        {
            ds = new DataSource();
            lv_column.Columns.Add("Role").Width = 200;
            lv_column.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_column.View = View.Details;
            lv_column.CheckBoxes = true;
            columns = table.columns;
            addColumnView();
        }

        private void addColumnView()
        {
            //List<string> checkColumn = ds.getAllObject(ds.getQueryColumnForm(tablename, rolename, type),"COLUMN_NAME");
            foreach (string col in columns)
            {
                ListViewItem item = new ListViewItem();
                item.Text = col;
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                lv_column.Items.Add(item);
                int privilige = option == "SELECT" ? Privilege.S : Privilege.U;
                item.Checked = table.checkPrivilege(col, privilige, Privilege.GRANT);
            }
        }
        private void lv_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_column.SelectedItems.Count > 0)
            {
                lv_column.SelectedItems[0].Checked = !lv_column.SelectedItems[0].Checked;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            message.Clear();
            foreach (ListViewItem item in lv_column.Items)
            {
                if (item.Checked)
                {
                    message.Add(item.Text);
                }
            }
            form.Form3TPCloseForm();

            //this.Close();
            this.Dispose();
        }
    }
}
