using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Management
{
    internal class Privilege
    {
        public static int GRANT = 10;
        public static int NONE = 20;
        public static int DENY = 30;
        public static int WITH_GRANT_OPTION = 40;
        public static int WITH_REVOKE_OPTION = 50;

        public static int S = 0;
        public static int I = 1;
        public static int D = 2;
        public static int U = 3;

        public static string Select = "Select";
        public static string Insert = "Insert";
        public static string Delete = "Delete";
        public static string Update = "Update";

        int privilege { get; set; }
        public Privilege(int privilege)
        {
            this.privilege = privilege;
        }
    }
}
