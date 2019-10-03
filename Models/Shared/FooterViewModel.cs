using System.Collections.Generic;

namespace NetCorePortfolio.Models.Shared
{
    public class FooterViewModel
    {
        public FooterViewModel()
        {
            SocialLinks = GetSocialLinks();
        }

        private List<SocialLink> GetSocialLinks()
        {
            return new List<SocialLink>()
            {
                new SocialLink()
                {
                    HyperLink = "#",
                    FontAwesomeIconName = "pinterest"
                },
                new SocialLink()
                {
                    HyperLink = "#",
                    FontAwesomeIconName = "linkedin"
                },
                new SocialLink()
                {
                    HyperLink = "#",
                    FontAwesomeIconName = "instagram"
                },
                new SocialLink()
                {
                    HyperLink = "#",
                    FontAwesomeIconName = "facebook"
                },
                new SocialLink()
                {
                    HyperLink = "#",
                    FontAwesomeIconName = "twitter"
                }
            };
        }

        public List<SocialLink> SocialLinks { get; set; }
    }
}