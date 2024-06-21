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
using System.Windows.Shapes;

namespace DB_Management
{
    public partial class recovery : UserControl
    {
        Connection connection = new Connection();
        string admin = "ADMIN_OLS";
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
                            sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT CLOSE;");
                            sw.WriteLine("RESTORE PLUGGABLE DATABASE PROJECT_DBMANAGEMENT FROM TAG = "+ label1.Text + ";");
                            sw.WriteLine("RECOVER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT;");
                            sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT OPEN;");
                            sw.WriteLine("exit;");
                        }
                    }

                    // Đọc output và lỗi (nếu có)
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (error == null)
                    {
                        MessageBox.Show("Finished");

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message, "Error");
                }
            }
            
        }
        public DataTable ParseAndDisplayBackupList(string backupList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tag", typeof(string));
            dataTable.Columns.Add("Completion Date", typeof(DateTime));
            dataTable.Columns.Add("Piece Name", typeof(string));

            // Define the regex patterns to match tags and completion dates
            string tagPattern = @"Tag:\s+(\S+)";
            string completionPattern = @"Ckp time:\s+(\d{1,2}-[A-Za-z]{3}-\d{2})";
            string pieceNamePattern = @"Piece Name:\s+(.*)";
            // Create regex objects
            Regex regexTag = new Regex(tagPattern);
            Regex regexCompletion = new Regex(completionPattern);
            Regex regexPieceName = new Regex(pieceNamePattern);

            // Match regex against the input
            MatchCollection tagMatches = regexTag.Matches(backupList);
            MatchCollection completionMatches = regexCompletion.Matches(backupList);
            MatchCollection pieceMatches = regexPieceName.Matches(backupList);

            // Iterate over matches and add to DataTable
            int matchCount = Math.Min(tagMatches.Count, completionMatches.Count);

            for (int i = 0; i < matchCount; i++)
            {

                string extractedSubstring = tagMatches[i].Groups[1].Value.Substring(12);
                int intValue = Convert.ToInt32(extractedSubstring) + 2;
                string currentTag = tagMatches[i].Groups[1].Value.Substring(0, 12) + intValue.ToString();

                string completionDateString = completionMatches[i].Groups[1].Value;
                string pieceString = pieceMatches[i].Groups[1].Value;
                DateTime currentCompletionDate = DateTime.MinValue;

                if (DateTime.TryParseExact(completionDateString, "dd-MMM-yy", null, System.Globalization.DateTimeStyles.None, out currentCompletionDate))
                {
                    dataTable.Rows.Add(currentTag, currentCompletionDate, pieceString);
                }
            }

            return dataTable;
        }
        private void button2_Click(object sender, EventArgs e)
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

        private void dataGridViewBackupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row is clicked (ignore header row)
            if (e.RowIndex >= 0)
            {
                // Assuming "Tag" is the name of the column containing the tag information
                object tagValue = dataGridViewBackupList.Rows[e.RowIndex].Cells["Tag"].Value;

                // Display the tag value in label1
                if (tagValue != null)
                {
                    label1.Text = "Choose: " + tagValue.ToString();
                }
                else
                {
                    label1.Text = string.Empty; // or handle null case as per your requirement
                }
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
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
                        sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT CLOSE;");
                        sw.WriteLine("RESTORE PLUGGABLE DATABASE PROJECT_DBMANAGEMENT;");
                        sw.WriteLine("RECOVER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT;");
                        sw.WriteLine("ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT OPEN;");
                        sw.WriteLine("exit;");
                    }
                }

                // Đọc output và lỗi (nếu có)
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                if (error == null)
                {
                    MessageBox.Show("Finished");

                }
                else
                {
                    MessageBox.Show("Error");
                }
                /*                // Hiển thị output và lỗi (nếu có)
                                MessageBox.Show("Output: " + output + "\nError: " + error, "RMAN Backup Result");
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Error");
            }
        }
    }
}
