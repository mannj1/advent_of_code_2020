using System;
using System.IO;
using System.Collections.Generic;

namespace aoc_d1_p1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dotnet aoc_d1_p1.dll <input_file>");
                return;
            }

            var filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: Invalid file path");
                return;
            }

            var text = File.ReadAllText(filePath);
            text = text.Replace("\r", "");
            var nums = new List<string>(text.Split('\n'));
            nums.RemoveAll(n => string.IsNullOrEmpty(n));
            var found = false;

            for (int x = 0; x < nums.Count - 1; x++)
            {
                var num1 = int.Parse(nums[x]);

                for (int y = x + 1; y < nums.Count; y++)
                {
                    var num2 = int.Parse(nums[y]);

                    if (num1 + num2 == 2020)
                    {
                        Console.WriteLine($"The answer is {num1} * {num2} = {num1 * num2}");
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
            }
        }
    }
}
