/*using DB_Management.Controls;
*/
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

namespace DB_Management
{
    public partial class HomeSV : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.Transparent;
        Color btnSelectedtColor = Color.Teal;
        public string role;

        public HomeSV()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButtons();
        }

        private void InitializeNavigationControl()
        {
            sv_ttcn usr = new sv_ttcn();
            sv_hocphan hp = new sv_hocphan(); 
            sv_dangky dk = new sv_dangky();
            sv_dangkyhp dkhp = new sv_dangkyhp();
            ThongBao thongBao = new ThongBao();
            List<UserControl> userControls = new List<UserControl>() // Your UserControl list
            {usr,hp, dk,dkhp, thongBao};

            navigationControl = new NavigationControl(userControls, content); // create an instance of NavigationControl class
            navigationControl.Display(0);
        }

        private void InitializeNavigationButtons()
        {
            List<Button> buttons = new List<Button>()
            { button1, button2, button3, button4};

            // create a NavigationButtons instance
            navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelectedtColor);

            // Make a default selected button
            navigationButtons.Highlight(button1);
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Highlight(button3);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(button1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Highlight(button2);
        }

        private void content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(button4);
        }

        private void btn_tb_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Highlight(btn_tb);
        }

        private void btn_dx_Click(object sender, EventArgs e)
        {
            Login.exit = false;
            this.Close();
        }
    } 
}