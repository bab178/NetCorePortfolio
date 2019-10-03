using System;

namespace NetCorePortfolio.Models.Home
{
    public class IntroStatementViewModel
    {
        public IntroStatementViewModel(int startingYear, string jobTitle)
        {
            YearsExperience = DateTime.UtcNow.Year - startingYear;
            JobTitle = jobTitle;
        }

        public int YearsExperience { get; }

        public string JobTitle { get; }
    }
}