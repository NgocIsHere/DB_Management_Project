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
    public partial class Home : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.Transparent;
        Color btnSelectedtColor = Color.Teal;
        public string role;

        public Home()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButtons();
            //this.Size = new Size(1280, 720);

            //this.role = role;
        }

        private void InitializeNavigationControl()
        {
            
            /*UserList ds = new UserList(role);
            UserList1 ds0 = new UserList1();*/
            addUser addUser = new addUser();
            addRole rl = new addRole();
            // EditUser edituser = new EditUser("");
            userList usr = new userList();
            StandardAudit standardAudit = new StandardAudit();
            FGAAudit fgaAudit = new FGAAudit();
            List<UserControl> userControls = new List<UserControl>() // Your UserControl list
            {usr,addUser,rl, standardAudit, fgaAudit};

            navigationControl = new NavigationControl(userControls, content); // create an instance of NavigationControl class
            navigationControl.Display(0);
        }

        private void InitializeNavigationButtons()
        {
            List<Button> buttons = new List<Button>()
            { button1, button2, button3, standard_btn, FGA_btn};

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

        private void btn_dx_Click(object sender, EventArgs e)
        {
            Login.exit = false;
            this.Close();
        }

        private void standard_btn_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(standard_btn);
        }

        private void FGA_btn_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Highlight(FGA_btn);
        }
    } 
}