using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestWork
{
    public class Parser
    {
        public IOrderedEnumerable<IGrouping<string, string>> Day(string path)
        {
            try
            {
                var groupByDay = from line in File.ReadLines(path)
                    let lineToArray = line.Split(',')
                    group line by lineToArray[2]
                    into g
                    orderby g.Key
                    select g;
                
                return groupByDay;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public List<string> Hour(string path)
        {
            List<string> minToHours = new List<string>();


            IEnumerable<IGrouping<string, string>> groupByHors = null;
            try
            {
                    groupByHors = from line in File.ReadLines(path)
                            let x = line.Split(',')
                            group line by x[2] +","+ x[3].Substring(0,2)
                            into hours
                            select hours;
            }
            catch (Exception e) { }
            
            foreach (var hour in groupByHors)
            {
                string[] s = hour.First().Split(',');
                
                s[5] = hour.Max(a => a.Split(',')[5]);
                
                s[6] = hour.Min(a => a.Split(',')[6]);
                
                s[7] = hour.Last().Split(',')[7];
               
                try
                {
                    s[8] = hour.Sum(a => Double.Parse(a.Split(',')[8])).ToString();
                }
                catch (Exception e) { } 
                
                minToHours.Add(String.Join(",",s));
            }

            return minToHours;
        }

        public void Files(string path1,string path2, out IEnumerable<string> newStrings, out IEnumerable<string> lostStrings, out IEnumerable<string> allStrings)
        { 
            newStrings = File.ReadLines(path2).Except(File.ReadLines(path1));

            lostStrings = File.ReadLines(path1).Except(File.ReadLines(path2));
            
            allStrings = File.ReadLines(path1).Union(File.ReadLines(path2).Distinct());
        }
        
        
        
    }
}