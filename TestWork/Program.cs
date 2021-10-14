using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            string pathStocks = "Files\\Stocks.txt";
            
            #region First Task
            
            string pathDays = "Files\\Days.txt";

            var days = new Parser().Day(pathStocks);

            using (StreamWriter streamWriter = new StreamWriter(pathDays))
            {
                foreach (var day in days)
                {
                    streamWriter.WriteLine($"In {day.Key} Max: {day.Max(a => (a.Split(',')[5]))}" +
                                           $"Min: {day.Min(a => (a.Split(',')[6]))}");
                }
            }

            #endregion

            #region Second Task
            
            string pathHours = "Files\\Hours.txt";

            var hours = new Parser().Hour(pathStocks);
            
            File.WriteAllLinesAsync(pathHours,hours);
            
            #endregion

            #region Thrird Task

            string pathFile1 = "Files\\file1.txt";
            string pathFile2 = "Files\\file2.txt";

            string pathNewStrings = "Files\\newstrings.txt";
            string pathLostStrings = "Files\\Loststrings.txt";
            string pathAllStrings = "Files\\allstrings.txt";

            new Parser().Files(pathFile1,pathFile2, out IEnumerable<string> newStrings,
                                                                out IEnumerable<string> lostStrings,
                                                                out IEnumerable<string> allStrings);
            
            File.WriteAllLinesAsync(pathNewStrings,newStrings);
            File.WriteAllLinesAsync(pathLostStrings,lostStrings);
            File.WriteAllLinesAsync(pathAllStrings,allStrings);

            #endregion

        }
    }
}