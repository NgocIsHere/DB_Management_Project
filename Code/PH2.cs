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
    public partial class PH2 : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.Transparent;
        Color btnSelectedtColor = Color.Teal;
        public string role;

        public PH2()
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
            // tao  cac man hinh
            //addUser addUser = new addUser();

            // EditUser edituser = new EditUser("");
            PhanCong phanCong = new PhanCong();
            DangKy dangKy = new DangKy();
            donvi dv = new donvi();
            hocphan hp = new hocphan();
            khmo k = new khmo();
            List<UserControl> userControls = new List<UserControl>() // Your UserControl list
            {dangKy,phanCong,dv,hp,dangKy,phanCong,k };

            navigationControl = new NavigationControl(userControls, content); // create an instance of NavigationControl class
            navigationControl.Display(0);
        }

        private void InitializeNavigationButtons()
        {
            List<Button> buttons = new List<Button>()
            { btn_nhansu,btn_sv,btn_donvi,btn_hp,btn_dangky,btn_phancong,btn_khm};

            // create a NavigationButtons instance
            navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelectedtColor);

            // Make a default selected button
            navigationButtons.Highlight(btn_nhansu);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Highlight(btn_donvi);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(btn_nhansu);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Highlight(btn_sv);
        }

        private void content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_hp_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(btn_hp);
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Highlight(btn_dangky);
        }

        private void btn_phancong_Click(object sender, EventArgs e)
        {
            navigationControl.Display(5);
            navigationButtons.Highlight(btn_phancong);
        }

        private void btn_khm_Click(object sender, EventArgs e)
        {
            navigationControl.Display(6);
            navigationButtons.Highlight(btn_khm);
        }
    }
}