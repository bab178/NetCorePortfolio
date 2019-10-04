namespace NetCorePortfolio.Models.Shared
{
    public class CallToActionViewModel
    {
        public CallToActionViewModel(bool isHeader)
        {
            IsHeader = isHeader;
        }

        public bool IsHeader { get; }
    }
}
