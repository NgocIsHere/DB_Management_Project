using Oracle.ManagedDataAccess.Client;
using System;
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
        public DataTable ParseAndDisplayBackupList(string backupList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tag", typeof(string));
            dataTable.Columns.Add("Completion Date", typeof(DateTime));

            // Define the regex patterns to match tags and completion dates
            string tagPattern = @"Tag:\s+(\S+)";
            string completionPattern = @"Ckp time:\s+(\d{1,2}-[A-Za-z]{3}-\d{2})";

            // Create regex objects
            Regex regexTag = new Regex(tagPattern);
            Regex regexCompletion = new Regex(completionPattern);

            // Match regex against the input
            MatchCollection tagMatches = regexTag.Matches(backupList);
            MatchCollection completionMatches = regexCompletion.Matches(backupList);

            // Iterate over matches and add to DataTable
            int matchCount = Math.Min(tagMatches.Count, completionMatches.Count);

            for (int i = 0; i < matchCount; i++)
            {
                string currentTag = tagMatches[i].Groups[1].Value;
                string completionDateString = completionMatches[i].Groups[1].Value;
                DateTime currentCompletionDate = DateTime.MinValue;

                if (DateTime.TryParseExact(completionDateString, "dd-MMM-yy", null, System.Globalization.DateTimeStyles.None, out currentCompletionDate))
                {
                    dataTable.Rows.Add(currentTag, currentCompletionDate);
                }
            }

            return dataTable;
        }
        private void button4_Click(object sender, EventArgs e)
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
                        sw.WriteLine("LIST BACKUP;");
                        sw.WriteLine("exit;");
                    }
                }

                // Đọc output và lỗi (nếu có)
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                string backupList = output;
                // Split backup list into individual backup sets
                string[] backupSets = backupList.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Parse backup list and get DataTable
                DataTable dataTable = ParseAndDisplayBackupList(backupList);

                // Bind DataTable to DataGridView
                dataGridViewBackupList.DataSource = dataTable;



                // Hiển thị output và lỗi (nếu có)
                /*                MessageBox.Show("Output: " + output + "\nError: " + error, "RMAN Backup Result");
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Error");
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

        private void RunRMANBackup()
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
                        sw.WriteLine("BACKUP DATABASE PLUS ARCHIVELOG;");
                        sw.WriteLine("exit;");
                    }
                }

                // Đọc output và lỗi (nếu có)
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Hiển thị output và lỗi (nếu có)
                MessageBox.Show("Output: " + output + "\nError: " + error, "RMAN Backup Result");
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
