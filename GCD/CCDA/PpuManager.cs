using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ppu
{
   public static class PpuManager
   {
       public static string path;// = @"D:\myPpu\";
       public static string fileName;// = "95ppu_No_Obs.txt";
       public static void ReadPpu(int steps, int zones, int variables)
       {
           var ppus = File.ReadLines( fileName).ToList();
           for (int i = 0; i < variables; i ++)
           {
               //var startVar = 198*i;
               var startVar = i * zones * (steps + 3);
               for (int j = 0; j < zones; j++)
               {
                   var startIndex = startVar + (j * (steps + 3));
                   var textName = ppus[startIndex];
                   string[] lines=new string[steps+1];
                   lines[0] = textName;
                   for (int k = 0; k < steps; k++)
                   {
                       var theLine = ppus[startIndex + 2 + k];
                       var data=  theLine.Trim().Split(' ').LastOrDefault();
                       lines[k+1] = (k+1).ToString() + "\t" + data;

                   }
                   File.WriteAllLines(path+@"\" + textName + ".txt", lines);

               }
           }

       }
    }
}
