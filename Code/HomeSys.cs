/*using DB_Management.Controls;
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;

namespace DB_Management
{
    public partial class HomeSys : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.Transparent;
        Color btnSelectedtColor = Color.Teal;
        public string role;

        public HomeSys()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButtons();
            //this.Size = new Size(1280, 720);

            //this.role = role;
        }

        private void InitializeNavigationControl()
        {

        }

        private void InitializeNavigationButtons()
        {
            List<Button> buttons = new List<Button>()
            { button1, button2, button3};
            list_backup list = new list_backup();
            recovery rcv = new recovery();
            history_recover his = new history_recover();
            List<UserControl> userControls = new List<UserControl>() // Your UserControl list
            {list, rcv, his};
            navigationControl = new NavigationControl(userControls, content);
            // create a NavigationButtons instance
            navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelectedtColor);

            // Make a default selected button
            navigationButtons.Highlight(button1);
        }

      


        private void button1_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(button1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Highlight(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Highlight(button3);
        }
    } 
}