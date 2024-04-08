using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public static List<string> mes_from_form2 = new List<string>();
        private List<string> tables;
        private DataSource ds;
        Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            InitializeMyComponent();
            
        }
        
        private void InitializeMyComponent()
        {
            ds = new DataSource();
            lv_table.Columns.Add("Role").Width = 200;
            lv_table.Font = new System.Drawing.Font("Microsoft Sans Serif",
                9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lv_table.View = View.Details;
            lv_table.CheckBoxes = true;
            tables = getAllTable();
            addTableView();
        }
        private List<string> getAllTable()
        {
            List<string> mytables = new List<string>();
            mytables = ds.getAllObject(DataSource.table_query, "TABLE_NAME");
            return mytables;
        }
        private void addTableView()
        {
            foreach(string table in tables)
            {
                ListViewItem item = new ListViewItem();
                item.Text = table;
                item.ForeColor = System.Drawing.Color.Aqua;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    9F, System.Drawing.FontStyle.Regular, System.Drawing.
                    GraphicsUnit.Point, ((byte)(163)));
                lv_table.Items.Add(item);
            } 
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void lv_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_table.SelectedItems.Count > 0)
            {
                lv_table.SelectedItems[0].Checked = !lv_table.SelectedItems[0].Checked;
            }
        }

        private void btn_aply_Click(object sender, EventArgs e)
        {
            mes_from_form2.Clear();
            foreach(ListViewItem item in lv_table.Items)
            {
                if (item.Checked)
                {
                    mes_from_form2.Add(item.Text);
                }
            }
            form1.Form2TPCLoseForm();
            //this.Close();
            this.Dispose();
        }
    }
}
