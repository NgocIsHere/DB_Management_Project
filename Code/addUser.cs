using DB_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace QLPHONGKHAM
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
            loadListView();
            loadCheckListBox();

            Connection connection = new Connection();
            connection.connect();
 
        }

        private void loadListView()
        {
            listView1.Font = new Font("Consolas", 14);


            listView1.Columns.Add("Bảng", 180);
            

            ListViewItem item1 = new ListViewItem("NHANSU");
            ListViewItem item2 = new ListViewItem("SINHVIEN");
            ListViewItem item3 = new ListViewItem("DONVI");
            ListViewItem item4 = new ListViewItem("KHMO");
            ListViewItem item5 = new ListViewItem("PHANCONG");
            ListViewItem item6 = new ListViewItem("DANGKY");

            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            listView1.Items.Add(item3);
            listView1.Items.Add(item4);
            listView1.Items.Add(item5);
            listView1.Items.Add(item6);

        }

        private void loadCheckListBox()
        {
            checkedListBox1.Font = new Font("Consolas", 14);  
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void addUser_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
            {
                //MessageBox.Show("SELECT");
            }
            else if (checkedListBox1.GetItemCheckState(0) == CheckState.Unchecked)
            {
                //MessageBox.Show("UNSELECT");
            }

            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            {
                //MessageBox.Show("UPDATE");
            }
            else if (checkedListBox1.GetItemCheckState(1) == CheckState.Unchecked)
            {
                //MessageBox.Show("UNUPDATE");
            }

            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
            {
                //MessageBox.Show("INSERT");
            }
            else if (checkedListBox1.GetItemCheckState(2) == CheckState.Unchecked)
            {
                //MessageBox.Show("UNINSERT");
            }

            if (checkedListBox1.GetItemCheckState(3) == CheckState.Checked)
            {
                //MessageBox.Show("DELETE");
            }
            else if (checkedListBox1.GetItemCheckState(3) == CheckState.Unchecked)
            {
                //MessageBox.Show("UNDELETE");
            }

            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked 
                || checkedListBox1.GetItemCheckState(1) == CheckState.Checked )
            {
                //MessageBox.Show("SELECT");
            }

        }
    }
}
