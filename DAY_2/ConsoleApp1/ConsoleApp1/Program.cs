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
                if (IsRowGood(row, 0))
                {
                    counter++;
                    continue;
                }
            }

            return counter;
        }

        public static bool IsRowGood(List<int> row, int depth)
        {
            if (depth > 1)
            {
                return false;
            }

            string line = "";
            foreach (var item in row)
            {
                line += $"[{Convert.ToString(item)}]";
            }

            Console.WriteLine($"{line}, depth: {depth}");

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var item in row)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 1);
                } else
                {
                    dict[item]++;
                }
            }

            foreach (var item in dict)
            {
                // that means 3 or more of the same numbers are in the list
                // so you have to go at least two deap
                // so it is straight up bad
                if (item.Value > 2)
                {
                    return false;
                }

                if (item.Value == 2)
                {
                    continue;
                }
            }

            for (int i = 0; i < row.Count - 1; i++)
            {
                //normally
                if (i - 1 >= 0 && i + 1 <= row.Count)
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
                        List<int> newrow = row;
                        newrow.RemoveAt(i);
                        return IsRowGood(newrow, depth + 1);
                    }
                } 
                else
                {   
                    //if it is the left most piece
                    if (i == 0)
                    {
                        int firstDiff = row[i + 1] - row[i];
                        int secondDiff = row[i + 2] - row[i + 1];
                        bool notZero = BothNegative(firstDiff, secondDiff) || BothPositive(firstDiff, secondDiff);
                        if (Math.Abs(firstDiff) <= 3 && Math.Abs(secondDiff) <= 3  && notZero)
                        {
                            continue;
                        } 
                        else
                        {
                            List<int> newrow = row;
                            newrow.RemoveAt(i);
                            return IsRowGood(newrow, depth + 1);
                        }
                    } 
                    else if (i == row.Count - 1) //if it is the right most
                    {
                        int firstDiff = row[i] - row[i - 1];
                        int secondDiff = row[i - 1] - row[i - 2];
                        bool notZero = BothNegative(firstDiff, secondDiff) || BothPositive(firstDiff, secondDiff);
                        if (Math.Abs(firstDiff) <= 3 && Math.Abs(secondDiff) <= 3 && notZero)
                        {
                            continue;
                        }
                        else
                        {
                            List<int> newrow = row;
                            newrow.RemoveAt(i);
                            return IsRowGood(newrow, depth + 1);
                        }
                    }
                }
                
            }

            return true;
        }

        public static bool BothPositive(int first, int second)
        {
            if (first > 0 && second > 0)
            {
                return true;
            }
            return false;
        }

        public static bool BothNegative(int first, int second)
        {
            if (first < 0 && second < 0)
            {
                return true;
            }
            return false;
        }



        static void Main(string[] args)
        {

            string path = $@"..\..\..\..\testinput";
            //string path = $@"..\..\..\..\input";
            ReadingInput(path);

            //int unsafecount = UnSafeNum();
            //int safecount = AOC.rows.Count - unsafecount;

            int safecount = SafeNum(AOC.rows);
            
            Console.WriteLine(safecount);
        }
    }
}
