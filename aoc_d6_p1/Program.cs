using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_d6_p1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dotnet aoc_d4_p2.dll <input_file>");
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

            var lines = new List<string>(text.Split('\n'));
            var results = new List<Dictionary<char, int>>();
            var currentResult = new Dictionary<char, int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    results.Add(currentResult);
                    currentResult = new Dictionary<char, int>();
                }
                else
                {
                    foreach (var ch in line)
                    {
                        if (currentResult.ContainsKey(ch))
                        {
                            currentResult[ch] += 1;
                        }
                        else
                        {
                            currentResult.Add(ch, 1);
                        }
                    }
                }
            }

            if (currentResult.Any())
                results.Add(currentResult);

            var sum = 0;
            foreach (var result in results)
            {
                sum += result.Count;
            }

            Console.WriteLine($"The sum is: {sum}");
        }
    }
}
