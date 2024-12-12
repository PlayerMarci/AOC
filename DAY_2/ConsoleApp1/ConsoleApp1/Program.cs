using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AOC
    {
        public static List<List<int>> rows = new List<List<int>>();
    }
    internal class Program
    {
        public static void ReadingInput(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            string line = streamReader.ReadLine();
            while (line != null)
            {
                List<int> ints = new List<int>();
                string[] parts = line.Split(' ');
                foreach (var item in parts)
                {
                    ints.Add(int.Parse(item));
                }

                AOC.rows.Add(ints);

                line = streamReader.ReadLine();
            }

            streamReader.Close();
            fileStream.Close();
        }

        public static int UnSafeNum()
        {
            int counter  = 0;

            foreach (var row in AOC.rows) {
                for (int i = 1; i < row.Count - 1; i++)
                {
                    int absDiffLeft = Math.Abs(row[i] - row[i - 1]);
                    int DiffRight = row[i + 1] - row[i];
                    int DiffLeft = row[i] - row[i - 1];
                    int absDiffRight = Math.Abs(DiffRight);

                    if (absDiffLeft <= 3 && absDiffRight <= 3 && ((DiffLeft > 0 && DiffRight > 0) || (DiffRight < 0 && DiffLeft < 0)))
                    {
                        continue;
                    } else
                    {
                        counter++;
                        break;
                    }
                }
            }
            return counter;
        }

        public static int SafeNum(List<List<int>> array)
        {
            int counter = 0;
            foreach (var row in array) {
                if (IsRowGood(row))
                {
                    counter++;
                    continue;
                }
                else { 

                }
            }

            return counter;
        }

        public static bool IsRowGood(List<int> row)
        {
            for (int i = 1; i < row.Count - 1; i++)
            {
                int absDiffLeft = Math.Abs(row[i] - row[i - 1]);
                int DiffRight = row[i + 1] - row[i];
                int DiffLeft = row[i] - row[i - 1];
                int absDiffRight = Math.Abs(DiffRight);


                if (absDiffLeft <= 3 && absDiffRight <= 3 && ((DiffLeft > 0 && DiffRight > 0) || (DiffRight < 0 && DiffLeft < 0)))
                {
                    continue;
                }
                else
                {
                    return false; 
                }
            }

            return true;
        }

        public static int UnSafeNum_2()
        {
            int counter = 0;

            foreach (var row in AOC.rows)
            {
                int rowcounter = 0;
                for (int i = 1; i < row.Count - 1; i++)
                {
                    int absDiffLeft = Math.Abs(row[i] - row[i - 1]);
                    int DiffRight = row[i + 1] - row[i];
                    int DiffLeft = row[i] - row[i - 1];
                    int absDiffRight = Math.Abs(DiffRight);


                    if (absDiffLeft <= 3 && absDiffRight <= 3 && ((DiffLeft > 0 && DiffRight > 0) || (DiffRight < 0 && DiffLeft < 0)))
                    {
                        continue;
                    }
                    else
                    {
                        rowcounter++;
                    }
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {

            //string path = $@"C:\Users\szabomarton\Desktop\AOC\DAY_2\testinput";
            string path = $@"C:\Users\szabomarton\Desktop\AOC\DAY_2\input";
            ReadingInput(path);

            //int unsafecount = UnSafeNum();
            //int safecount = AOC.rows.Count - unsafecount;

            int unsafecount = UnSafeNum_2();
            int safecount = AOC.rows.Count - unsafecount;
            Console.WriteLine(safecount);
        }
    }
}
