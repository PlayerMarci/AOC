using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AOC
    {
        public static List<int> multiples = new List<int>();
        public static List<string> rows = new List<string>();
        public static string regexPattern = "mul([0-9]+,[0-9]+)";
    }
    internal class Program
    {
        
        public static void ReadInput(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            string line = streamReader.ReadLine();
            while (line != null)
            {
                AOC.rows.Add(line);

                line = streamReader.ReadLine();
            }
            streamReader.Close();
            fileStream.Close();
        }

        public static void CalculateRow(string row)
        {
            //Regex regex = new Regex();
            var match = Regex.Matches(row, AOC.regexPattern);
            foreach (var item in match)
            {
                //item.ToString();

                //int[] nums = Regex.Matches(, "[0-9]+");
                Console.WriteLine(item);
            }

        }
        static void Main(string[] args)
        {
            string path = @"../../../../input.txt";
            ReadInput(path);
            CalculateRow(AOC.rows[0]);
        }
    }
}
