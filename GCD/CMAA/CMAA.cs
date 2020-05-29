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
using CCT;
using Microsoft.Office.Interop.Access;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Form = System.Windows.Forms.Form;
using AllInOne;

namespace CMAA
{
    public partial class CMAA : Form
    {
        private string path = @"D:\GCD\GlobalModelData";
        private string UserDataFolder = @"\UserDatabase";
        private string outputPath = @"D:\GCD\GlobalModelData\Outputs";
        private string month = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec";
        private int year = 2004;
        AllInOneForm frmParent ;
        private int ttIndex;
        private int sttIndex;
        private static DateTime startDate = new DateTime(2006, 01, 01);
        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        private string curentDir = @"";// where the exe run
        public CMAA()
        {
            InitializeComponent();
            
        }
        private void CalcFiles(string directory, string model, string senario, bool isPcp, string prefix, List<string> acceptFiles, DateTime startPeriod, DateTime endPeriod)
        {
            var d = Directory.CreateDirectory(directory.Replace(@"\Average-Anomalies\Outputs_Average", UserDataFolder));
            var Files = d.GetFiles();
            if (acceptFiles != null)
            {
                Files = Files.Where(x => acceptFiles.Any(y => y == x.Name.Replace("p.txt", "").Replace("t.txt", ""))).ToArray();
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
                var dayCounter = 0;
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
                    if (curDate < startPeriod.AddMonths(mounthCounter))
                    {
                        var lineVal = Convert.ToDouble(lines[i]);
                        curDate = curDate.AddDays(1);
                        if (lineVal > -99)
                        {
                            totalMonth += lineVal;
                            dayCounter++;
                        }
                    }
                    else
                    {
                        int modeMonth;
                        Math.DivRem((mounthCounter - 1), 12, out modeMonth);
                        if (!isPcp)
                        {
                            totalMonth = totalMonth / dayCounter;
                        }
                        dayCounter = 0;
                        dt[yearIndex, modeMonth] = totalMonth;
                        totalYear += totalMonth;
                        if (modeMonth == 11)
                        {
                            if (isPcp)
                                dt[yearIndex, 12] = totalYear;
                            else
                            {
                                dt[yearIndex, 12] = totalYear / 12;
                            }
                            totalYear = 0;
                            yearIndex++;
                        }
                        //reset
                        totalMonth = 0;
                        mounthCounter++;
                        var lineVal = Convert.ToDouble(lines[i]);
                        if (lineVal > -99)
                        {
                            totalMonth += lineVal;
                            dayCounter++;
                        }
                        curDate = curDate.AddDays(1);
                    }
                }
                int modeMonthLast = 11;
                Math.DivRem((mounthCounter - 1), 12, out modeMonthLast);
                if (!isPcp)
                {
                    totalMonth = totalMonth / dayCounter;
                }
                dayCounter = 0;
                dt[yearIndex, modeMonthLast] = totalMonth;
                totalYear += totalMonth;
                if (modeMonthLast == 11)
                {
                    if (isPcp)
                        dt[yearIndex, 12] = totalYear;
                    else
                    {
                        dt[yearIndex, 12] = totalYear / 12;
                    }
                    totalYear = 0;
                    yearIndex++;
                }


                #region average
                var yearCount = 94;
                if (CruModel.Checked)
                {
                    year = 1968;
                    yearCount = 37;
                }
                if (ScenarioChk.CheckedItems.Contains("Historical"))
                {
                    year = 1948;
                    yearCount = 56;
                }
                if (ObserveModel.Checked)
                {
                    year = observeDate.Value.Year - 2;
                    yearCount = Convert.ToInt32(lastLine / 365);
                }
                for (int i = 0; i < 13; i++)
                {
                    double columnTotal = 0;
                    var removeDay = 0;
                    for (int j = 0; j < yearCount; j++)
                    {
                        var theVal= Convert.ToDouble(dt[j, i]);
                        if (theVal > -99)
                        {
                            columnTotal += theVal;
                        }
                        else
                        {
                            removeDay++;
                        }
                    }
                    dt[yearCount, i] = columnTotal / (yearCount- removeDay);

                }
                #endregion

                var fileName = model + "_" + senario + "_" + prefix + file.Name.Replace(".txt", ".xlsx");
                SaveExcel(directory + fileName, dt, isPcp, year, yearCount);
            }

        }
        private void RunGcd_Click(object sender, EventArgs e)
        {
            
            frmParent.BusyState();
            try
            {
                path = FileTxt.Text;
                UserDataFolder =@"\"+ path.Split('\\').LastOrDefault();
                var inputs = "";
                var models = ModelChk.CheckedItems.Cast<object>().Aggregate("", (current, model) => current + (model + ","));
                models =models.Length>0? models.Remove(models.Length - 1):models;
                var sens = ScenarioChk.CheckedItems.Cast<object>().Aggregate("", (current, sen) => current + (sen + ","));
                sens =sens.Length>0? sens.Remove(sens.Length - 1):sens;
                if (CruModel.Checked)
                {
                    models = "ObservedData";
                    sens = "ObservedCru";
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
                OutputRun(false);
                File.WriteAllText(outputPath + "/inputs.txt", inputs);

                MessageBox.Show("End!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            frmParent.ReadyState();
        }
        private void OutputRun(bool isAnomaly)
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


            List<string> fileList = null;


            startDate = new DateTime(2006, 01, 01);
            var startPeriod = new DateTime(2006, 1, 1);
            var endPeriod = new DateTime(2099, 12, 31);
            if (CruModel.Checked)
            {
                startDate = new DateTime(1970, 01, 01);
                startPeriod = new DateTime(1970, 1, 1);
                endPeriod = new DateTime(2006, 12, 31);
            }
            else if (ObserveModel.Checked)
            {
                startDate = observeDate.Value;
                startPeriod = observeDate.Value;
                endPeriod = new DateTime(2096, 12, 31);
            }
            else if (CheckedSens.Contains("Historical"))
            {
                startDate = new DateTime(1950, 01, 01);
                startPeriod = new DateTime(1950, 1, 1);
                endPeriod = new DateTime(2006, 12, 31);
            }

            outputPath = Directory.GetParent(path).ToString();// path.Split(new[] { @"\UserDatabase" }, StringSplitOptions.None).FirstOrDefault();
            //var x = Directory.GetParent(path).ToString();
            outputPath = outputPath + @"\Average-Anomalies\Outputs_Average";
     
            Directory.CreateDirectory(outputPath);
            foreach (var model in CheckedModels)
            {
                var modelDirectory = outputPath + @"\" + model;
                Directory.CreateDirectory(modelDirectory);
                foreach (var senario in CheckedSens)
                {
                    var senarioDirectory = modelDirectory + @"\" + senario;
                    Directory.CreateDirectory(senarioDirectory);
                    if (Precipitation.Checked)
                    {
                        var pcpDirectory = senarioDirectory + @"\pcp\";
                        Directory.CreateDirectory(pcpDirectory);
                      
                            CalcFiles(pcpDirectory, model.ToString(), senario.ToString(), true, "pcp_", fileList, startPeriod, endPeriod);
                        
                    }
                    if (Temperature.Checked)
                    {
                        var tmpDirectory = senarioDirectory + "/tmp/";
                        Directory.CreateDirectory(tmpDirectory);
                      
                            CalcFiles(tmpDirectory, model.ToString(), senario.ToString(), false, "max_", fileList,
                                startPeriod, endPeriod);
                            CalcFiles(tmpDirectory, model.ToString(), senario.ToString(), false, "min_", fileList,
                                startPeriod, endPeriod);
                        
                    }
                }
            }
        }
        private void CalcFileAnomaly(string directory, string model, string senario, bool isPcp, string prefix, List<string> acceptFiles, DateTime baseStartPeriod, DateTime baseEndPeriod, DateTime futStartPeriod, DateTime futEndPeriod)
        {
            var d = Directory.CreateDirectory(directory.Replace(@"\Average-Anomalies\Outputs_Anomaly", UserDataFolder).Replace(@"\Average-Anomalies\Outputs_Average_Anomaly", UserDataFolder));

            var Files = d.GetFiles();
            if (acceptFiles != null)
            {
                Files = Files.Where(x => acceptFiles.Any(y => y == x.Name.Replace("p.txt", "").Replace("t.txt", ""))).ToArray();
            }
            foreach (var file in Files)
            {

                var baseDt = Anomaly(file, baseStartPeriod, baseEndPeriod, isPcp, prefix);
                var futDt = Anomaly(file, futStartPeriod, futEndPeriod, isPcp, prefix);



                var fileName = "Anomaly_" + model + "_" + senario + "_" + prefix + file.Name.Replace(".txt", ".xlsx");
                SaveAnomalyExcel(directory + fileName, baseDt, futDt, isPcp, baseStartPeriod, baseEndPeriod, futStartPeriod, futEndPeriod, null, null, null);
            }

        }
        private void CalcFileAnomalyCru(string directory, string model, string senario, bool isPcp, string prefix, List<string> acceptFiles, DateTime baseStartPeriod, DateTime baseEndPeriod, DateTime futStartPeriod, DateTime futEndPeriod)
        {
            double LatitudeFrom = -1000000;
            double LongitudeFrom = -1000000;
            double LatitudeTo = 1000000;
            double LongitudeTo = 1000000;

            List<Position> union = FindFileـJoin(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
            var d = Directory.CreateDirectory(directory.Replace(@"\Average-Anomalies\Outputs_Average_Anomaly", UserDataFolder));
            var cruPath = path + @"\ObservedData\ObservedCru";
            if (isPcp)
            {
                cruPath += @"\pcp";
            }
            else
            {

                cruPath += @"\tmp";

            }
            var cruDir = Directory.CreateDirectory(cruPath);
            var CruFiles = cruDir.GetFiles();
            var Files = d.GetFiles();
            if (senario.Contains("Historical"))
            {
                Files =
                    Files.Where(x => union.Any(y => y.Cru == x.Name.Replace("p.txt", "").Replace("t.txt", "")))
                        .ToArray();

            }
            else
            {
                Files = Files.Where(x => union.Any(y => y.Main == x.Name.Replace("p.txt", "").Replace("t.txt", ""))).ToArray();

            }
            List<double[]> anomalySummery = new List<double[]>();
            foreach (var file in Files)
            {
                var singleOrDefault = new Position();
                if (senario.Contains("Historical"))
                    singleOrDefault = union.SingleOrDefault(x => x.Cru == file.Name.Replace("p.txt", "").Replace("t.txt", ""));
                else
                    singleOrDefault = union.SingleOrDefault(x => x.Main == file.Name.Replace("p.txt", "").Replace("t.txt", ""));
                if (singleOrDefault != null && singleOrDefault.Cru.Length > 0)
                {
                    var cruName = singleOrDefault.Cru;
                    var cruFile = CruFiles.SingleOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == cruName);
                    if (cruFile != null)
                    {
                        startDate = new DateTime(1970, 01, 01);
                        var baseDt = Anomaly(cruFile, baseStartPeriod, baseEndPeriod, isPcp, prefix);

                        startDate = new DateTime(2006, 01, 01);
                        if (senario.Contains("Historical"))
                        {
                            startDate = new DateTime(1950, 01, 01);
                        }
                        var futDt = Anomaly(file, futStartPeriod, futEndPeriod, isPcp, prefix);


                        var fileName = "Anomaly_" + model + "_" + senario + "_" + prefix + file.Name.Replace(".txt", ".xlsx");
                        SaveAnomalyExcel(directory + fileName, baseDt, futDt, isPcp, baseStartPeriod, baseEndPeriod, futStartPeriod, futEndPeriod, anomalySummery, singleOrDefault.Latitude, singleOrDefault.Longitude);
                    }
                }
            }
            var totalFileName = "LongtermAve_Anomaly_" + model + "_" + senario + "_" + prefix + "TotalReport.xlsx";
            var inputBiasFileName = "Longterm_" + model + "_" + senario + "_" + prefix + "TotalReport.xlsx";
            SaveAnomalySummmeryExcel(anomalySummery, directory + totalFileName, inputBiasFileName);
        }
        private void CalcFileAnomalyObserve(string directory, string model, string senario, bool isPcp, string prefix, List<string> acceptFiles, DateTime baseStartPeriod, DateTime baseEndPeriod, DateTime futStartPeriod, DateTime futEndPeriod)
        {
            double LatitudeFrom = -1000000;
            double LongitudeFrom = -1000000;
            double LatitudeTo = 1000000;
            double LongitudeTo = 1000000;

            List<Position> union = FindFileـJoinObserve();
            var d = Directory.CreateDirectory(directory.Replace(@"\Average-Anomalies\Outputs_Average_Anomaly", UserDataFolder));
            var cruPath = path + @"\ObservedData\ObservedUser";
            if (isPcp)
            {
                cruPath += @"\pcp";
            }
            else
            {

                cruPath += @"\tmp";

            }
            var cruDir = Directory.CreateDirectory(cruPath);
            var CruFiles = cruDir.GetFiles();
            var Files = d.GetFiles();

            Files =
                Files.Where(x => union.Any(y => y.Main == x.Name.Replace("p.txt", "").Replace("t.txt", "")))
                    .ToArray();


            List<double[]> anomalySummery = new List<double[]>();
            foreach (var file in CruFiles)
            {
                var singleOrDefault = union.SingleOrDefault(x => x.Cru == file.Name.Replace("p.txt", "").Replace("t.txt", ""));
                if (singleOrDefault != null)
                {
                    var MainName = singleOrDefault.Main;
                    var MainFile = Files.SingleOrDefault(x => x.Name.Replace("p.txt", "").Replace("t.txt", "") == MainName);
                    if (MainFile != null)
                    {
                        startDate = observeDate.Value;
                        var baseDt = Anomaly(file, baseStartPeriod, baseEndPeriod, isPcp, prefix);

                        startDate = new DateTime(2006, 01, 01);
                        if (CruModel.Checked)
                        {
                            startDate = new DateTime(1970, 01, 01);
                        }
                        if (ScenarioChk.CheckedItems.Contains("Historical"))
                        {
                            startDate = new DateTime(1950, 01, 01);
                        }
                        var futDt = Anomaly(MainFile, futStartPeriod, futEndPeriod, isPcp, prefix);


                        var fileName = "Anomaly_" + model + "_" + senario + "_" + prefix + file.Name.Replace(".txt", ".xlsx");
                        SaveAnomalyExcel(directory + fileName, baseDt, futDt, isPcp, baseStartPeriod, baseEndPeriod, futStartPeriod, futEndPeriod, anomalySummery, singleOrDefault.Latitude, singleOrDefault.Longitude);
                    }
                }
            }
            var totalFileName = "LongtermAve_Anomaly_" + model + "_" + senario + "_" + prefix + "TotalReport.xlsx";
            var inputBiasFileName = "Longterm_" + model + "_" + senario + "_" + prefix + "TotalReport.xlsx";
            SaveAnomalySummmeryExcel(anomalySummery, directory + totalFileName, inputBiasFileName);
        }


        private void SaveAnomalySummmeryExcel(List<double[]> anomalySummery, string filePath, string inputBiasFileName)
        {


            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Workbook wb2 = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Workbook wb3 = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            Worksheet ws2 = (Worksheet)wb2.Worksheets[1];
            Worksheet ws3 = (Worksheet)wb3.Worksheets[1];
            ws.Cells[1, 1] = "Latitude";
            ws.Cells[1, 2] = "Longitude";
            ws2.Cells[1, 1] = "Latitude";
            ws2.Cells[1, 2] = "Longitude";
            ws3.Cells[1, 1] = "Latitude";
            ws3.Cells[1, 2] = "Longitude";
            var rowTitle = month.Split(',');
            var index = 2;
            for (int i = 0; i < rowTitle.Length; i++)
            {
                index++;
                ws.Cells[1, index] = rowTitle[i] + "_base";
                index++;
                ws.Cells[1, index] = rowTitle[i] + "_fut";
                index++;
                ws.Cells[1, index] = rowTitle[i] + "_anomaly";
            }
            ws.Cells[1, index + 1] = "Annual_base";
            ws.Cells[1, index + 2] = "Annual_fut";
            ws.Cells[1, index + 3] = "Annual_anomaly";
            var index2 = 2;
            for (int i = 0; i < rowTitle.Length; i++)
            {
                index2++;
                ws2.Cells[1, index2] = rowTitle[i] + "_base";
                ws3.Cells[1, index2] = rowTitle[i] + "_fut";
            }
            for (int i = 0; i < anomalySummery.Count; i++)
            {
                var bfIndex = 3;
                var mainIndex = 3;
                for (int j = 0; j < 28; j++)
                {


                    if (j < 2)
                    {
                        ws.Cells[i + 2, j + 1] = anomalySummery[i][j];
                        ws2.Cells[i + 2, j + 1] = anomalySummery[i][j];
                        ws3.Cells[i + 2, j + 1] = anomalySummery[i][j];
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            var baseVal = anomalySummery[i][j];
                            var futVal = anomalySummery[i][j + 1];
                            ws.Cells[i + 2, mainIndex] = baseVal;
                            mainIndex++;
                            ws.Cells[i + 2, mainIndex] = futVal;
                            mainIndex++;
                            ws.Cells[i + 2, mainIndex] = (futVal - baseVal) * 100 / baseVal;
                            mainIndex++;
                        }
                        if (j % 2 == 0 && j < 26)
                        {
                            ws2.Cells[i + 2, bfIndex] = anomalySummery[i][j];
                            ws3.Cells[i + 2, bfIndex] = anomalySummery[i][j + 1];
                            bfIndex++;
                        }
                    }
                }
            }
            var inputBiasFolder = path.Split(new[] { @"\UserDatabase" }, StringSplitOptions.None).FirstOrDefault();
            inputBiasFolder = inputBiasFolder + @"\InputBiasCorrection\";
            Directory.CreateDirectory(inputBiasFolder);
            ws.SaveAs(filePath);
            ws2.SaveAs(inputBiasFolder + "Observed_" + inputBiasFileName.Replace("Anomaly", "Longterm"));
            ws3.SaveAs(inputBiasFolder + "GCM_" + inputBiasFileName.Replace("Anomaly", "Longterm"));
            wb.Close();
            wb2.Close();
            wb3.Close();
        }
        private void SaveAnomalyExcel(string filePath, double[] baseDt, double[] futDt, bool isPcp, DateTime baseStartPeriod, DateTime baseEndPeriod, DateTime futStartPeriod, DateTime futEndPeriod, List<double[]> anomalySummery, string Latitude, string Longitude)
        {

            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            ws.Cells[2, 1] = "Base_" + baseStartPeriod.Year + "_" + baseEndPeriod.Year;
            ws.Cells[3, 1] = "Future_" + futStartPeriod.Year + "_" + futEndPeriod.Year;

            var rowTitle = month.Split(',');
            for (int i = 0; i < rowTitle.Length; i++)
            {
                ws.Cells[1, i + 2] = rowTitle[i];
            }
            if (isPcp)
            {
                ws.Cells[1, 14] = "Sum";
            }
            else
            {
                ws.Cells[1, 14] = "Average";
            }
            if (anomalySummery != null)
            {
                var summery = new double[28];
                summery[0] = Convert.ToDouble(Latitude);
                summery[1] = Convert.ToDouble(Longitude);
                var index = 1;
                for (int j = 0; j < 13; j++)
                {
                    ws.Cells[2, j + 2] = baseDt[j];
                    ws.Cells[3, j + 2] = futDt[j];
                    index++;
                    summery[index] = baseDt[j];
                    index++;
                    summery[index] = futDt[j];
                }
                anomalySummery.Add(summery);
            }
            else
            {
                for (int j = 0; j < 13; j++)
                {
                    ws.Cells[2, j + 2] = baseDt[j];
                    ws.Cells[3, j + 2] = futDt[j];
                }
            }
            ws.SaveAs(filePath);
            wb.Close();
        }
        private double[] Anomaly(FileInfo file, DateTime startPeriod, DateTime endPeriod, bool isPcp, string prefix)
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
            var dayCounter = 0;
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
                if (curDate < startPeriod.AddMonths(mounthCounter))
                {
                    var lineVal= Convert.ToDouble(lines[i]);
                  
                    curDate = curDate.AddDays(1);
                   
                    if (lineVal > -99)
                    {
                        totalMonth += lineVal;
                        dayCounter++;
                    }
                }
                else
                {
                    int modeMonth;
                    Math.DivRem((mounthCounter - 1), 12, out modeMonth);
                    if (!isPcp)
                    {
                        totalMonth = totalMonth / dayCounter;
                    }
                    dayCounter = 0;
                    dt[yearIndex, modeMonth] = totalMonth;
                    totalYear += totalMonth;
                    if (modeMonth == 11)
                    {
                        if (isPcp)
                            dt[yearIndex, 12] = totalYear;
                        else
                        {
                            dt[yearIndex, 12] = totalYear / 12;
                        }
                        totalYear = 0;
                        yearIndex++;
                    }
                    //reset
                    totalMonth = 0;
                    mounthCounter++;
                    var lineVal = Convert.ToDouble(lines[i]);
                    if (lineVal > -99)
                    {
                        totalMonth += lineVal;
                        dayCounter++;
                    }
                    curDate = curDate.AddDays(1);
                }
            }
            var yearStartIndex = startPeriod.Year - startDate.Year;
            var yearEndIndex = endPeriod.Year - startDate.Year;
            var avgDt = new double[13];
            for (int i = 0; i < 13; i++)
            {
                double total = 0;
                var removeDay = 0;
                for (int j = yearStartIndex; j <= yearEndIndex; j++)
                {
                    if (dt[j, i] > -99)
                    {
                        total += dt[j, i];
                    }
                    else
                    {
                        removeDay++;
                    }
                }
                avgDt[i] = total / ((yearEndIndex + 1 - yearStartIndex) - removeDay);
            }
            return avgDt;
        }
        private List<Position> FindFileـJoin(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
        {

            OleDbConnection con = new OleDbConnection();
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + curentDir + @"\positionDB.mdb";
            con.ConnectionString = cs;
            string query = "SELECT distinct PositionRecord.File_Name as cru,PositionRecord.File_Name,PositionRecord.Longitude,PositionRecord.Latitude from PositionRecord where  (PositionRecord.Latitude>=" + LatitudeFrom +
                           " and PositionRecord.Longitude>=" + LongitudeFrom + " and  PositionRecord.Latitude<=" + LatitudeTo +
                           " and PositionRecord.Longitude<=" + LongitudeTo + ")";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            var list = (from DataRow row in dt.Rows
                        select new Position()
                        {
                            Cru = row["cru"].ToString(),
                            Main = row["File_name"].ToString(),
                            Latitude = row["Latitude"].ToString(),
                            Longitude = row["Longitude"].ToString()
                        }).ToList();

            con.Close();
            return list;
        }

        private void SaveExcel(string filePath, double[,] data, bool isPcp, int year, int yearCount)
        {
            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            //var yearCount = 94;
            //if (CruModel.Checked || ScenarioChk.CheckedItems.Contains("Historical"))
            //{
            //    year = 1968;
            //    yearCount = 37;
            //}


            for (int i = 2; i < yearCount + 2; i++)
            {
                ws.Cells[i, 1] = year + i;
            }
            ws.Cells[yearCount + 2, 1] = "Average";
            var rowTitle = month.Split(',');
            for (int i = 0; i < rowTitle.Length; i++)
            {
                ws.Cells[1, i + 2] = rowTitle[i];
            }
            if (isPcp)
            {
                ws.Cells[1, 14] = "Sum";
            }
            else
            {
                ws.Cells[1, 14] = "Average";
            }
            for (int i = 0; i < yearCount + 1; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    ws.Cells[i + 2, j + 2] = data[i, j];
                }
            }
            ws.SaveAs(filePath);
            wb.Close();
        }
        private void PpuFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                FileTxt.Text = folderDialog.SelectedPath;

            }
        }
        private void RunAnomaly_Click(object sender, EventArgs e)
        {
          
            frmParent.BusyState();
            try
            {
                path = FileTxt.Text;
                var inputs = "";
                var models = ModelChk.CheckedItems.Cast<object>().Aggregate("", (current, model) => current + (model + ","));
                models = models.Length > 0 ? models.Remove(models.Length - 1) : "";
                var sens = ScenarioChk.CheckedItems.Cast<object>().Aggregate("", (current, sen) => current + (sen + ","));
                sens = sens.Length > 0 ? sens.Remove(sens.Length - 1) : "";
                inputs += "Main Database Folder : " + Environment.NewLine + FileTxt.Text + Environment.NewLine;
                inputs += "Historic Climate Data : " + Environment.NewLine + CruModel.Checked + Environment.NewLine;
                inputs += "Future Climate Models : " + Environment.NewLine + models + Environment.NewLine;
                inputs += "Carbon Emission Scenarios : " + Environment.NewLine + sens + Environment.NewLine;
                inputs += "Precipitation : " + Environment.NewLine + Precipitation.Checked + Environment.NewLine;
                inputs += "Temperature : " + Environment.NewLine + Temperature.Checked + Environment.NewLine;
                inputs += "BaseStartDate : " + Environment.NewLine + BaseStartDate.Text + Environment.NewLine;
                inputs += "BaseEndDate : " + Environment.NewLine + BaseEndDate.Text + Environment.NewLine;
                inputs += "FutStartDate : " + Environment.NewLine + FutStartDate.Text + Environment.NewLine;
                inputs += "FutEndDate : " + Environment.NewLine + FutEndDate.Text + Environment.NewLine;
                inputs += "Historic Climate Data (base) : " + Environment.NewLine + baseCru.Checked + Environment.NewLine;

                OutputRun(true);
                File.WriteAllText(outputPath + "/inputs.txt", inputs);

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
            outputPath = path.Split(new[] { @"\UserDatabase" }, StringSplitOptions.None).FirstOrDefault();
            outputPath = outputPath + @"\Average-Anomalies\Outputs_Average";
            System.Diagnostics.Process.Start(outputPath);
        }
        private void OutputAnomaly_Click(object sender, EventArgs e)
        {
            outputPath = path.Split(new[] { @"\UserDatabase" }, StringSplitOptions.None).FirstOrDefault();
            outputPath = outputPath + @"\Average-Anomalies\Outputs_Average_Anomaly";
            System.Diagnostics.Process.Start(outputPath);
        }
        private void CruModel_CheckedChanged(object sender, EventArgs e)
        {
            
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

        private void GCD_Load(object sender, EventArgs e)
        {
            frmParent = (AllInOneForm)this.MdiParent;
            curentDir = System.IO.Directory.GetCurrentDirectory();
            FileTxt.Text = StaticData.UserProjectFolder + @"\UserDatabase";

        }


        private void ObserveModel_CheckedChanged(object sender, EventArgs e)
        {
            
            if (ObserveModel.Checked)
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
                ModelChk.Items.Remove("ObservedData");
                ScenarioChk.Items.Remove("ObservedUser");
                ModelChk.SetItemChecked(ModelChk.Items.Count - 1, false);
                ModelChk.Enabled = true;
                ScenarioChk.SetItemChecked(ScenarioChk.Items.Count - 1, false);
                ScenarioChk.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void baseObserve_CheckedChanged(object sender, EventArgs e)
        {
            //  matchObserve.Enabled = baseObserve.Checked;
            //downscalingBtn.Enabled = baseObserve.Checked;
        }


        private List<Position> FindFileـJoinObserve(bool cru = false)
        {
            path = FileTxt.Text;
            var mainInput = path.Replace(UserDataFolder.Substring(1), "inputs.txt");
            var lines = File.ReadAllLines(mainInput);
            var LatitudeFrom = Convert.ToDouble("0");
            var LongitudeFrom = Convert.ToDouble("0");
            var LatitudeTo = Convert.ToDouble("0");
            var LongitudeTo = Convert.ToDouble("0");
        
                    LatitudeFrom = Convert.ToDouble(lines[13].ToString());
                
               
                    LatitudeTo = Convert.ToDouble(lines[15].ToString());
                
                    LongitudeFrom = Convert.ToDouble(lines[17].ToString());
              
                    LongitudeTo = Convert.ToDouble(lines[19].ToString());
                
            
            var observs = FindFileNamesObserve();
            //var latorder = observs.OrderBy(x => x.Latitude);
            //var observeStartLat = Convert.ToDouble(latorder.FirstOrDefault().Latitude);
            //var observeEndLat = Convert.ToDouble(latorder.LastOrDefault().Latitude);
            //var lonorder = observs.OrderBy(x => x.Longitude);
            //var observeStartLon = Convert.ToDouble(lonorder.FirstOrDefault().Longitude);
            //var observeEndLon = Convert.ToDouble(lonorder.LastOrDefault().Longitude);
            var allPos = new List<Position>();
            if (CruModel.Checked || ScenarioChk.CheckedItems.Contains("Historical") || cru)
            {
                allPos = FindFileNamesCru(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
            }
            else
            {
                allPos = FindFileNames(LatitudeFrom, LongitudeFrom, LatitudeTo, LongitudeTo);
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
                        }).ToList();
            return list;
        }
        private List<Position> FindFileNames(double LatitudeFrom, double LongitudeFrom, double LatitudeTo, double LongitudeTo)
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

        private void downscalingBtn_Click(object sender, EventArgs e)
        {


            // observes = FindFileـJoinObserve(true);
            //foreach (var observe in observes)
            //{
            //    var sourceFileName = observe.Main;
            //    var destinationFileName = observe.Cru;
            //    //copy
            //}
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
        private void ModelChk_MouseLeave(object sender, EventArgs e)
        {

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
    }
}
