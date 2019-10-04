namespace NetCorePortfolio.Models.Shared
{
    public class SocialLink
    {
        public SocialLink()
        {
        }

        public SocialLink(string hyperLink, string fontAwesomeIconName)
        {
            HyperLink = hyperLink;
            FontAwesomeIconName = fontAwesomeIconName;
        }

        public string HyperLink { get; set; }

        public string FontAwesomeIconName { get; set; }
    }
}