using EPiServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcBootstrap.Extensions
{
    public static class UrlExtensions
    {
        public static string GetFriendlyUrl(this Url url)
        {
            return url.ToString().GetFriendlyUrl();
        }
    }
}
