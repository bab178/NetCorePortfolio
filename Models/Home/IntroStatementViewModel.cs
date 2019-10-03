using System;

namespace NetCorePortfolio.Models.Home
{
    public class IntroStatementViewModel
    {
        private static readonly int _startingYear = DateTime.UtcNow.Year - 2;

        public int YearsExperience => DateTime.UtcNow.Year - _startingYear;

        public string JobTitle => "X";
    }
}