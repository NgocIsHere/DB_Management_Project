using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code
{
    public partial class HoSoBenhNhan : Form
    {
        public HoSoBenhNhan()
        {
            InitializeComponent();
        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HoSoBenhNhan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet.BENHAN' table. You can move, or remove it, as needed.
            //this.bENHANTableAdapter.Fill(this.pHONGKHAM_DBDataSet.BENHAN);
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet1.CUOCHEN' table. You can move, or remove it, as needed.
            //this.cUOCHENTableAdapter.Fill(this.pHONGKHAM_DBDataSet.CUOCHEN);
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet.BENHAN' table. You can move, or remove it, as needed.
            //this.bENHANTableAdapter.Fill(this.pHONGKHAM_DBDataSet.BENHAN);
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet.BENHAN' table. You can move, or remove it, as needed.
            //this.bENHANTableAdapter.Fill(this.pHONGKHAM_DBDataSet.BENHAN);
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet.CUOCHEN' table. You can move, or remove it, as needed.
            //this.cUOCHENTableAdapter.Fill(this.pHONGKHAM_DBDataSet.CUOCHEN);
            // TODO: This line of code loads data into the 'pHONGKHAM_DBDataSet1.BENHAN' table. You can move, or remove it, as needed.
            //this.bENHANTableAdapter.Fill(this.pHONGKHAM_DBDataSet.BENHAN);

        }

        private void xemtatcabenhnhanToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bENHANTableAdapter.FillBy(this.pHONGKHAM_DBDataSet.BENHAN);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.bENHANTableAdapter.FillBy(this.pHONGKHAM_DBDataSet.BENHAN);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bENHANTableAdapter.FillBy1(this.pHONGKHAM_DBDataSet.BENHAN);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
