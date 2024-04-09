using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    internal class Role
    {
        public static Table table_in_select { get; set; }
        public string Name { get; set; }
        public List<Table> tables;
        public Role(string name)
        {
            Name = name;
            tables = new List<Table>();
        }
        public Role()
        {
            Name = "";
            tables = new List<Table>();
        }
        public bool existTable(string name)
        {
            foreach(Table table in tables)
            {
                if (table.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public Table GetTable(string name)
        {
            foreach (Table table in tables)
            {
                if(table.Name.Equals(name))
                {
                    return table;
                }
            }
            return null;
        }
        public void addTablePrivilege(string name)
        {
            DataSource source = new DataSource();
            List<string> columns = source.getAllObject(source.getQueryTableColumn(name), "COLUMN_NAME");
            tables.Add(new Table(name, columns));
        }
    }
}
