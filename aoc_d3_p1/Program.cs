using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_d3_p1
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

            var rows = new List<string>(text.Split('\n'));
            rows.RemoveAll(n => string.IsNullOrEmpty(n));

            var right = 3;
            var down = 1;
            var goingDown = false;
            var currentX = 0;
            var downwardIncrement = 0;
            var encounteredTrees = 0;

            for (var i = 0; i < rows.Count; i++)
            {
                var row = rows[i];

                if (!goingDown)
                {
                    // Move right
                    while (currentX + right >= row.Length)
                    {
                        rows = rows.Select(s => $"{s}{s}").ToList();
                        row = rows[i];
                    }

                    currentX += right;
                    goingDown = true;
                }
                else
                {
                    // Move down
                    downwardIncrement++;

                    if (downwardIncrement >= down)
                    {
                        if (row[currentX] == '#')
                        {
                            encounteredTrees++;
                        }

                        // The next loop will increment i, but we must remain
                        // on this line to perform the next right movement
                        i--;
                        downwardIncrement = 0;
                        goingDown = false;
                    }
                }
            }

            Console.WriteLine($"There were {encounteredTrees} encountered trees");
        }
    }
}
