using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllInOne;
using Microsoft.Office.Interop.Access;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Form = System.Windows.Forms.Form;

namespace CCT
{

    public partial class CctMain : Form
    {
        private string inputPath = @"D:\GCD\GlobalModelData";
        private string outputPath = @"D:\GCD\GlobalModelData\Outputs";
        private string curentDir = @"";// where the exe run
        private string month = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec";
        AllInOneForm frmParent;
        private int year = 2004;
        private static DateTime startDate = new DateTime(2006, 01, 01);
        private int ttIndex;
        private int sttIndex;
        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();


        public CctMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmParent = (AllInOneForm)this.MdiParent;
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

        private List<string> FindFileNamesObserve(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query = "select File_name from observePosition where (Latitude>=" + LatitudeFrom +
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
        private List<Position> FindFileFromNameObserve(List<string> fileNames)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query =
                "SELECT distinct observePosition.File_Name,observePosition.Longitude,observePosition.Latitude from observePosition where observePosition.File_Name in ('" +
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

        private void PpuFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                FileTxt.Text = folderDialog.SelectedPath;

            }
        }



        private void OutputGcd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputPath);
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
            var filePath = outputPath + @"\InputCCDA\CCDASummery.xlsx";
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
            if (CruModel.Checked || ScenarioChk.CheckedItems.Contains("Historical"))
            {

                filePositions = FindFileFromNameCru(fileNames);
            }
            else if (ObserveModel.Checked)
            {
                filePositions = FindFileFromNameObserve(fileNames);
            }
            else
            {
                filePositions = FindFileFromName(fileNames);
            }
            foreach (var file in Files)
            {

                double[,] dt = new double[95, 13];
                var lines = File.ReadAllLines(file.FullName);
                var firstLine = (startPeriod - startDate).Days + 1;
                var lastLine = (endPeriod - startDate).Days + 1;
                var mounthCounter = startPeriod.Month;
                var yearIndex = startPeriod.Year - startDate.Year;
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
                    ccdaLines[theIndex + 1] = (theIndex + 1).ToString() + "\t" + lines[i];
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
        private void ReportSwat(string directory, string model, string senario, bool isPcp, string prefix, List<string> acceptFiles, DateTime startPeriod, DateTime endPeriod)
        {
            var theDir = inputPath + directory.Split(new[] { @"\UserDatabase" }, StringSplitOptions.None).LastOrDefault();
            var d = Directory.CreateDirectory(theDir);// Directory.CreateDirectory(directory.Replace(@"\UserDatabase", ""));


            var Files = d.GetFiles();
            if (acceptFiles != null)
            {
                Files = Files.Where(x => acceptFiles.Any(y => y == x.Name.Replace("p.txt", "").Replace("t.txt", ""))).ToArray();
            }
            var fileIndex = 0;
            foreach (var file in Files)
            {
                File.Copy(file.FullName, directory + file.Name, true);
            }
        }

        private void CruModel_CheckedChanged(object sender, EventArgs e)
        {
            ObserveModel.Enabled = !CruModel.Checked;
            if (CruModel.Checked)
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
                ModelChk.Items.Remove("ObservedData");
                ScenarioChk.Items.Remove("ObservedCru");
                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, false);
                ModelChk.Enabled = true;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, false);
                ScenarioChk.Enabled = true;
            }
        }

        private void ScenarioChk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void swatBtn_Click(object sender, EventArgs e)
        {
            var CheckedModels = ModelChk.CheckedItems.OfType<string>().ToList();
            var CheckedSens = ScenarioChk.CheckedItems.OfType<string>().ToList();
            if (CruModel.Checked)
            {
                CheckedModels =new List<string>(){ "ObservedData"};
                CheckedSens = new List<string>(){"ObservedCru"};
            }
            else if (ObserveModel.Checked)
            {
                CheckedModels =new List<string>(){"ObservedData"};
                CheckedSens = new List<string>(){"ObservedUser"};
            }

            List<string> fileList = null;
            if (SelectedArea.Checked)
            {
                var LatitudeFrom = Convert.ToDouble(LatFrom.Text);
                var LongitudeFrom = Convert.ToDouble(LongFrom.Text);
                var LatitudeTo = Convert.ToDouble(LatTo.Text);
                var LongitudeTo = Convert.ToDouble(LongTo.Text);
                if (CruModel.Checked || CheckedSens.Contains("Historical"))
                    fileList = FindFileNamesCru(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
                else if (ObserveModel.Checked)
                    fileList = FindFileNamesObserve(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
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
            var outputPathSwat = outputPath + @"\UserDatabase";
            Directory.CreateDirectory(outputPathSwat);
            foreach (var model in CheckedModels)
            {
                var modelDirectory = outputPathSwat + @"\" + model;
                Directory.CreateDirectory(modelDirectory);
                foreach (var senario in CheckedSens)
                {
                    var senarioDirectory = modelDirectory + @"\" + senario;
                    Directory.CreateDirectory(senarioDirectory);
                    if (Precipitation.Checked)
                    {
                        var pcpDirectory = senarioDirectory + @"\pcp\";
                        Directory.CreateDirectory(pcpDirectory);

                        ReportSwat(pcpDirectory, model.ToString(), senario.ToString(), true, "", fileList, startPeriod, endPeriod);

                    }
                    if (Temperature.Checked)
                    {
                        var tmpDirectory = senarioDirectory + "/tmp/";
                        Directory.CreateDirectory(tmpDirectory);

                        ReportSwat(tmpDirectory, model.ToString(), senario.ToString(), false, "max_", fileList,
                                startPeriod, endPeriod);
                        ReportSwat(tmpDirectory, model.ToString(), senario.ToString(), false, "min_", fileList,
                                startPeriod, endPeriod);

                    }
                }
            }
            //  MessageBox.Show("End!");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void twoBtn_Click(object sender, EventArgs e)
        {

            frmParent.BusyState();
            try
            {
                curentDir = System.IO.Directory.GetCurrentDirectory();
                outputPath = OutputTxt.Text;
                inputPath = FileTxt.Text;
                var inputs = "";
                var models = ModelChk.CheckedItems.Cast<object>().Aggregate("", (current, model) => current + (model + ","));
                models =models.Length>0? models.Remove(models.Length - 1):models;
             

                var sens = ScenarioChk.CheckedItems.Cast<object>().Aggregate("", (current, sen) => current + (sen + ","));
                sens =sens.Length>0? sens.Remove(sens.Length - 1):sens;

                if (CruModel.Checked)
                {
                    models="ObservedData";
                    sens="ObservedCru";
                }
                else if (ObserveModel.Checked)
                {
                    models = "ObservedData";
                    sens = "ObservedUser";
                }

                inputs += "Main Database Folder : " + Environment.NewLine + FileTxt.Text + Environment.NewLine;
                inputs += "Historic Climate Data : " + Environment.NewLine + CruModel.Checked + Environment.NewLine;
                inputs += "Future Climate Models : " + Environment.NewLine + models + Environment.NewLine;
                inputs += "Carbon Emission Scenarios : " + Environment.NewLine + sens + Environment.NewLine;
                inputs += "Precipitation : " + Environment.NewLine + Precipitation.Checked + Environment.NewLine;
                inputs += "Temperature : " + Environment.NewLine + Temperature.Checked + Environment.NewLine;
                inputs += "Latitude From : " + Environment.NewLine + LatFrom.Text + Environment.NewLine;
                inputs += "Latitude To : " + Environment.NewLine + LatTo.Text + Environment.NewLine;
                inputs += "Longitude From : " + Environment.NewLine + LongFrom.Text + Environment.NewLine;
                inputs += "Longitude To : " + Environment.NewLine + LongTo.Text + Environment.NewLine;
                inputs += "Start Date : " + Environment.NewLine + (SelectedPeriod.Checked ? Environment.NewLine + SimStartDate.Text : "") + Environment.NewLine;
                inputs += "End Date : " + Environment.NewLine + (SelectedPeriod.Checked ? Environment.NewLine + SimEndDate.Text : "") + Environment.NewLine;
                inputs += "User Project Folder : " + Environment.NewLine + OutputTxt.Text + Environment.NewLine;
                StaticData.UserProjectFolder = OutputTxt.Text;
                File.WriteAllText(outputPath + "/inputs.txt", inputs);
                // CcdaBtn_Click(sender, e);
                swatBtn_Click(sender, e);
                MessageBox.Show("End!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            frmParent.ReadyState();
        }



        private void OutputBrows_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                OutputTxt.Text = outputPath = folderDialog.SelectedPath;

            }
        }

        private void SelectedPeriod_CheckedChanged(object sender, EventArgs e)
        {
            SimEndDate.Enabled = SelectedPeriod.Checked;
            SimStartDate.Enabled = SelectedPeriod.Checked;
        }

        private void ObserveModel_CheckedChanged(object sender, EventArgs e)
        {
            CruModel.Enabled = !ObserveModel.Checked;
            if (ObserveModel.Checked)
            {
                MessageBox.Show(@"Three steps for downscaling of GCMs while having ObservedUser in the project:
1- Click Run button for ObservedUser, 
2- Click Run button for GCMs, 
3- Click downscaling button for GCMs (RCPs and Historical).", "Tip", MessageBoxButtons.OK);

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
                ModelChk.Items.Remove("ObservedData");
                ScenarioChk.Items.Remove("ObservedUser");
                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, false);
                ModelChk.Enabled = true;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, false);
                ScenarioChk.Enabled = true;
            }
        }

        private void downscalingBtn_Click(object sender, EventArgs e)
        {
            if (ObserveModel.Checked)
            {
                MessageBox.Show(@"ObservedUser cannot be downscaled. When having ObservedUser in your project, downscale GCMs (RCPs and Historical).
Three steps for downscaling of GCMs while having ObservedUser in the project:
1- Click Run button for ObservedUser, 
2- Click Run button for GCMs, 
3- Click downscaling button for GCMs (RCPs and Historical).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            var msg = @"Only if ObservedUser is being used in the project, GCMs must be downscaled. 
Coordinates of ObservedCru and GCMs are match and there is no need for downscaling of observed data.
Continue downscaling of GCMs?";
            if (MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

                curentDir = System.IO.Directory.GetCurrentDirectory();
                outputPath = OutputTxt.Text;
                inputPath = FileTxt.Text;
                var observes = new List<Position>();
                if (CruModel.Checked || CheckedSens.Contains("Historical"))
                {
                    observes = FindFileـJoinObserve(true);
                }
                else
                {
                    observes = FindFileـJoinObserve(false);

                }
                var outputPathSwat = outputPath + @"\UserDatabase";
                var outputPathDs = outputPathSwat.Replace(@"UserDatabase", "DownScaling");
                Directory.CreateDirectory(outputPathDs);
                foreach (var model in CheckedModels)
                {
                    var modelDirectory = outputPathDs + @"\" + model;
                    Directory.CreateDirectory(modelDirectory);
                    foreach (var senario in CheckedSens)
                    {

                        var senarioDirectory = modelDirectory + @"\" + senario;
                        Directory.CreateDirectory(senarioDirectory);

                        var pcpDirectory = senarioDirectory + @"\pcp\";
                        Directory.CreateDirectory(pcpDirectory);
                        var tmpDirectory = senarioDirectory + "/tmp/";
                        Directory.CreateDirectory(tmpDirectory);
                        foreach (var observe in observes)
                        {
                            var sourceFileName = observe.Main;
                            var destinationFileName = observe.Cru;
                            File.Copy(
                                pcpDirectory.Replace("DownScaling", "UserDatabase") + sourceFileName + "p.txt",
                                pcpDirectory + destinationFileName + "p.txt");
                            File.Copy(
                                tmpDirectory.Replace("DownScaling", "UserDatabase") + sourceFileName + "t.txt",
                                tmpDirectory + destinationFileName + "t.txt");
                        }

                    }
                }
            }
            frmParent.ReadyState();
            MessageBox.Show("End!");
        }
        private List<Position> FindFileـJoinObserve(bool cru = false)
        {
            var observs = FindFileNamesObserve();
            var LatitudeFrom = Convert.ToDouble(LatFrom.Text);
            var LongitudeFrom = Convert.ToDouble(LongFrom.Text);
            var LatitudeTo = Convert.ToDouble(LatTo.Text);
            var LongitudeTo = Convert.ToDouble(LongTo.Text);
            var allPos = new List<Position>();
            if (CruModel.Checked || ScenarioChk.CheckedItems.Contains("Historical") || cru)
            {
                allPos = FindFileNamesCruPos(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
            }
            else
            {
                allPos = FindFileNamesPos(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
            }


            foreach (var observ in observs)
            {
                var near = ReadCloserMeasuredRow(allPos, observ.Latitude, observ.Longitude);
                observ.Main = near.Main;
            }
            return observs;
        }
        private List<Position> FindFileNamesObserve()
        {
            string query = "select File_name,Latitude,Longitude from observePosition";
            var dt = RunQuery(query);

            //var list = (from DataRow row in dt.Rows
            //            select row["File_name"].ToString()).ToList();
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Cru = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString(),
                        }).ToList();
            return list;
        }
        private List<Position> FindFileNamesCruPos(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {
            string query = "select File_name,Latitude,Longitude,Elev from PositionRecord where (Latitude>=" + LatitudeFrom +
                           " and Longitude>=" + LongitudeFrom + " and  Latitude<=" + LatitudeTo +
                           " and Longitude<=" + LongitudeTo + ")";
            var dt = RunQuery(query);

            //var list = (from DataRow row in dt.Rows
            //            select row["File_name"].ToString()).ToList();
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Main = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString(),
                        }).ToList();
            return list;
        }
        private List<Position> FindFileNamesPos(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {
            string query = "select File_name,Latitude,Longitude from PositionRecord where (Latitude>=" + LatitudeFrom +
                           " and Longitude>=" + LongitudeFrom + " and  Latitude<=" + LatitudeTo +
                           " and Longitude<=" + LongitudeTo + ")";
            var dt = RunQuery(query);

            //var list = (from DataRow row in dt.Rows
            //            select row["File_name"].ToString()).ToList();
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Main = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString(),
                        }).ToList();
            return list;
        }

        private DataTable RunQuery(string query)
        {
            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private Position ReadCloserMeasuredRow(List<Position> allPos, string fileLat, string fileLong)
        {
            double minDistance = 100000000000000;
            var minRow = new Position();
            for (int i = 1; i < allPos.Count; i++)
            {
                var mData = allPos[i];
                var mLat = mData.Latitude;
                var mLong = mData.Longitude;
                var dis = Distance(Convert.ToDouble(fileLat), Convert.ToDouble(fileLong), Convert.ToDouble(mLat), Convert.ToDouble(mLong));
                if (dis < minDistance)
                {
                    minDistance = dis;
                    minRow = mData;
                }
            }
            return minRow;
        }
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

        private void DownScalinChk_CheckedChanged(object sender, EventArgs e)
        {
            downscalingBtn.Enabled = DownScalinChk.Checked;
        }


    }
}
public class Position
{
    public string Cru { get; set; }
    public string Main { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
}

public class ObservePosition : Position
{
    public string FutureFileName { get; set; }
}