using System;
using System.Collections.Generic;
using System.IO;

namespace aoc_d5_p1
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
            lines.RemoveAll(n => string.IsNullOrEmpty(n));

            long highestSeatId = 0;

            foreach (var line in lines)
            {
                (var row, var column) = FindRowAndColumn(line);
                var seatId = (long)row * 8 + (long)column;

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }

            Console.WriteLine($"Highest seat Id: {highestSeatId}");
        }

        static (int, int) FindRowAndColumn(string input)
        {
            var minRow = 0;
            var maxRow = 127;
            var minSeat = 0;
            var maxSeat = 7;

            foreach (var ch in input.ToUpper())
            {
                if (ch == 'F')
                {
                    maxRow = minRow + ((maxRow - minRow) / 2);
                }
                else if (ch == 'B')
                {
                    minRow += 1 + ((maxRow - minRow) / 2);
                }
                else if (ch == 'L')
                {
                    maxSeat = minSeat + ((maxSeat - minSeat) / 2);
                }
                else if (ch == 'R')
                {
                    minSeat += 1 + ((maxSeat - minSeat) / 2);
                }
            }

            return (minRow, minSeat);
        }
    }
}
