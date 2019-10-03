using System.Collections.Generic;

namespace NetCorePortfolio.Models.Home
{
    public class PortfolioItem
    {
        public PortfolioItem()
        {
            Tags = new List<string>();
        }

        public List<string> Tags { get; set; }

        public string ImageSrc { get; set; }

        public string SourceCodeSrc { get; set; }

        public string LiveDemoSrc { get; set; }

        public string Title { get; set; }
    }
}
