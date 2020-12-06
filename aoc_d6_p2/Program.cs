using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_d6_p2
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
            var results = new List<(Dictionary<char, int>, int)>();
            var currentResult = new Dictionary<char, int>();
            var currentGroupCount = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    results.Add((currentResult, currentGroupCount));
                    currentGroupCount = 0;
                    currentResult = new Dictionary<char, int>();
                }
                else
                {
                    currentGroupCount++;

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
                results.Add((currentResult, currentGroupCount));

            var sum = 0;
            foreach ((var answers, var count) in results)
            {
                foreach (var answer in answers)
                {
                    if (answer.Value == count)
                    {
                        sum += 1;
                    }
                }
            }

            Console.WriteLine($"The sum is: {sum}");
        }
    }
}
