using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc_d2_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dotnet aoc_d2_p2.dll <input_file>");
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
            lines.RemoveAll(n => string.IsNullOrEmpty(n));

            var validPasswords = 0;

            foreach (var line in lines)
            {
                var splitLine = line.Split(':');
                var rule = splitLine[0].Split(' ');
                var password = splitLine[1].Trim();
                var range = rule[0].Split('-');
                var validPos1 = int.Parse(range[0]);
                var validPos2 = int.Parse(range[1]);
                var expectedLetter = rule[1][0];

                if (validPos1 < 1 || validPos2 > password.Length)
                    continue;

                if ((password[validPos1 - 1] == expectedLetter && password[validPos2 - 1] != expectedLetter) ||
                    (password[validPos1 - 1] != expectedLetter && password[validPos2 - 1] == expectedLetter))
                {
                    validPasswords++;
                }
            }

            Console.WriteLine($"There are {validPasswords} valid passwords in the provided list.");
        }
    }
}
