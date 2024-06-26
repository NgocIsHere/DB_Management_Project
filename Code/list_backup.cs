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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Management
{
    public partial class list_backup : UserControl
    {
        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
        public list_backup()
        {
            InitializeComponent();
        }
        
        private void button4_Click(object sender, EventArgs e)
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
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Invalid Operation: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo process để chạy lệnh RMAN
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // Gửi lệnh RMAN vào input của cmd.exe
                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine("rman target /");
                        sw.WriteLine("BACKUP PLUGGABLE DATABASE PROJECT_DBMANAGEMENT PLUS ARCHIVELOG;");
                        sw.WriteLine("exit;");
                    }
                }

                // Đọc output và lỗi (nếu có)
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                MessageBox.Show("Added Backup");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo process để chạy lệnh RMAN
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // Gửi lệnh RMAN vào input của cmd.exe
                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine("rman target /");
                        sw.WriteLine("DELETE NOPROMPT BACKUP;");
                        sw.WriteLine("exit;");
                    }
                }

                // Đọc output và lỗi (nếu có)
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                MessageBox.Show("Deleted Backup");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Error");
            }
        }
    }
}
