using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDA
{
    public class AnalyzeManager
    {
        public static string path;// = @"D:\myPpu\data\";
        public static string outPath;
        public static void Analyze(int daysCount, string preNames, string points, DateTime baseDate, string oprs, DateTime priodStartDate, DateTime priodEndDate, bool sumCheck, string totalPoints)
        {
            preNames = preNames.ToUpper();

            DirectoryInfo d = new DirectoryInfo(path);//get directory
            Directory.CreateDirectory(outPath);
            var inputs = new List<InputModel>();
            for (int i = 0; i < preNames.Split(',').Length; i++)
            {
                double totalPoint = 0;
                if (sumCheck)
                {
                    totalPoint = Convert.ToDouble(totalPoints.Split(',')[i]);
                }
                inputs.Add(new InputModel()
                {
                    Files = d.GetFiles("*" + preNames.Split(',')[i] + "*"),
                    Point = Convert.ToDouble(points.Split(',')[i]),
                    PreName = preNames.Split(',')[i],
                    SignNumber = oprs.Split(',')[i] == "gt" ? 1 : -1,
                    TotalPoint = totalPoint
                });
            }
            //var files = d.GetFiles("*"+preName + "*");//find all files that have preName
            List<string> totalReportLines = new List<string>();// total report
            totalReportLines.Add("index" + "\t\t" + "Count" + "\t\t" + "Avrage");
            var firstItem = inputs[0];
            for (int ind = 1; ind <= firstItem.Files.Length; ind++)//analys each file
            {

                var fileLines = new List<string[]>();
                var detailReportHeader = "index" + "\t\t" + "DaysCount" + "\t\t" + "StartDate" + "\t\t" + "EndDate";

                foreach (var input in inputs)
                {
                    var file = input.Files.SingleOrDefault(x => x.Name.Trim() == input.PreName + "_" + ind.ToString() + ".txt");
                    fileLines.Add(File.ReadAllLines(file.FullName));
                    detailReportHeader += "\t\tAvg_" + input.PreName;
                }
                var tempCounter = 0;
                List<string> detailReportlines = new List<string>();// detail report
                List<IterationInfo> iterations = new List<IterationInfo>();
                //  var lines = File.ReadAllLines(file.FullName);// read all lines of file
                detailReportlines.Add(detailReportHeader);
                double[] totals = new double[inputs.Count];
                var startIndex = (priodStartDate - baseDate).Days + 1;
                var endIndex = Math.Min((priodEndDate - baseDate).Days+1, fileLines[0].Length);

                for (int i = startIndex; i <= endIndex; i++) // read each line of file
                {
                    double[] tempsVal = new double[inputs.Count];
                    var isok = true;
                    for (int f = 0; f < inputs.Count; f++)
                    {
                        tempsVal[f] = 0;
                        var fileLine = fileLines[f];
                        var val = Convert.ToDouble(fileLine[i].Trim().Replace("\t", " ").Split(' ').LastOrDefault());
                        tempsVal[f] = val;

                        if ((val - inputs[f].Point) * inputs[f].SignNumber < 0)// sharayet bargharar nis
                        {
                            isok = false;
                            break;
                        }

                    }
                    if (isok == true)
                    {
                        for (int f = 0; f < inputs.Count; f++)
                        {
                            totals[f] += tempsVal[f];
                        }
                        tempCounter++;
                        if (sumCheck && tempCounter == daysCount)
                        {
                            var totOk = true;
                            for (int f = 0; f < inputs.Count; f++)
                            {
                                if ((totals[f] - inputs[f].TotalPoint) * inputs[f].SignNumber < 0)// sharayet bargharar nis
                                {
                                    totOk = false;
                                    break;
                                }
                            }
                            if (totOk)
                            {
                                AddIteration(ref tempCounter, ref detailReportlines, daysCount, ref iterations, baseDate, i, ref totals, sumCheck);// happen an itteration
                                totals = new double[inputs.Count];
                            }
                            else
                            {
                                i = i - tempCounter+1;
                                tempCounter=0;
                                totals = new double[inputs.Count];
                            }
                        }
                    }
                    else
                    {
                        if (!sumCheck)
                        {
                            AddIteration(ref tempCounter, ref detailReportlines, daysCount, ref iterations, baseDate, i, ref totals, sumCheck);// happen an itteration
                            totals = new double[inputs.Count];

                        }
                        else
                        {
                            tempCounter = 0;
                            totals = new double[inputs.Count];
                        }


                    }
                    //read last column of line

                }
                if (!sumCheck)
                {
                    AddIteration(ref tempCounter, ref detailReportlines, daysCount, ref iterations, baseDate, fileLines[0].Length, ref totals, sumCheck);// happen an itteration in end of File
                    totals = new double[inputs.Count];
                }
                else
                {
                    tempCounter = 0;
                    totals = new double[inputs.Count];
                }
                var newName = "";
                foreach (var input in inputs)
                {
                    newName += input.PreName + "_";

                }
                newName += ind + "_out.txt";
                File.WriteAllLines(outPath + @"\" + newName, detailReportlines);

                var totCounter = totalReportLines.Count;
                if (iterations.Count > 0)
                    totalReportLines.Add(totCounter + "\t\t" + iterations.Count + "\t\t" + iterations.Average(x => x.DaysCount));
                else
                    totalReportLines.Add(totCounter + "\t\t" + 0 + "\t\t" + 0);

            }
            File.WriteAllLines(outPath + @"\totalReport_out.txt", totalReportLines);
        }

        private static void AddIteration(ref int tempCounter, ref List<string> detailReportlines, int daysCount, ref List<IterationInfo> iterations, DateTime baseDate, long index, ref double[] total,bool sumCheck)
        {
            if (tempCounter >= daysCount) // happen an itteration in end of File
            {
                var theIteration = new IterationInfo()
                {
                    DaysCount = tempCounter,
                    EndDate = baseDate.AddDays(index - 2).ToShortDateString(),
                    StartDate = baseDate.AddDays(index - tempCounter - 1).ToShortDateString()
                };
                if (sumCheck)
                {
                    theIteration.EndDate = baseDate.AddDays(index - 1).ToShortDateString();
                    theIteration.StartDate = baseDate.AddDays(index - tempCounter).ToShortDateString();
                }
                
                iterations.Add(theIteration);
                var counter = detailReportlines.Count;
                var detailRow = counter.ToString() + "\t\t" + theIteration.DaysCount + "\t\t\t" + theIteration.StartDate +
                            "\t" + theIteration.EndDate;
                for (int i = 0; i < total.Length; i++)
                {
                    detailRow += "\t" + (total[i] / tempCounter).ToString("#.##") + "\t";
                    total[i] = 0;
                }
                detailReportlines.Add(detailRow);
            }

            tempCounter = 0;
        }
    }

    public class IterationInfo
    {
        public int DaysCount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class InputModel
    {
        public FileInfo[] Files { get; set; }
        public string PreName { get; set; }
        public double Point { get; set; }
        public int SignNumber { get; set; }
        public double TotalPoint { get; set; }
    }
}
