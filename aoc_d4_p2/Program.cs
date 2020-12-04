using System;
using System.Collections.Generic;
using System.IO;

namespace aoc_d4_p2
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
            var currentPassport = new Passport();
            var validPassports = 0;
            var consuming = false;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    consuming = false;
                    if (currentPassport.IsValid)
                        validPassports++;
                    currentPassport = new Passport();
                }
                else
                {
                    // Consume the line
                    consuming = true;
                    var pairs = line.Split(' ');

                    foreach (var pair in pairs)
                    {
                        if (string.IsNullOrEmpty(pair))
                            continue;

                        var keyValue = pair.Split(':');

                        switch (keyValue[0])
                        {
                            case "byr":
                                currentPassport.BirthYear = keyValue[1];
                                break;

                            case "iyr":
                                currentPassport.IssueYear = keyValue[1];
                                break;

                            case "eyr":
                                currentPassport.ExpirationYear = keyValue[1];
                                break;

                            case "hgt":
                                currentPassport.Height = keyValue[1];
                                break;

                            case "hcl":
                                currentPassport.HairColor = keyValue[1];
                                break;

                            case "ecl":
                                currentPassport.EyeColor = keyValue[1];
                                break;

                            case "pid":
                                currentPassport.PassportId = keyValue[1];
                                break;

                            case "cid":
                                currentPassport.CountryId = keyValue[1];
                                break;
                        }
                    }
                }
            }

            // Check the last passport
            if (consuming && currentPassport.IsValid)
                validPassports++;

            Console.WriteLine($"{validPassports} valid passports found.");
        }
    }
}
