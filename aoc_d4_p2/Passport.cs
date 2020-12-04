using System.Linq;

namespace aoc_d4_p2
{
    class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid => Validate();

        private bool Validate()
        {
            bool result = !string.IsNullOrEmpty(BirthYear) && !string.IsNullOrEmpty(IssueYear) && !string.IsNullOrEmpty(ExpirationYear) && !string.IsNullOrEmpty(Height) && !string.IsNullOrEmpty(HairColor) && !string.IsNullOrEmpty(EyeColor) && !string.IsNullOrEmpty(PassportId);

            if (result)
            {
                var parseResult = int.TryParse(BirthYear, out var iBirthYear);
                result = result && BirthYear.Length == 4 && parseResult && iBirthYear >= 1920 && iBirthYear <= 2002;

                parseResult = int.TryParse(IssueYear, out var iIssueYear);
                result = result && IssueYear.Length == 4 && parseResult && iIssueYear >= 2010 && iIssueYear <= 2020;

                parseResult = int.TryParse(ExpirationYear, out var iExpYear);
                result = result && ExpirationYear.Length == 4 && parseResult && iExpYear >= 2020 && iExpYear <= 2030;

                Height = Height.ToLower();
                if (Height.EndsWith("cm"))
                {
                    var sHeight = Height.Replace("cm", "");
                    parseResult = int.TryParse(sHeight, out var iHeight);
                    result = result && parseResult && iHeight >= 150 && iHeight <= 193;
                }
                else if (Height.EndsWith("in"))
                {
                    var sHeight = Height.Replace("in", "");
                    parseResult = int.TryParse(sHeight, out var iHeight);
                    result = result && parseResult && iHeight >= 59 && iHeight <= 76;
                }
                else
                    return false;

                var hex = "0123456789abcdef";
                result = result && HairColor.StartsWith("#") && HairColor.Length == 7 && HairColor.Remove(0, 1).ToLower().All(a => hex.Contains(a));

                EyeColor = EyeColor.ToLower();
                result = result && (EyeColor == "amb" || EyeColor == "blu" || EyeColor == "brn" || EyeColor == "gry" || EyeColor == "grn" || EyeColor == "hzl" || EyeColor == "oth");

                parseResult = int.TryParse(PassportId, out var iPassportId);
                result = result && PassportId.Length == 9 && parseResult;
            }

            return result;
        }
    }
}
