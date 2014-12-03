using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SearchServiceLogs
{
    public partial class frmSearchServiceLogs : Form
    {
        public frmSearchServiceLogs()
        {
            _LogfilesDirectory = string.Empty;
            _ExportfileDirectory = string.Empty;
            InitializeComponent();
            cbDeviceType.SelectedIndex = 0;
            lblExportDirectoryLabel.Visible = lbloutputDirectoryPath.Visible = btnSetOutputFilePath.Visible = false;
        }
        public string _LogfilesDirectory { get; set; }
        public string _ExportfileDirectory { get; set; }
        DataTable dtSearchResults = null;
        DataTable dtTempSearchResults = null;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_LogfilesDirectory != string.Empty && cbDeviceType.SelectedIndex != -1 && cbDeviceType.SelectedIndex != 0)
            {
                //Create a New Data table to store search results data per client
                dtSearchResults = GetTable("Result");
                dtTempSearchResults = GetTable("TempResult");

                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(_LogfilesDirectory);
                DirectoryInfo[] dirs = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);
                lblStats.Text = DateTime.Now.ToString("hh:mm:ss");
                if (dir.Exists)
                {
                    foreach (DirectoryInfo subDirectory in dirs)
                    {
                        //String List object to store all the Match line for each client
                        List<string> sbSearchLinePerClient = new List<string>();

                        ////Add Directory Name which would be Client Name to result Data Table
                        //dtSearchResults.Rows.Add(subDirectory.Name, string.Empty, string.Empty, string.Empty);

                        // Get the files with name "SEDCSmartAppsService_*" in the directory and pull the lines that match the Search text
                        FileInfo[] files = subDirectory.GetFiles("SEDCSmartAppsService_*", SearchOption.TopDirectoryOnly);
                        foreach (FileInfo file in files)
                        {
                            sbSearchLinePerClient.AddRange(ReturnMatchLines(file.FullName, cbDeviceType.SelectedIndex, string.Empty));


                            //Parse all the lines we get for each Client
                            if (sbSearchLinePerClient.Count > 0)
                            {
                                foreach (string line in sbSearchLinePerClient.ToArray())
                                {
                                    if (line.IndexOf("<hardwareid>") != -1 && line.IndexOf("</PushNotifyType>") != -1)
                                    {
                                        try
                                        {
                                            string strFinal = line.Substring(line.IndexOf("<hardwareid>"), line.IndexOf("</PushNotifyType>") - line.IndexOf("<hardwareid>") + 17);
                                            XmlDocument objXMLDoc = new XmlDocument();
                                            objXMLDoc.LoadXml("<Data>" + strFinal.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("\'", "&apos;") + "</Data>");

                                            string hardwareId = objXMLDoc.SelectSingleNode("Data/hardwareid").InnerText;
                                            var foundHardwareID = dtSearchResults.Select("HardwareID = '" + hardwareId + "'");
                                            if (foundHardwareID.Length == 0)
                                            {
                                                //Add IOS Version & Profile Details to result Data Table
                                                dtSearchResults.Rows.Add(subDirectory.Name, objXMLDoc.SelectSingleNode("Data/profilename").InnerText.Replace("&amp;", "&").Replace("&quot;", "\"").Replace("&apos;", "\'"),
                                                    objXMLDoc.SelectSingleNode("Data/osversion").InnerText, objXMLDoc.SelectSingleNode("Data/appversion").InnerText, hardwareId);
                                                dtTempSearchResults.Rows.Add(subDirectory.Name, objXMLDoc.SelectSingleNode("Data/profilename").InnerText.Replace("&amp;", "&").Replace("&quot;", "\"").Replace("&apos;", "\'"),
                                                    objXMLDoc.SelectSingleNode("Data/osversion").InnerText, objXMLDoc.SelectSingleNode("Data/appversion").InnerText, hardwareId);
                                            }

                                        }
                                        catch (Exception Ex)
                                        {
                                            MessageBox.Show("There was an error occurred while processing Log Files for client :-" + subDirectory.Name + "  File Name:-" + file.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            sbSearchLinePerClient.Clear();
                        }
                        ////Add a Blank line after Each Client
                        //dtSearchResults.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);

                        //Write to File after per Client reading
                        if (chkExportResults.Checked && !_ExportfileDirectory.Equals(string.Empty))
                        {
                            using (StreamWriter writer = new StreamWriter(_ExportfileDirectory,true))
                            {
                                WriteDataTable(dtTempSearchResults, writer, false);
                                dtTempSearchResults.Clear();
                            }
                        }
                    }
                    if (dtSearchResults.Rows.Count > 0)
                    {
                        dgvSearchResults.DataSource = dtSearchResults;
                    }
                    lblStats.Text += " / " + DateTime.Now.ToString("hh:mm:ss");
                    if (chkExportResults.Checked)
                        MessageBox.Show("File exported successfully!" + "\r\n"+"File Path:-"+_ExportfileDirectory, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (_LogfilesDirectory == string.Empty)
                    MessageBox.Show("Please select Directory path for Log Files!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbDeviceType.SelectedIndex == -1 || cbDeviceType.SelectedIndex == 0)
                    MessageBox.Show("Please select Device Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private string[] ReturnMatchLines(string filePath, int Devicetype, string subString)
        {
            //Devicetype=1 for Iphone and Devicetype=2 for Android
            List<string> matchLines = new List<string>();
            if (Devicetype == 1)
            {
                foreach (var match in File.ReadLines(filePath)
                                 .Select((text, index) => new { text, lineNumber = index + 1 })
                                 .Where(x => x.text.Contains("<PushNotifyType>APNS</PushNotifyType>")))
                {
                    matchLines.Add(match.text);
                }
            }
            else if (Devicetype == 2)
            {
                foreach (var match in File.ReadLines(filePath)
                                 .Select((text, index) => new { text, lineNumber = index + 1 })
                                 .Where(x => (x.text.Contains("<PushNotifyType>GCM</PushNotifyType>") || x.text.Contains("<PushNotifyType>CDMA</PushNotifyType>"))))
                {
                    matchLines.Add(match.text);
                }
            }
            return matchLines.ToArray();
        }

        private DataTable GetTable(string tblName)
        {
            // Here we create a DataTable with columns.
            DataTable table = new DataTable(tblName);
            table.Columns.Add("Client Name", typeof(string));
            table.Columns.Add("Profile Name", typeof(string));
            table.Columns.Add("IOS Version", typeof(string));
            table.Columns.Add("App Version", typeof(string));
            table.Columns.Add("HardwareID", typeof(string));

            return table;
        }

        private void btnSetDirectoryPath_Click(object sender, EventArgs e)
        {

            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _LogfilesDirectory = dlg.SelectedPath;
                    lblDirectoryPath.Text = _LogfilesDirectory;
                    MessageBox.Show("Directory path for Log Files selected!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void ExportGrid(DataGridView dGV, string filename)
        {
            string stOutput = "";
            //// Export titles:
            //string sHeaders = "";

            //for (int j = 0; j < dGV.Columns.Count; j++)
            //    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + ",";
            //stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + ",";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }
        public static void WriteDataTable(DataTable sourceTable, TextWriter writer, bool includeHeaders)
        {
            if (includeHeaders)
            {
                List<string> headerValues = new List<string>();
                foreach (DataColumn column in sourceTable.Columns)
                {
                    headerValues.Add(QuoteValue(column.ColumnName));
                }

                writer.WriteLine(String.Join(",", headerValues.ToArray()));
            }

            string[] items = null;
            foreach (DataRow row in sourceTable.Rows)
            {
                items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();
                writer.WriteLine(String.Join(",", items));
            }

            writer.Flush();
        }

        private static string QuoteValue(string value)
        {
            return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = "export.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportGrid(dgvSearchResults, sfd.FileName);
                MessageBox.Show("File exported successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblDirectoryPath_DoubleClick(object sender, EventArgs e)
        {
            if (!lblStats.Visible)
                lblStats.Visible = true;
            else
                lblStats.Visible = false;
        }

        private void btnSetOutputFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _ExportfileDirectory = sfd.FileName;
                    lbloutputDirectoryPath.Text = _ExportfileDirectory;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void chkExportResults_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkExportResults.Checked)
            {
                lblExportDirectoryLabel.Visible = lbloutputDirectoryPath.Visible = btnSetOutputFilePath.Visible = true;
            }
            else
            {
                lblExportDirectoryLabel.Visible = lbloutputDirectoryPath.Visible = btnSetOutputFilePath.Visible = false;
            }
        }


    }
}
