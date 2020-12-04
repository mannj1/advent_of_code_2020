namespace aoc_d4_p1
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

        public bool IsValid => !string.IsNullOrEmpty(BirthYear) && !string.IsNullOrEmpty(IssueYear) && !string.IsNullOrEmpty(ExpirationYear) && !string.IsNullOrEmpty(Height) && !string.IsNullOrEmpty(HairColor) && !string.IsNullOrEmpty(EyeColor) && !string.IsNullOrEmpty(PassportId);
    }
}
