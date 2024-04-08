using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Management
{
    internal class Table
    {
        public static string all = "all column";
        public static string any = "any column";
        public string Name { get; set; }
        public List<string> columns;
        private List<List<int>> hash;

        public Table(string name)
        {
            Name = name;
            columns = new List<string>();
            hash = new List<List<int>>();
        }
        public Table(string name, List<string> columns)
        {
            this.Name = name;
            this.columns = columns;
            hash = new List<List<int>>();
            for (int i = 0; i < columns.Count; i++)
            {
                hash.Add(new List<int>() { Privilege.NONE, Privilege.NONE,
                Privilege.NONE,Privilege.NONE});
            }
        }
        private int findColumn(string columnname)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Equals(columnname))
                {
                    return i;
                }
            }
            return -1;
        }
        public void editPrivilege(string columnname, int privilege, int option)
        {
            if (checkOption(option) && checkPrivilige(privilege))
            {
                if (columnname == all)
                {
                    for (int i = 0; i < hash.Count; i++)
                    {
                        hash[i][privilege] = option;
                    }
                }
                else
                {
                    int column = findColumn(columnname);
                    if (column >= 0)
                    {
                        hash[column][privilege] = option;
                    }
                }
            }
        }
        private bool checkPrivilige(int privilege)
        {
            if (privilege == Privilege.I || privilege == Privilege.S
                || privilege == Privilege.D || privilege == Privilege.U)
            {
                return true;
            }
            return false;
        }
        private bool checkOption(int option)
        {
            if (option == Privilege.GRANT || option == Privilege.DENY
                || option == Privilege.WITH_GRANT_OPTION ||
                option == Privilege.NONE || option == Privilege.WITH_REVOKE_OPTION)
            {
                return true;
            }
            return false;
        }
        public Privilege getPrivilege(string columnname, int privilege)
        {
            if (checkPrivilige(privilege))
            {
                int column = findColumn(columnname);
                if (column >= 0)
                {
                    return new Privilege(hash[column][privilege]);
                }
            }
            return new Privilege(-1);
        }
        public bool checkPrivilege(string columnname, int privilege, int option)
        {
            if (checkOption(option) && checkPrivilige(privilege))
            {
                if (columnname.Equals(all))
                {
                    for (int i = 0; i < hash.Count; i++)
                    {
                        if (option == Privilege.GRANT)
                        {
                            if (hash[i][privilege] != Privilege.GRANT &&
                                hash[i][privilege] != Privilege.WITH_GRANT_OPTION)
                            {
                                return false;
                            }
                        }
                        else if (hash[i][privilege] != option)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else if (columnname.Equals(any))
                {
                    for (int i = 0; i < hash.Count; i++)
                    {
                        if (option == Privilege.GRANT)
                        {
                            if (hash[i][privilege] == Privilege.GRANT ||
                                hash[i][privilege] == Privilege.WITH_GRANT_OPTION)
                            {
                                return true;
                            }
                        }
                        else if (hash[i][privilege] == option)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    int column = findColumn(columnname);
                    return hash[column][privilege] == option;
                }
            }
            return false;
        }
    }
}
