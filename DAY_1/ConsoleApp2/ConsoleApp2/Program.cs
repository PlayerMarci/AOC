using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class AOC
    {
        public static List<int> first = new List<int>();
        public static List<int> second = new List<int>();
        public static Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
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
                string[] parts = line.Split(new string[] { "   " }, StringSplitOptions.RemoveEmptyEntries);
                int value1 = Convert.ToInt32(parts[0]);
                int value2 = Convert.ToInt32(parts[1]);

                AOC.first.Add(value1);
                AOC.second.Add(value2);

                line = streamReader.ReadLine();
            }

            streamReader.Close();
            fileStream.Close();
        }

        public static void AOC_2(int[] array1, int[] array2)
        {
            foreach (var item in array1)
            {
                if (AOC.keyValuePairs.ContainsKey(item))
                {
                    if (array2.Contains(item))
                    {
                        int num = array2.Count(x => x == item);
                        AOC.keyValuePairs[item] += num;
                    }
                    else
                    {
                        AOC.keyValuePairs.Add(item, 0);
                    }
                } else
                {
                    if (array2.Contains(item))
                    {
                        int num = array2.Count(x => x == item);
                        AOC.keyValuePairs.Add(item, num);
                    }
                    else
                    {
                        AOC.keyValuePairs.Add(item, 0);
                    }
                }
                
            }

            int sol = 0;

            foreach (var item in AOC.keyValuePairs)
            {
                sol += item.Key * item.Value;
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine(sol);

        }
        static void Main(string[] args)
        {

            string path = $@"C:\Users\szabomarton\Desktop\C#\ProgaOra\20241212\input.txt";
            ReadingInput(path);

            /*
            AOC.first.Add(3);
            AOC.first.Add(4);
            AOC.first.Add(2);
            AOC.first.Add(1);
            AOC.first.Add(3);
            AOC.first.Add(3);

            AOC.second.Add(4);
            AOC.second.Add(3);
            AOC.second.Add(5);
            AOC.second.Add(3);
            AOC.second.Add(9);
            AOC.second.Add(3);
            */
            AOC.first.Sort();
            AOC.second.Sort();

            AOC_2(AOC.first.ToArray(), AOC.second.ToArray());
        }
    }
}
