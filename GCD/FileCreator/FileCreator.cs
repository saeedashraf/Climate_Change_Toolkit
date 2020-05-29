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
using System.Xml.Serialization;
using AllInOne;
using CCT;
using Microsoft.Office.Interop.Access;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Form = System.Windows.Forms.Form;

namespace FileCreator
{
    public partial class FileCreator : Form
    {
        private string path = @"";// where files exist
        private string curentDir = @"";// where the exe run
        private string OutputPath = @"";// where files exist
        AllInOneForm frmParent ;
        private int ttIndex;
        private int sttIndex;
        public FileCreator()
        {
            InitializeComponent();
            
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            var msg = @"We recommend to run (interpolate) the module for each variable (precipitation or temperature) separately. 

Extents numbers must contain 0.25 or 0.75 decimals.

Do you want to continue?";
            if (MessageBox.Show(msg, "Check Your input data!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
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

                frmParent.BusyState();
                Directory.CreateDirectory(curentDir + @"\backup");
                File.Copy(curentDir + @"\positionDB.mdb", curentDir + @"\backup\" + DateTime.Now.Ticks + "-positionDB.mdb", true);
                //try
                //{
                var fileFolders = "";
                if (DirectRb.Checked)
                {
                    fileFolders = DirectFilesTxt.Text;
                    MainRun(fileFolders);
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

                                MainRun(pcpDirectory);

                            }
                            if (Temperature.Checked)
                            {

                                var tmpDirectory = senarioDirectory + @"\tmp";
                                Directory.CreateDirectory(tmpDirectory);

                                MainRun(tmpDirectory);

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
                inputs += "Latitude From : " + Environment.NewLine + LatFrom.Text + Environment.NewLine;
                inputs += "Latitude To : " + Environment.NewLine + LatTo.Text + Environment.NewLine;
                inputs += "Longitude From : " + Environment.NewLine + LongFrom.Text + Environment.NewLine;
                inputs += "Longitude To : " + Environment.NewLine + LongTo.Text + Environment.NewLine;
                inputs += "Considering Elevation : " + elevChk.Checked + Environment.NewLine;
                inputs += "Current Grid Size : " + stepTxt.Text + Environment.NewLine;

                File.WriteAllText(ManualFilesTxt.Text.Replace("UserDatabase", "Interpolation").Replace("Bias-Corrected", "Interpolation") + "/inputs.txt", inputs);
                MessageBox.Show("End!");
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                frmParent.ReadyState();
            }

      
        }

        private void MainRun(string fileFolder)
        {
            path = fileFolder;
            OutputPath = path.Replace("UserDatabase", "Interpolation").Replace("Bias-Corrected", "Interpolation");
            var outputDirectory = Directory.CreateDirectory(OutputPath);
            var d = Directory.CreateDirectory(path);
            var pathFiles = d.GetFiles();//read folder files
            if (pathFiles.Length > 0)
            {
                if (path != OutputPath)
                {
                    pathFiles.ToList().ForEach(f => File.Copy(f.FullName, OutputPath + "/" + f.Name, true));
                }

                var isPcp = pathFiles[0].Name.ToLower().Contains("p");// pcp or tmp
                OutputRun(CruModel.Checked || ScenarioChk.CheckedItems.Contains("Historical"), pathFiles, isPcp);
            }
        }

        private void OutputRun(bool cru, FileInfo[] pathFiles, bool isPcp)
        {
            List<Position> fileList = null;
            var LatitudeFrom = Convert.ToDouble(LatFrom.Text);
            var LongitudeFrom = Convert.ToDouble(LongFrom.Text);
            var LatitudeTo = Convert.ToDouble(LatTo.Text);
            var LongitudeTo = Convert.ToDouble(LongTo.Text);
            var step = Convert.ToDouble(stepTxt.Text);
            var useElev = elevChk.Checked; 
            if (cru && !ObservedUserDBChk.Checked)//is cru?
                fileList = FindFileNamesCru(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);//file list from cru db
            else if(ObserveModel.Checked || ObservedUserDBChk.Checked)
                fileList = FindFileNamesObserve(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);//file list from cru db
            else
                fileList = FindFileNames(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);//file list from  db

            for (var i = LongitudeFrom; i < LongitudeTo; i += step)// for each long
            {
                for (var j = LatitudeFrom; j < LatitudeTo; j += step)// for each lat
                {
                    //in DB
                    var thefilePosition = fileList.FirstOrDefault(x => x.Longitude == i.ToString() && x.Latitude == j.ToString());
                    var rowNextfilePosition = fileList.FirstOrDefault(x => x.Longitude == i.ToString() && x.Latitude == (j + step).ToString());
                    var colNextfilePosition = fileList.FirstOrDefault(x => x.Longitude == (i + step).ToString() && x.Latitude == j.ToString());
                    var forthNextfilePosition = fileList.FirstOrDefault(x => x.Longitude == (i + step).ToString() && x.Latitude == (j + step).ToString());
                    //in Folder

                    if (thefilePosition != null)
                    {
                        var thePathFile = pathFiles.FirstOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == thefilePosition.Main);
                        if (thePathFile != null)
                        {
                            if (rowNextfilePosition != null)
                            {
                                //real file next in row exist in folder
                                var rowNextPathFile = pathFiles.FirstOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == rowNextfilePosition.Main);
                                if (rowNextPathFile != null)
                                {
                                    CreateAvarageFileAndDB(thePathFile, rowNextPathFile, thefilePosition, rowNextfilePosition, isPcp, cru, useElev);
                                }
                            }
                            if (colNextfilePosition != null)
                            {
                                //real file next in col exist in folder
                                var colNextPathFile = pathFiles.FirstOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == colNextfilePosition.Main);
                                if (colNextPathFile != null)
                                {
                                    CreateAvarageFileAndDB(thePathFile, colNextPathFile, thefilePosition, colNextfilePosition, isPcp, cru, useElev);
                                }
                            }
                            if (forthNextfilePosition != null && colNextfilePosition != null && rowNextfilePosition != null)
                            {
                                //real file next in col exist in folder
                                var rowNextPathFile = pathFiles.FirstOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == rowNextfilePosition.Main);
                                var colNextPathFile = pathFiles.FirstOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == colNextfilePosition.Main);
                                var forthNextPathFile = pathFiles.FirstOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == forthNextfilePosition.Main);
                                if (forthNextPathFile != null && colNextPathFile != null && rowNextPathFile != null)
                                {
                                    CreateCenterAvarageFileAndDB(thePathFile, rowNextPathFile, colNextPathFile, forthNextPathFile, thefilePosition, rowNextfilePosition, colNextfilePosition, forthNextfilePosition, isPcp, cru, useElev);
                                }
                            }
                        }
                    }

                }
            }

        }

        private void CreateCenterAvarageFileAndDB(FileInfo thePathFile, FileInfo rowNextPathFile, FileInfo colNextPathFile, FileInfo forthNextPathFile, Position thefilePosition, Position rowNextfilePosition, Position colNextfilePosition, Position forthNextfilePosition, bool isPcp, bool cru, bool useElev)
        {
            var fileLines = File.ReadAllLines(thePathFile.FullName);// read all lines of current file
            var rowNextFileLines = File.ReadAllLines(rowNextPathFile.FullName);// read all lines of next file
            var colNextFileLines = File.ReadAllLines(colNextPathFile.FullName);// read all lines of next file
            var forthNextFileLines = File.ReadAllLines(forthNextPathFile.FullName);// read all lines of next file
            string[] newFileLines = new string[fileLines.Length];
            newFileLines[0] = fileLines[0];// date in first row of file
            var fileElev = useElev ? Convert.ToDouble(thefilePosition.Elev) : 1;
            var rowNextFileElev = useElev ? Convert.ToDouble(rowNextfilePosition.Elev) : 1;
            var colNextfileElev = useElev ? Convert.ToDouble(colNextfilePosition.Elev) : 1;
            var forthNextFileElev = useElev ? Convert.ToDouble(forthNextfilePosition.Elev) : 1;
            var totalElev = fileElev + rowNextFileElev + colNextfileElev + forthNextFileElev;
            for (int i = 1; i < fileLines.Length; i++)
            {
                if (isPcp)
                {
                    var avg = ((Convert.ToDouble(fileLines[i]) * fileElev) + (Convert.ToDouble(rowNextFileLines[i]) * rowNextFileElev) + (Convert.ToDouble(colNextFileLines[i]) * colNextfileElev) + (Convert.ToDouble(forthNextFileLines[i]) * forthNextFileElev)) / totalElev;//create pcp average
                    newFileLines[i] = avg.ToString("f2", CultureInfo.InvariantCulture);
                }
                else
                {
                    var avgMax = ((Convert.ToDouble(fileLines[i].Split(',')[0]) * fileElev) + (Convert.ToDouble(rowNextFileLines[i].Split(',')[0]) * rowNextFileElev) + (Convert.ToDouble(colNextFileLines[i].Split(',')[0]) * colNextfileElev) + (Convert.ToDouble(forthNextFileLines[i].Split(',')[0]) * forthNextFileElev)) / totalElev;//create tmp max average
                    var avgMin = ((Convert.ToDouble(fileLines[i].Split(',')[1]) * fileElev) + (Convert.ToDouble(rowNextFileLines[i].Split(',')[1]) * rowNextFileElev) + (Convert.ToDouble(colNextFileLines[i].Split(',')[1]) * colNextfileElev) + (Convert.ToDouble(forthNextFileLines[i].Split(',')[1]) * forthNextFileElev)) / totalElev;//create tmp max average

                    newFileLines[i] = avgMax.ToString("f2", CultureInfo.InvariantCulture) + "," + avgMin.ToString("f2", CultureInfo.InvariantCulture);
                }
            }
            var newFileName = thefilePosition.Main.ToString() + rowNextfilePosition.Main.ToString() + colNextfilePosition.Main.ToString() + forthNextfilePosition.Main.ToString();
            var newLatitude = (Convert.ToDouble(thefilePosition.Latitude) + Convert.ToDouble(rowNextfilePosition.Latitude) + Convert.ToDouble(colNextfilePosition.Latitude) + Convert.ToDouble(forthNextfilePosition.Latitude)) / 4;//create lat average
            var newLongitude = (Convert.ToDouble(thefilePosition.Longitude) + Convert.ToDouble(rowNextfilePosition.Longitude) + Convert.ToDouble(colNextfilePosition.Longitude) + Convert.ToDouble(forthNextfilePosition.Longitude)) / 4;//create long average
            var newElev = totalElev / 4;

            if (isPcp)
            {
                newFileName += "p.txt";
            }
            else
            {
                newFileName += "t.txt";
            }
            File.WriteAllLines(OutputPath + @"\" + newFileName, newFileLines);// create new file

            InsertToDbNewFile(newFileName, newLatitude, newLongitude, newElev, cru);// insert to db new file info
        }

        private void CreateAvarageFileAndDB(FileInfo thePathFile, FileInfo nextPathFile, Position thefilePosition, Position nextfilePosition, bool isPcp, bool cru, bool useElev)
        {
            var fileLines = File.ReadAllLines(thePathFile.FullName);// read all lines of current file

            var nextFileLines = File.ReadAllLines(nextPathFile.FullName);// read all lines of next file
            string[] newFileLines = new string[fileLines.Length];
            newFileLines[0] = fileLines[0];// date in first row of file
            var fileElev = useElev ? Convert.ToDouble(thefilePosition.Elev) : 1;
            var nextFileElev = useElev ? Convert.ToDouble(nextfilePosition.Elev) : 1;
            var totalElev = fileElev + nextFileElev;
            for (int i = 1; i < fileLines.Length; i++)
            {
                if (isPcp)
                {
                    var avg = ((Convert.ToDouble(fileLines[i]) * fileElev) + (Convert.ToDouble(nextFileLines[i]) * nextFileElev)) / totalElev;//create pcp average
                    newFileLines[i] = avg.ToString("f2", CultureInfo.InvariantCulture);
                }
                else
                {
                    var avgMax = ((Convert.ToDouble(fileLines[i].Split(',')[0]) * fileElev) + (Convert.ToDouble(nextFileLines[i].Split(',')[0]) * nextFileElev)) / totalElev;//create tmp max average
                    var avgMin = ((Convert.ToDouble(fileLines[i].Split(',')[1]) * fileElev) + (Convert.ToDouble(nextFileLines[i].Split(',')[1]) * nextFileElev)) / totalElev;//create tmp min average

                    newFileLines[i] = avgMax.ToString("f2", CultureInfo.InvariantCulture) + "," +
                                      avgMin.ToString("f2", CultureInfo.InvariantCulture);
                }
            }
            var newFileName = thefilePosition.Main.ToString() + nextfilePosition.Main.ToString();
            var newLatitude = (Convert.ToDouble(thefilePosition.Latitude) + Convert.ToDouble(nextfilePosition.Latitude)) / 2;//create lat average
            var newLongitude = (Convert.ToDouble(thefilePosition.Longitude) + Convert.ToDouble(nextfilePosition.Longitude)) / 2;//create long average
            var newElev = totalElev / 2;
            if (isPcp)
            {
                newFileName += "p.txt";
            }
            else
            {
                newFileName += "t.txt";
            }
            File.WriteAllLines(OutputPath + @"\" + newFileName, newFileLines);// create new file

            InsertToDbNewFile(newFileName, newLatitude, newLongitude, newElev, cru);// insert to db new file info
        }

        private void InsertToDbNewFile(string newFileName, double newLatitude, double newLongitude, double newElev,
            bool cru)
        {
            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            var tblName = "PositionRecord";
            if (cru && !ObservedUserDBChk.Checked)
                tblName = "PositionRecord";
            else if (ObserveModel.Checked || ObservedUserDBChk.Checked)
                tblName = "observePosition";
            //            var preQ = @" IF NOT EXISTS
            //        (
            //        SELECT 1
            //        FROM " + tblName + @"
            //        WHERE Latitude = " + newLatitude + @" and Longitude= " + newLongitude + @"
            //        )
            //        BEGIN
            //        ";
            var preQ = @" SELECT *
        FROM " + tblName + @"
        WHERE Latitude = " + newLatitude + @" and Longitude= " + newLongitude + @"
        ";
            var dt = RunQuery(preQ);

            if (dt.Rows.Count == 0)
            {
            
            var query = /*preQ+*/ @"insert into " + tblName + " (File_Name,Latitude,Longitude,Elev) values('" +
                                  newFileName.Replace("p.txt", "").Replace("t.txt", "") + "'," + newLatitude + "," +
                                  newLongitude + "," +
                                  newElev + @")";
            //End";
            var command = new OleDbCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }

        private List<Position> FindFileNames(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
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
                            Elev = row["Elev"].ToString(),
                        }).ToList();
            return list;
        }
        private List<Position> FindFileNamesCru(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
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
                            Elev = row["Elev"].ToString(),
                        }).ToList();
            return list;
        }
        private List<Position> FindFileNamesObserve(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {
            string query = "select File_name,Latitude,Longitude,Elev from observePosition where (Latitude>=" + LatitudeFrom +
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
                            Elev = row["Elev"].ToString(),
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

        private void FileCreator_Load(object sender, EventArgs e)
        {
            curentDir = System.IO.Directory.GetCurrentDirectory();
            ManualFilesTxt.Text = StaticData.UserProjectFolder + @"\UserDatabase";
            frmParent = (AllInOneForm)this.MdiParent;
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

        private void FilesBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                DirectFilesTxt.Text = folderDialog.SelectedPath;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var msg = @"Possible Input data folders: 
UserDatabase or Bias-Corrected or Interpolation folders.

Recommendation: Browse Bias-Corrected folder for the first run and for the second run browse the created Interpolation folder (output of first run).";
            MessageBox.Show(msg, "Tip", MessageBoxButtons.OK);
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                ManualFilesTxt.Text = folderDialog.SelectedPath;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CruModel.Checked = checkBox1.Checked;
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

        private void OutputGcd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(OutputPath);
        }

        private void elevChk_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = elevChk.Checked;
        }

        private void ObserveModel_CheckedChanged(object sender, EventArgs e)
        {
            
            if (ObserveModel.Checked)
            {
                CruModel.Checked = false;
                checkBox1.Checked = false;
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

        private void ObservedUserDBChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ObservedUserDBChk.Checked)
            {
                MessageBox.Show(@"ObservedUser cannot be interpolated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
            }
        }
    }

    internal class Position
    {
        public string Main { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elev { get; set; }
    }
}
