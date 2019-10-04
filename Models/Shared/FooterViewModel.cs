using System.Collections.Generic;

namespace NetCorePortfolio.Models.Shared
{
    public class FooterViewModel
    {
        public FooterViewModel(string contactName)
        {
            ContactName = contactName;
            SocialLinks = GetSocialLinks();
        }

        public string ContactName { get; }

        public List<SocialLink> SocialLinks { get; }

        private List<SocialLink> GetSocialLinks()
        {
            return new List<SocialLink>()
            {
                new SocialLink("#", "pinterest"),
                new SocialLink("#", "linkedin"),
                new SocialLink("#", "instagram"),
                new SocialLink("#", "facebook"),
                new SocialLink("#", "twitter")
            };
        }
    }
}