/*using DB_Management.Controls;*/
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
            { button1, button2, button3};

            // create a NavigationButtons instance
            navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelectedtColor);

            // Make a default selected button
            navigationButtons.Highlight(button1);
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Highlight(button3);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(button1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(button2);
        }

       
    } 
}