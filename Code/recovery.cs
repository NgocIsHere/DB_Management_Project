using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace DB_Management
{
    public partial class recovery : UserControl
    {
        Connection connection = new Connection();
        public recovery()
        {
            InitializeComponent();

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            if(label1.Text != "Choose")
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    using (StreamWriter sw = process.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("rman target /");
                            sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT CLOSE;");
                            sw.WriteLine("RESTORE PLUGGABLE DATABASE PROJECT_DBMANAGEMENT FROM TAG = "+ label1.Text + ";");
                            sw.WriteLine("RECOVER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT;");
                            sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT OPEN;");
                            sw.WriteLine("exit;");
                        }
                    }

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    MessageBox.Show("Finished");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message, "Error");
                }
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = "SELECT TAG, COMPLETION_TIME, HANDLE FROM V$BACKUP_PIECE WHERE DELETED = 'NO' AND CON_ID = 4";
                connection.connect();
                using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                {
                    cmd.ExecuteNonQuery();
                }
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, connection.connection))
                    {
                        OracleDataReader dr = cmd.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(dr);
                        dataGridViewBackupList.DataSource = data;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("load thất bại: " + ex.Message);
                }
               
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Oracle Error: " + ex.Message);
            }
 
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                try
                {
                    using (StreamWriter sw = process.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("rman target /");
                            sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT CLOSE;");
                            sw.WriteLine("RESTORE PLUGGABLE DATABASE PROJECT_DBMANAGEMENT;");
                            sw.WriteLine("RECOVER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT;");
                            sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT OPEN;");
                            sw.WriteLine("exit;");
                        }
                    }

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    MessageBox.Show("Output: " + output + "\nError: " + error, "RMAN Backup Result");
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Error");
            }
        }

        private void dataGridViewBackupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Assuming "Tag" is the name of the column containing the tag information
                object tagValue = dataGridViewBackupList.Rows[e.RowIndex].Cells["TAG"].Value;

                // Display the tag value in label1
                if (tagValue != null)
                {
                    label1.Text = "Choose: " + tagValue.ToString();
                }
                else
                {
                    label1.Text = "Choose: ";
                }
            }
        }
    }
}
