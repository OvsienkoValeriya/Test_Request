using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 1)
            {
                Reader(args[0], args[1]);
            }
            else if (args.Count() > 0)
            {
                Reader(args[0], @"Test_output.log");
            }
            else
            {
                Reader(@"Test.log", @"Test_output.log");
            }
        }
        public static void Reader(string filename, string outputFilename)
        {
            var regexp = new Regex(@"Request for (\S+)_(\S+)_(\S+)_(\S+)");
            using (StreamWriter file = new StreamWriter(outputFilename))
            {
                foreach (string line in File.ReadLines(filename, Encoding.UTF8))
                {
                    var date = DateTime.Now;
                    var newText = Process(line, date);
                    if (newText != null)
                    {
                        file.WriteLine(newText);
                    }
                }
            }
        }
        public static string Process(string input, DateTime date)
        {
            var regexp = new Regex(@"Request for (\S+)_(\S+)_(\S+)_(\S+)");
            var matches = regexp.Matches(input);
            if (matches.Count > 0)
            {
                var groups = matches[0].Groups;
                return ($"Дата записи: {date:d}, Время записи: {date:t}, {groups[1]}, {groups[2]}, {groups[3]}, {groups[4]}");
            }
            else
            {
                return null;
            }
        }
    }
}
