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
using CCT;
using Microsoft.Office.Interop.Access;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Form = System.Windows.Forms.Form;
namespace Correction
{
    public partial class CorrectionForm : Form
    {
        public string FilesPath = "";
        public string AnomalyFilePath = "";
        public string MeasuredFilePath = "";
        private string curentDir = @"";// where the exe run
        private string OutPutFolder = @"\DownScaleOut";
        private string OutputDir = "";
        Excel.Application xlAppWrite = new Excel.Application();
        private static DateTime startDate = new DateTime(2006, 01, 01);
        AllInOneForm frmParent;
        private int ttIndex;
        private int sttIndex;
        public CorrectionForm()
        {
            InitializeComponent();
           
        }

        private void CorrectionForm_Load(object sender, EventArgs e)
        {
            frmParent = (AllInOneForm)this.MdiParent;
            curentDir = System.IO.Directory.GetCurrentDirectory();
            ManualFilesTxt.Text  = StaticData.UserProjectFolder + @"\UserDatabase";
            OutputTxt.Text = StaticData.UserProjectFolder + @"\Bias-Corrected";
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function Compute Distance             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = (Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2))) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            return (dist);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function open dialog to find files  folder               :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private void FilesBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                DirectFilesTxt.Text = folderDialog.SelectedPath;

            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function open dialog to find the Measured File           :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private void MeasuredBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MeasuredTxt.Text = dialog.FileName;

            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function open dialog to find the Anomaly File            :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private void AnomalyBtn_Click(object sender, EventArgs e)
        {
            var InputBiasCorrectionFolder= StaticData.UserProjectFolder + @"\InputBiasCorrection";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = InputBiasCorrectionFolder;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AnomalyTxt.Text = dialog.FileName;

            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  It is the main Function to start                              :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private void RunBtn_Click(object sender, EventArgs e)
        {
            
            frmParent.BusyState();
            var CheckedModels = ModelChk.CheckedItems.OfType<string>().ToList();
            var CheckedSens = ScenarioChk.CheckedItems.OfType<string>().ToList();
            if (CruModel.Checked)
            {
                CheckedModels = new List<string>() { "ObservedData" };
                CheckedSens = new List<string>() { "ObservedCru" };
            }
            else if (ObserveModel.Checked)
            {
                CheckedModels = new List<string>() { "ObservedData" };
                CheckedSens = new List<string>() { "ObservedUser" };
            }
            try
            {
                commentLbl.Text = "Starting...";
                var fileFolders = "";
                if (DirectRb.Checked)
                {
                    fileFolders = DirectFilesTxt.Text;
                    MainRun(fileFolders,false);
                }
                else
                {
                    var parentFolder = ManualFilesTxt.Text;
                    foreach (var model in CheckedModels)
                    {
                        var modelDirectory = parentFolder + @"\" + model;
                        Directory.CreateDirectory(modelDirectory);
                        foreach (var senario in CheckedSens)
                        {
                            var senarioDirectory = modelDirectory + @"\" + senario;
                            Directory.CreateDirectory(senarioDirectory);
                            if (Precipitation.Checked)
                            {
                                var pcpDirectory = senarioDirectory + @"\pcp";
                                Directory.CreateDirectory(pcpDirectory);

                                MainRun(pcpDirectory,true);

                            }
                            if (Temperature.Checked)
                            {

                                var tmpDirectory = senarioDirectory + @"\tmp";
                                Directory.CreateDirectory(tmpDirectory);

                                MainRun(tmpDirectory,false);

                            }
                        }
                    }
                }
                var inputs = "";
                var models = CheckedModels.Cast<object>().Aggregate("", (current, model) => current + (model + ","));
                models =models.Length>0? models.Remove(models.Length - 1):models;
                var sens = CheckedSens.Cast<object>().Aggregate("", (current, sen) => current + (sen + ","));
                sens =sens.Length>0? sens.Remove(sens.Length - 1):sens;
                inputs += "Main Database Folder : " + Environment.NewLine + ManualFilesTxt.Text + Environment.NewLine;
                inputs += "Historic Climate Data : " + Environment.NewLine + CruModel.Checked + Environment.NewLine;
                inputs += "Future Climate Models : " + Environment.NewLine + models + Environment.NewLine;
                inputs += "Carbon Emission Scenarios : " + Environment.NewLine + sens + Environment.NewLine;
                inputs += "Precipitation : " + Environment.NewLine + Precipitation.Checked + Environment.NewLine;
                inputs += "Temperature : " + Environment.NewLine + Temperature.Checked + Environment.NewLine;
                inputs += "Output Folder  : " + Environment.NewLine + OutputTxt.Text + Environment.NewLine;
                inputs += "Simulation File : " + Environment.NewLine + AnomalyTxt.Text + Environment.NewLine;
                inputs += "Measured File : " + Environment.NewLine + MeasuredTxt.Text + Environment.NewLine;
                inputs += "Correction Method : " + Environment.NewLine + (RatioRb.Checked ? RatioRb.Text : PlusRb.Text) + Environment.NewLine;

                File.WriteAllText(ManualFilesTxt.Text.Replace(@"\UserDatabase", @"\Bias-Corrected").Replace(@"\DownScaling", @"\Bias-Corrected") + "/inputs.txt", inputs);

                MessageBox.Show("End!");
                commentLbl.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            frmParent.ReadyState(); 
        }

        private void MainRun(string FileFolders,bool isPcp)
        {
            FilesPath = FileFolders;// FilesTxt.Text;
            OutputDir = FilesPath + OutPutFolder;
            //if (OutputTxt.Text.Length > 0)
            //{
            //    OutputDir = OutputTxt.Text;
            //}
            //else
            //{
            OutputDir = FilesPath.Replace(@"\UserDatabase", @"\Bias-Corrected").Replace(@"\DownScaling", @"\Bias-Corrected");
            //}

            AnomalyFilePath = AnomalyTxt.Text;
            MeasuredFilePath = MeasuredTxt.Text;
            commentLbl.Text = "Reading Anomaly Data...";
            var anomalyData = ReadExcel(AnomalyFilePath);
            commentLbl.Text = "Reading Measured Data...";
            var measuredData = ReadExcel(MeasuredFilePath);
            commentLbl.Text = "Creating Scales...";
            var allFilesScales = new List<ScaleModel>();
            var isRatio = RatioRb.Checked;
            for (int i = 1; i < anomalyData.Count; i++)
            {
                var rowData = anomalyData[i];
                var fileLat = rowData[0];
                var fileLong = rowData[1];
                double[] fileScales = new double[12];//a scale row for all month and one file
                fileScales[0] = Convert.ToDouble(rowData[0]);//lat
                fileScales[1] = Convert.ToDouble(rowData[1]);//long

                var closerMeasuredRow = ReadCloserMeasuredRow(measuredData, fileLat, fileLong);//read closer row to this file
                for (int j = 2; j < closerMeasuredRow.Length; j++)
                {
                    var aIndex = j;// 2 + ((j - 2) * 2);
                    var mVal = Convert.ToDouble(closerMeasuredRow[j]);
                    var aVal = Convert.ToDouble(rowData[aIndex]);// Convert.ToDouble(rowData[aIndex + 1]);
                    if (isRatio)
                    {
                        if (aVal == 0)
                        {
                            if(isPcp)
                                fileScales[j - 2] = 0.1;
                            else
                                fileScales[j - 2] = 0;
                        }
                        else
                        {
                            var tempScale = mVal / aVal;
                            if(isPcp){
                                if (tempScale > 10)
                                {
                                    fileScales[j - 2] = 10;
                                }
                                else if (tempScale < 0.1)
                                {
                                    fileScales[j - 2] = 0.1;
                                }
                                else
                                {
                                    fileScales[j - 2] = tempScale;
                                }
                            }
                            else
                            {
                                fileScales[j - 2] = tempScale;
                            }
                        }

                    }
                    else
                    {
                        fileScales[j - 2] = mVal - aVal;
                    }
                }
                var scale = new ScaleModel()
                {
                    //Latitude = Convert.ToDouble(rowData[0]),
                    //Longitude = Convert.ToDouble(rowData[1]),
                    Latitude = Convert.ToDouble(fileLat),
                    Longitude = Convert.ToDouble(fileLong),
                    MonthScales = fileScales
                };
                allFilesScales.Add(scale);
            }
            ChangeFilesValue(FilesPath, allFilesScales, isRatio);
        }
        private void ChangeFilesValue(string filesPath, List<ScaleModel> allFilesScales, bool isRatio)
        {
            commentLbl.Text = "Finding Exist Files...";
            var d = Directory.CreateDirectory(filesPath);

            var files = d.GetFiles();
            if (files.Length > 0)
            {
                var isPcp = files[0].Name.IndexOf("p", StringComparison.Ordinal) > 0 ? true : false;
                var prefix = files[0].Name.Substring(files[0].Name.Length - 5);
                var isTmax = false;
                var filePositions =
                    FindFileFromName(files.Select(x => x.Name.Replace("p.txt", "").Replace("t.txt", "")).ToList());
                var query = from pos in filePositions
                            from scale in
                                allFilesScales.Where(
                                    x => pos.Latitude == x.Latitude.ToString() && pos.Longitude == x.Longitude.ToString())
                                    .Distinct()
                            select new { pos.Main, scale.MonthScales };
                var combinedDatas = query.ToList();
                if (!isPcp && (AnomalyFilePath.Contains("max") || AnomalyFilePath.Contains("tmx")))
                {

                    isTmax = true;

                }
                commentLbl.Text = "Changing Files...";
                Directory.CreateDirectory(OutputDir);
                foreach (var data in combinedDatas)
                {

                    var fileName = data.Main + prefix;
                    var monthScales = data.MonthScales;
                    DoChangeFile(filesPath, fileName, monthScales, isPcp, isTmax, isRatio);

                }
            }
        }
        private void DoChangeFile(string filesPath, string fileName, double[] monthScales, bool isPcp, bool isTmax, bool isRatio)
        {
            var fullAddress = filesPath + @"\" + fileName;
            var lines = File.ReadAllLines(fullAddress);
            var newtempFileName = OutputDir + @"\" + fileName;
            var newLines = lines;
            if (File.Exists(newtempFileName))
            {
                newLines = File.ReadAllLines(newtempFileName);
            }
            for (int i = 1; i < lines.Length; i++)
            {
                var theMonth = startDate.AddDays(i - 1).Month;
                var scale = monthScales[theMonth - 1];
                if (isPcp)
                {
                    var oldValue = Convert.ToDouble(lines[i]);
                    
                    var newValue = Math.Min(oldValue * scale,150);
                    if (!isRatio)
                    {
                        newValue = oldValue + scale;
                    }
                    if (oldValue <= -99) {
                        newValue = oldValue;
                    }
                    lines[i] = newValue.ToString("f2", CultureInfo.InvariantCulture);
                }
                else
                {
                    
                    if (isTmax)
                    {
                        var oldValue = Convert.ToDouble(lines[i].Split(',')[0]);
                        var newValue = oldValue * scale;
                        if (!isRatio)
                        {
                            newValue = oldValue + scale;
                        }
                        if (oldValue <= -99)
                        {
                            newValue = oldValue;
                        }
                        lines[i] = newValue.ToString("f2", CultureInfo.InvariantCulture) + "," + newLines[i].Split(',')[1];
                    }
                    else
                    {
                        var oldValue = Convert.ToDouble(lines[i].Split(',')[1]);
                        var newValue = oldValue * scale;
                        if (!isRatio)
                        {
                            newValue = oldValue + scale;
                        }
                        if (oldValue <= -99)
                        {
                            newValue = oldValue;
                        }
                        lines[i] = newLines[i].Split(',')[0] + "," + newValue.ToString("f2", CultureInfo.InvariantCulture);
                    }
                }


            }

            var newFileName = OutputDir + @"\" + fileName;
            File.WriteAllLines(newFileName, lines);
        }
        private List<Position> FindFileFromName(List<string> fileNames)
        {
            CruChk.Checked = CruModel.Checked || ScenarioChk.CheckedItems.Contains("Historical");
            OleDbConnection con = new OleDbConnection();
            var tblName = "PositionRecord";
            if (CruChk.Checked)
                tblName = "PositionRecord";
            if(ObserveChk.Checked || ObserveModel.Checked)
                tblName = "observePosition";
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query =
                "SELECT distinct " + tblName + ".File_Name," + tblName + ".Longitude," + tblName + ".Latitude from " + tblName + " where " + tblName + ".File_Name in ('" +
               string.Join("','", fileNames) + "')";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Main = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString()
                        }).ToList();

            con.Close();
            return list;
        }
        private string[] ReadCloserMeasuredRow(List<string[]> measuredData, string fileLat, string fileLong)
        {
            double minDistance = 100000000000000;
            string[] minRow = new string[measuredData[0].Length];
            for (int i = 1; i < measuredData.Count; i++)
            {
                var mData = measuredData[i];
                var mLat = mData[0];
                var mLong = mData[1];
                var dis = Distance(Convert.ToDouble(fileLat), Convert.ToDouble(fileLong), Convert.ToDouble(mLat), Convert.ToDouble(mLong));
                if (dis < minDistance)
                {
                    minDistance = dis;
                    minRow = mData;
                }
            }
            return minRow;
        }

        private List<string[]> ReadExcel(string path)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;



            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];

            range = xlWorkSheet.UsedRange;
            List<string[]> dataArray = new List<string[]>();//[range.Rows.Count, range.Columns.Count];
            for (int rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                string[] rows = new string[range.Columns.Count];
                for (int cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    var range1 = range.Cells[rCnt, cCnt] as Excel.Range;
                    if (range1 != null && range1.Value2 != null)
                    {
                        string str = range1.Value2.ToString();
                        //dataArray[rCnt - 1, cCnt - 1] = str;
                        rows[cCnt - 1] = str;
                    }
                    else
                    {
                        //dataArray[rCnt - 1, cCnt - 1] = "";
                        rows[cCnt - 1] = "";
                    }

                }
                dataArray.Add(rows);
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            return dataArray;
        }

        private void CruChk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OutFilesBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                OutputTxt.Text = folderDialog.SelectedPath;

            }
        }

        private void DirectRb_CheckedChanged(object sender, EventArgs e)
        {
            DirectPanel.Enabled = DirectRb.Checked;
            ManualRb.Checked = !DirectRb.Checked;
            ManualPanel.Enabled = ManualRb.Checked;
        }

        private void ManualRb_CheckedChanged(object sender, EventArgs e)
        {
            ManualPanel.Enabled = ManualRb.Checked;
            DirectRb.Checked = !ManualRb.Checked;
            DirectPanel.Enabled = DirectRb.Checked;
        }

        private void PpuFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                ManualFilesTxt.Text = folderDialog.SelectedPath;

            }
        }

        private void OutputGcd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(OutputDir);
        }

        private void CruModel_CheckedChanged(object sender, EventArgs e)
        {
            ObserveModel.Enabled = !CruModel.Checked;
            if (CruModel.Checked)
            {
                var msg = @"You probably should do bias correction for GCMs not Observed!
Are you atill want to do bias correction for ObservedCru?";

                if (MessageBox.Show(msg, "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                    DialogResult.OK)
                {
                    ObserveModel.Checked = false;
                    //ModelChk.Items.Add("ObservedData");
                    //ScenarioChk.Items.Add("ObservedCru");
                    for (int i = 0; i < ModelChk.Items.Count; i++)
                        ModelChk.SetItemChecked(i, false);
                    for (int i = 0; i < ScenarioChk.Items.Count; i++)
                        ScenarioChk.SetItemChecked(i, false);

                    //ModelChk.SetItemChecked(ModelChk.Items.Count - 1, true);
                    ModelChk.Enabled = false;
                    //ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, true);
                    ScenarioChk.Enabled = false;
                }
                else
                {
                    CruModel.Checked = false;
                }
             
            }
            else
            {
                ModelChk.Items.Remove("ObservedData");
                ScenarioChk.Items.Remove("ObservedCru");
                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, false);
                ModelChk.Enabled = true;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, false);
                ScenarioChk.Enabled = true;
            }
        }

        private void ObserveModel_CheckedChanged(object sender, EventArgs e)
        {
            CruModel.Enabled = !ObserveModel.Checked;
            if (ObserveModel.Checked)
            {           
                var msg = @"You probably should do bias correction for GCMs not Observed!
Are you atill want to do bias correction for ObservedUser?";

                if (MessageBox.Show(msg, "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                    DialogResult.OK)
                {
                    CruModel.Checked = false;
                    //ModelChk.Items.Add("ObservedData");
                    //ScenarioChk.Items.Add("ObservedUser");
                    for (int i = 0; i < ModelChk.Items.Count; i++)
                        ModelChk.SetItemChecked(i, false);
                    for (int i = 0; i < ScenarioChk.Items.Count; i++)
                        ScenarioChk.SetItemChecked(i, false);

                    //ModelChk.SetItemChecked(ModelChk.Items.Count - 1, true);
                    ModelChk.Enabled = false;
                    //ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, true);
                    ScenarioChk.Enabled = false;
                }
                else
                {
                    ObserveModel.Checked = false;
                }
            }
            else
            {
                ModelChk.Items.Remove("ObservedData");
                ScenarioChk.Items.Remove("ObservedUser");
                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, false);
                ModelChk.Enabled = true;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, false);
                ScenarioChk.Enabled = true;
            }
        }
        private void ModelChk_MouseHover(object sender, EventArgs e)
        {
            //if (ttIndex != ModelChk.IndexFromPoint(e.Location))
            GetModelToolTip();

        }
        private void ModelChk_MouseMove(object sender, MouseEventArgs e)
        {
            if (ttIndex != ModelChk.IndexFromPoint(e.Location))
                GetModelToolTip();
        }
        private void GetModelToolTip()
        {
            //foreach (var chk in ModelChk.Items)
            //{
            //    chk.Attributes.Add("title", "salam");
            //}

            ttIndex = ModelChk.IndexFromPoint(ModelChk.PointToClient(MousePosition));
            if (ttIndex > -1)
            {
                System.Drawing.Point p = PointToClient(MousePosition);
                toolTip1.ToolTipTitle = ModelChk.Items[ttIndex].ToString();
                toolTip1.SetToolTip(ModelChk, frmParent.ModelsTip[ttIndex].ToString());

            }
        }
        private void GetSenToolTip()
        {
            //foreach (var chk in ModelChk.Items)
            //{
            //    chk.Attributes.Add("title", "salam");
            //}

            sttIndex = ScenarioChk.IndexFromPoint(ScenarioChk.PointToClient(MousePosition));
            if (sttIndex > -1)
            {
                System.Drawing.Point p = PointToClient(MousePosition);
                toolTip1.ToolTipTitle = ScenarioChk.Items[sttIndex].ToString();
                toolTip1.SetToolTip(ScenarioChk, frmParent.SensTip[sttIndex].ToString());

            }
        }

        private void ScenarioChk_MouseHover(object sender, EventArgs e)
        {
            GetSenToolTip();
        }

        private void ScenarioChk_MouseMove(object sender, MouseEventArgs e)
        {
            if (sttIndex != ScenarioChk.IndexFromPoint(e.Location))
                GetSenToolTip();
        }

        private void ManualPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ObserveChk.Checked = radioButton2.Checked;
        }

    }

    public class ScaleModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double[] MonthScales { get; set; }
    }
    public class Position
    {
        public string Main { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
