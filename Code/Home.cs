/*using QLPHONGKHAM.Controls;*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPHONGKHAM
{
    public partial class Home : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.Transparent;
        Color btnSelectedtColor = Color.Teal;
        public string role;
        public Home(string role)
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButtons();
            this.role = role;
        }

        private void InitializeNavigationControl()
        {
            
            UserList ds = new UserList(role);
            List<UserControl> userControls = new List<UserControl>() // Your UserControl list
            {ds,ds,ds,ds,ds};

            navigationControl = new NavigationControl(userControls, content); // create an instance of NavigationControl class
            navigationControl.Display(0);
        }

        private void InitializeNavigationButtons()
        {
            List<Button> buttons = new List<Button>()
            { thuocButton, NSButton, NVButton, LLVButton,button3};

            // create a NavigationButtons instance
            navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelectedtColor);

            // Make a default selected button
            navigationButtons.Highlight(LLVButton);
        }

        private void thuocButton_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(thuocButton);
        }

        private void NSButton_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Highlight(NSButton);
        }

        private void NVButton_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Highlight(NVButton);
        }
        private void LLVButton_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(LLVButton);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            UserList ds = new UserList(role);
            ds.Show();*/
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            /*DangNhap dn = new DangNhap();
            this.Hide();
            dn.Show();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Appointment appointment = new Appointment(role);
            this.Hide();
            appointment.Show();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*navigationControl.Display(4);
            navigationButtons.Highlight(button3);*/
        }
    } 
}