using System;
using System.IO;
using System.Collections.Generic;

namespace aoc_d1_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dotnet aoc_d1_p2.dll <input_file>");
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

            for (int x = 0; x < nums.Count - 2; x++)
            {
                var num1 = int.Parse(nums[x]);

                for (int y = x + 1; y < nums.Count - 1; y++)
                {
                    var num2 = int.Parse(nums[y]);

                    for (int z = y + 1; z < nums.Count; z++)
                    {
                        var num3 = int.Parse(nums[z]);

                        if (num1 + num2 + num3 == 2020)
                        {
                            Console.WriteLine($"The answer is {num1} * {num2} * {num3} = {num1 * num2 * num3}");
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        break;
                }

                if (found)
                    break;
            }
        }
    }
}
