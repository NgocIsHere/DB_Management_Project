using DB_Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (!Login.exit)
            {
                Login login = new Login();
                Login.exit = true;
                Login.role = null;


                Application.Run(login);

                if (Login.role != null)
                {
                    if (Login.role.Equals("DBA"))
                    {
                        Home dba_home = new Home();
                        Application.Run(dba_home);

                    }
                    else if (Login.role.Equals("SINHVIEN"))
                    {
                        HomeSV sv_home = new HomeSV();
                        Application.Run(sv_home);
                    }
                    else
                    {
                        PH2 pH2 = new PH2();
                        Application.Run(pH2);
                    }                
                    

                }
                

            }
            

        }
    }
}
