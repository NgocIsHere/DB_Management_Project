using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Update
{   
    public partial class Update : Form
    {
        Connection connection = new Connection();
        List<string> privileges = new List<string>();
        List<string> queries = new List<string>();

        public Update()
        {
            InitializeComponent();
            loadListView();
            loadCheckListBox();
            connection.connect();
        }   

        private void loadListView()
        {
            listView1.Font = new Font("Consolas", 14);
            listView1.Columns.Add("Table", 180);
            listView1.View = View.Details;

            listView2.View = View.Details;
            listView2.Columns.Add("Column Names", -2, HorizontalAlignment.Left);
            listView2.Font = new Font("Consolas", 14);

            ListViewItem item1 = new ListViewItem("NHANSU");
            ListViewItem item2 = new ListViewItem("SINHVIEN");
            ListViewItem item3 = new ListViewItem("DONVI");
            ListViewItem item4 = new ListViewItem("KHMO");
            ListViewItem item5 = new ListViewItem("PHANCONG");
            ListViewItem item6 = new ListViewItem("DANGKY");

            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            listView1.Items.Add(item3);
            listView1.Items.Add(item4);
            listView1.Items.Add(item5);
            listView1.Items.Add(item6);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedTable = listView1.SelectedItems[0].Text;
                loadListView2(selectedTable);
            }
        }

        private void loadCheckListBox()
        {
            checkedListBox.Font = new Font("Consolas", 14);
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (checkedListBox.GetItemCheckState(0) == CheckState.Checked
                || checkedListBox.GetItemCheckState(1) == CheckState.Checked)
            {
                listView2.Items.Clear();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        loadListView2(listView1.Items[i].Text);
                    }
                }
            }
            else if (checkedListBox.GetItemCheckState(0) == CheckState.Unchecked
                               && checkedListBox.GetItemCheckState(1) == CheckState.Unchecked)
            {
                listView2.Items.Clear();
            }
        }

        private void loadListView2(string name)
        {
            string query = $"SELECT '{name}.'||column_name FROM USER_TAB_COLUMNS WHERE table_name = '{name}'";
            Debug.WriteLine(query);

            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(0);
                        Debug.WriteLine(columnName);
                        ListViewItem item = new ListViewItem(columnName);
                        listView2.Items.Add(item);
                    }
                }
            }
        }   
           
        private void Search_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
            }

            string username = Username_Box.Text;
            string selectedTable = listView1.SelectedItems[0].Text;
            string query = $"SELECT PRIVILEGE FROM USER_TAB_PRIVS WHERE GRANTEE = '{username}' AND TABLE_NAME = '{selectedTable}'";

            using (OracleCommand cmd = new OracleCommand(query, connection.connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string privilege = reader.GetString(0);
                        for (int i = 0; i < checkedListBox.Items.Count; i++)
                        {
                            if (checkedListBox.Items[i].ToString().ToUpper() == privilege)
                            {
                                checkedListBox.SetItemCheckState(i, CheckState.Checked);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            queries.Clear();
            privileges.Clear();

            if (checkedListBox.GetItemCheckState(0) == CheckState.Checked)
            {
                privileges.Add("SELECT");
            }
            if (checkedListBox.GetItemCheckState(1) == CheckState.Checked)
            {
                privileges.Add("UPDATE");
            }
            if (checkedListBox.GetItemCheckState(2) == CheckState.Checked)
            {
                privileges.Add("INSERT");
            }
            if (checkedListBox.GetItemCheckState(3) == CheckState.Checked)
            {
                privileges.Add("DELETE");
            }

            List<string> tables = new List<string>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    tables.Add(listView1.Items[i].Text);
                }
            }

            foreach (string table in tables)
            {
                queries.Add($"REVOKE ALL PRIVILEGES ON {table} FROM {Username_Box.Text}");
                if (privileges.Count > 0)
                {
                    queries.Add($"GRANT {string.Join(", ", privileges)} ON {table} TO {Username_Box.Text}");
                }
            }

            if (listView2.Items.Count > 0 && privileges.Contains("SELECT"))
            {
                List<string> columns = new List<string>();
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Selected)
                    {
                        columns.Add(listView2.Items[i].Text);
                    }
                }
                string query = $"CREATE OR REPLACE VIEW {Username_Box.Text}_SELECT AS SELECT {string.Join(", ", columns)} FROM {string.Join(", ", tables)}";
                queries.Add(query);
                string grant = $"GRANT SELECT ON {Username_Box.Text}_SELECT TO {Username_Box.Text}";
                queries.Add(grant);
            }

            try
            {
                foreach (string query in queries)
                {
                    using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
