namespace NetCorePortfolio.Models.Shared
{
    public class HeaderViewModel
    {
        public HeaderViewModel(string contactName, bool isResumeAvailable)
        {
            ContactName = contactName;
            IsResumeAvailable = isResumeAvailable;
        }

        public string ContactName { get; }

        public bool IsResumeAvailable { get; }
    }
}