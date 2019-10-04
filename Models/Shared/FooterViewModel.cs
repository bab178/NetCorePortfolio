using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace NetCorePortfolio.Models.Shared
{
    public class FooterViewModel
    {
        public FooterViewModel(string contactName, IConfiguration configuration)
        {
            ContactName = contactName;

            var socialLinks = new List<SocialLink>();
            configuration.GetSection("SocialLinks").Bind(socialLinks);

            SocialLinks = socialLinks;
        }

        public string ContactName { get; }

        public List<SocialLink> SocialLinks { get; }
    }
}