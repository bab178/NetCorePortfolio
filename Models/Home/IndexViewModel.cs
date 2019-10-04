using System.Collections.Generic;
using System.Linq;

namespace NetCorePortfolio.Models.Home
{
    public class IndexViewModel
    {
        public IndexViewModel(List<PortfolioItem> portfolioItems)
        {
            PortfolioItems = portfolioItems;
            TagList = PortfolioItems
                .SelectMany(p => p.Tags)
                .Distinct()
                .OrderBy(p => p)
                .ToList();
        }

        public List<PortfolioItem> PortfolioItems { get; set; }

        public List<string> TagList { get; set; }
    }
}
