namespace NetCorePortfolio.Models.Shared
{
    public class HeaderViewModel
    {
        public HeaderViewModel(string contactName)
        {
            ContactName = contactName;
        }

        public string ContactName { get; }
    }
}