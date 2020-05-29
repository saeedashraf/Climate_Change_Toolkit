using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllInOne;
using CCDA;
using CCT;
using Microsoft.Office.Interop.Excel;
using ppu;
using DataTable = System.Data.DataTable;

namespace CCDAWinApp
{
    public partial class CCDA : Form
    {
        private string inputPath = @"D:\GCD\GlobalModelData";
        private string outputPath = @"D:\GCD\GlobalModelData\Outputs";
        private string curentDir = @"";// where the exe run
        private string month = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec";
        private int year = 2004;
        private static DateTime inputStartDate = new DateTime(2006, 01, 01);
        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        public CCDA()
        {
            InitializeComponent();
        }

        private void PpuFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt|All Files |*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ppuFileTxt.Text = openFileDialog1.FileName;
            }
        }

        private void PpuOutputBtn_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ppuOutputTxt.Text = folderBrowserDialog1.SelectedPath;
                cdaInputTxt.Text = folderBrowserDialog1.SelectedPath;
                cdaOutputTxt.Text = folderBrowserDialog1.SelectedPath + @"\output";
            }
        }

        private void RunPPUBtn_Click(object sender, EventArgs e)
        {
            AllInOneForm frmParent = (AllInOneForm)this.MdiParent;
            frmParent.BusyState(); 
            try
            {

                var fileName = ppuFileTxt.Text;
                var steps = Convert.ToInt32(StepTxt.Text);
                var zones = Convert.ToInt32(ZoneTxt.Text);
                var variables = Convert.ToInt32(VarsTxt.Text);
                var path = ppuOutputTxt.Text;
                if (String.IsNullOrEmpty(path))
                {
                    path = fileName.Split(new[] { @"\InputCCDA" }, StringSplitOptions.None).FirstOrDefault();
                    path = path + @"\CCDA\PPU";
                    ppuOutputTxt.Text = path;
                }
                PpuManager.path = path;
                PpuManager.fileName = fileName;
                PpuManager.ReadPpu(steps, zones, variables);
                var inputs = "";

                inputs += "Number of time steps : " + Environment.NewLine + StepTxt.Text + Environment.NewLine;
                inputs += "Number of SUBs/HRUs : " + Environment.NewLine + ZoneTxt.Text + Environment.NewLine;
                inputs += "Number of variables : " + Environment.NewLine + VarsTxt.Text + Environment.NewLine;

                File.WriteAllText(path + "/inputs.txt", inputs);

                MessageBox.Show("execute successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            frmParent.ReadyState(); 


        }

        private void OpenOutputBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ppuOutputTxt.Text);
        }

        private void cdaInputBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                cdaInputTxt.Text = folderBrowserDialog1.SelectedPath;
                cdaOutputTxt.Text = folderBrowserDialog1.SelectedPath + @"\output";
            }
        }

        private void cdaOutputBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                cdaOutputTxt.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cdaOpenOutput_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(cdaOutputTxt.Text);
        }

        private void cdaRunBtn_Click(object sender, EventArgs e)
        {
            AllInOneForm frmParent = (AllInOneForm)this.MdiParent;
            frmParent.BusyState(); 
            try
            {

                var preName = PreNameTxt.Text;
                var daysCount = Convert.ToInt32(DaysTxt.Text);
                var point = PointsTxt.Text;
                var startDate = dateTimePicker1.Value;
                var priodStartDate = PriodStartDate.Value;
                var priodEndDate = PriodEndDate.Value;
                var opr = oprTxt.Text;
                var path = cdaInputTxt.Text;
                var outputPath = cdaOutputTxt.Text;
                var sumCheck = SumChk.Checked;
                var totalsTxt = TotalsTxt.Text;
                if (String.IsNullOrEmpty(outputPath))
                {
                    outputPath = path.Split(new[] { @"\InputCCDA" }, StringSplitOptions.None).FirstOrDefault();
                    outputPath = outputPath + @"\CCDA\CCDA";
                    cdaOutputTxt.Text = outputPath;
                }
                AnalyzeManager.path = path;
                AnalyzeManager.outPath = outputPath;
                AnalyzeManager.Analyze(daysCount, preName, point, startDate, opr, priodStartDate, priodEndDate, sumCheck, totalsTxt);

                var inputs = "";

                inputs += "Variables Names : " + Environment.NewLine + preName + Environment.NewLine;
                inputs += "File Start Date : " + Environment.NewLine + dateTimePicker1.Text + Environment.NewLine;
                inputs += "Priod Start Date : " + Environment.NewLine + PriodStartDate.Text + Environment.NewLine;
                inputs += "Priod End Date : " + Environment.NewLine + PriodEndDate.Text + Environment.NewLine;
                inputs += "Critical Length : " + Environment.NewLine + DaysTxt.Text + Environment.NewLine;
                inputs += "Variable Thresholds : " + Environment.NewLine + PointsTxt.Text + Environment.NewLine;
                inputs += "Operation : " + Environment.NewLine + PriodStartDate.Text + Environment.NewLine;
                inputs += "Priod End Date : " + Environment.NewLine + oprTxt.Text + Environment.NewLine;


                File.WriteAllText(outputPath + "/inputs.txt", inputs);
                MessageBox.Show("execute successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            frmParent.ReadyState(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cdaInputTxt.Text = StaticData.UserProjectFolder + @"\InputCCDA\DataAnalyzer";
            cdaOutputTxt.Text = StaticData.UserProjectFolder + @"\InputCCDA\DataAnalyzerOutput";

            FileTxt.Text = StaticData.UserProjectFolder + @"\UserDatabase";
            OutputTxt.Text = StaticData.UserProjectFolder + @"\InputCCDA";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ZoneTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void CcdaBtn_Click(object sender, EventArgs e)
        {
            curentDir = System.IO.Directory.GetCurrentDirectory();
            outputPath = OutputTxt.Text;
            inputPath = FileTxt.Text;
            List<string> fileList = null;
            if (SelectedArea.Checked)
            {
                var LatitudeFrom = Convert.ToDouble(LatFrom.Text);
                var LongitudeFrom = Convert.ToDouble(LongFrom.Text);
                var LatitudeTo = Convert.ToDouble(LatTo.Text);
                var LongitudeTo = Convert.ToDouble(LongTo.Text);
                if (CruModel.Checked)
                    fileList = FindFileNamesCru(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
                else
                    fileList = FindFileNames(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
            }
            var startPeriod = new DateTime(2006, 1, 1);
            var endPeriod = new DateTime(2099, 12, 31);
            if (SelectedPeriod.Checked)
            {
                startPeriod = SimStartDate.Value;
                endPeriod = SimEndDate.Value;
            }
            var outputPathCCDA = outputPath;// + @"\InputCCDA";
            Directory.CreateDirectory(outputPathCCDA);
            Directory.CreateDirectory(outputPathCCDA + @"\DataAnalyzer");
            Directory.CreateDirectory(outputPathCCDA + @"\DataAnalyzerOutput");
            List<Position> oldNewName = new List<Position>();
            foreach (var model in ModelChk.CheckedItems)
            {
                var modelDirectory = outputPathCCDA + @"\" + model;
                Directory.CreateDirectory(modelDirectory);
                foreach (var senario in ScenarioChk.CheckedItems)
                {
                    var senarioDirectory = modelDirectory + @"\" + senario;
                    Directory.CreateDirectory(senarioDirectory);
                    if (Precipitation.Checked)
                    {
                        var pcpDirectory = senarioDirectory + @"\pcp\";
                        Directory.CreateDirectory(pcpDirectory);

                        ReportCcda(pcpDirectory, model.ToString(), senario.ToString(), true, "", fileList, startPeriod, endPeriod, ref  oldNewName);

                    }
                    if (Temperature.Checked)
                    {
                        var tmpDirectory = senarioDirectory + "/tmp/";
                        Directory.CreateDirectory(tmpDirectory);

                        ReportCcda(tmpDirectory, model.ToString(), senario.ToString(), false, "max_", fileList,
                                startPeriod, endPeriod, ref oldNewName);
                        ReportCcda(tmpDirectory, model.ToString(), senario.ToString(), false, "min_", fileList,
                                startPeriod, endPeriod, ref oldNewName);

                    }
                }
            }
            SaveSummeryCcdaToExcel(oldNewName);
            // MessageBox.Show("End!");
        }
        private List<string> FindFileNames(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query = "select File_name from PositionRecord where (Latitude>=" + LatitudeFrom +
                           " and Longitude>=" + LongitudeFrom + " and  Latitude<=" + LatitudeTo +
                           " and Longitude<=" + LongitudeTo + ")";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            var list = (from DataRow row in dt.Rows
                        select row["File_name"].ToString()).ToList();
            con.Close();
            return list;
        }
        private List<string> FindFileNamesCru(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query = "select File_name from cruPosition where (Latitude>=" + LatitudeFrom +
                           " and Longitude>=" + LongitudeFrom + " and  Latitude<=" + LatitudeTo +
                           " and Longitude<=" + LongitudeTo + ")";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            var list = (from DataRow row in dt.Rows
                        select row["File_name"].ToString()).ToList();
            con.Close();
            return list;
        }

        private void SaveSummeryCcdaToExcel(List<Position> oldNewName)
        {
            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            ws.Cells[1, 1] = "Latitude";
            ws.Cells[1, 2] = "Longitude";
            ws.Cells[1, 3] = "oldName";
            ws.Cells[1, 4] = "newName";

            for (int i = 0; i < oldNewName.Count; i++)
            {
                ws.Cells[i + 2, 1] = oldNewName[i].Latitude;
                ws.Cells[i + 2, 2] = oldNewName[i].Longitude;
                ws.Cells[i + 2, 3] = oldNewName[i].Main;
                ws.Cells[i + 2, 4] = oldNewName[i].Cru;
            }
            var filePath = outputPath + @"\CCDASummery.xlsx";
            ws.SaveAs(filePath);
            wb.Close();
        }

        private void ReportCcda(string directory, string model, string senario, bool isPcp, string prefix, List<string> acceptFiles, DateTime startPeriod, DateTime endPeriod, ref  List<Position> oldNewName)
        {
            var theDir = inputPath + directory.Split(new[] { @"\InputCCDA" }, StringSplitOptions.None).LastOrDefault();
            var d = Directory.CreateDirectory(theDir);// Directory.CreateDirectory(directory.Replace(@"\InputCCDA", ""));
            var Files = d.GetFiles();
            if (acceptFiles != null)
            {
                Files = Files.Where(x => acceptFiles.Any(y => y == x.Name.Replace("p.txt", "").Replace("t.txt", ""))).ToArray();
            }
            var fileIndex = 0;
            List<string> fileNames = Files.Select(x => x.Name.Replace("p.txt", "").Replace("t.txt", "")).ToList();
            List<Position> filePositions = new List<Position>();
            if (CruModel.Checked)
            {

                filePositions = FindFileFromNameCru(fileNames);
            }
            else
            {
                filePositions = FindFileFromName(fileNames);
            }
            foreach (var file in Files)
            {

                double[,] dt = new double[95, 13];
                var lines = File.ReadAllLines(file.FullName);
                var firstLine = (startPeriod - inputStartDate).Days + 1;
                var lastLine = (endPeriod - inputStartDate).Days + 1;
                var mounthCounter = startPeriod.Month;
                var yearIndex = startPeriod.Year - inputStartDate.Year;
                var curDate = startPeriod;
                double totalMonth = 0;
                double totalYear = 0;
                lastLine = lastLine + 2 > lines.Length ? lines.Length : lastLine + 2;
                var theIndex = 0;
                var ccdaLines = new string[lastLine + 1 - firstLine];
                ccdaLines[0] = file.Name;
                for (int i = firstLine; i < lastLine; i++)
                {
                    if (!isPcp)
                    {
                        if (prefix == "max_")
                        {
                            lines[i] = lines[i].Split(',')[0];
                        }
                        else
                        {
                            lines[i] = lines[i].Split(',')[1];
                        }

                    }
                    ccdaLines[theIndex + 1] = (theIndex + 1).ToString() + "\t" + Convert.ToDouble(lines[i]).ToString("f2", CultureInfo.InvariantCulture);
                    theIndex++;
                }


                var PreFileName = "PCP_";
                if (!isPcp)
                {
                    if (prefix == "max_")
                    {
                        PreFileName = "TMX_";
                    }
                    else
                    {
                        PreFileName = "TMN_";
                    }
                }
                //var fileName = model + "_" + senario + "_" + prefix + file.Name;
                fileIndex++;
                var fileName = PreFileName + fileIndex + ".txt";
                var theFile = filePositions.SingleOrDefault(x => x.Main == file.Name.Replace("p.txt", "").Replace("t.txt", ""));
                if (theFile != null)
                {
                    theFile.Main = file.Name;
                    theFile.Cru = fileName;
                    oldNewName.Add(theFile);
                }
                File.WriteAllLines(directory + @"\" + fileName, ccdaLines);

            }
        }


        private List<Position> FindFileFromName(List<string> fileNames)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query =
                "SELECT distinct PositionRecord.File_Name,PositionRecord.Longitude,PositionRecord.Latitude from PositionRecord where PositionRecord.File_Name in ('" +
               string.Join("','", fileNames) + "')";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Cru = "",
                            Main = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString()
                        }).ToList();

            con.Close();
            return list;
        }
        private List<Position> FindFileFromNameCru(List<string> fileNames)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query =
                "SELECT distinct cruPosition.File_Name,cruPosition.Longitude,cruPosition.Latitude from cruPosition where cruPosition.File_Name in ('" +
               string.Join("','", fileNames) + "')";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Cru = "",
                            Main = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString()
                        }).ToList();

            con.Close();
            return list;
        }

        private void twoBtn_Click(object sender, EventArgs e)
        {
            AllInOneForm frmParent = (AllInOneForm)this.MdiParent;
            frmParent.BusyState(); 
            try
            {
                CcdaBtn_Click(sender, e);
                MessageBox.Show("End!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            frmParent.ReadyState(); 
        }

        private void OutputGcd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputPath);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                FileTxt.Text = folderDialog.SelectedPath;

            }
        }

        private void CruModel_CheckedChanged(object sender, EventArgs e)
        {
            if (CruModel.Checked)
            {
                ModelChk.Items.Add("HistoricData");
                ScenarioChk.Items.Add("HistoricData");
                for (int i = 0; i < ModelChk.Items.Count - 1; i++)
                    ModelChk.SetItemChecked(i, false);
                for (int i = 0; i < ScenarioChk.Items.Count - 1; i++)
                    ScenarioChk.SetItemChecked(i, false);

                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, true);
                ModelChk.Enabled = false;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, true);
                ScenarioChk.Enabled = false;
            }
            else
            {
                ModelChk.Items.Remove("HistoricData");
                ScenarioChk.Items.Remove("HistoricData");
                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, false);
                ModelChk.Enabled = true;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, false);
                ScenarioChk.Enabled = true;
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void SumChk_CheckedChanged(object sender, EventArgs e)
        {
            TotalsTxt.Enabled = SumChk.Checked;
        }
    }
}
