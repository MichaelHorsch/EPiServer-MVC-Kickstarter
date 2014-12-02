using EPiServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcBootstrap.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// THis method takes a url and turns it into a friendly url.
        /// </summary>
        /// <param name="str">The url provided by EPiServer.</param>
        /// <returns>A human readable url.</returns>
        public static string GetFriendlyUrl(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                // Get the friendly URL
                var url = new UrlBuilder(str);

                // Only set it if the querylanguage is not already determined.
                if (string.IsNullOrEmpty(url.QueryLanguage))
                {
                    url.QueryLanguage = EPiServer.Globalization.ContentLanguage.PreferredCulture.Name;
                }

                if (EPiServer.Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.UTF8Encoding.UTF8))
                {
                    return url.ToString();
                }
            }

            // if its not an episerver page, just return original url
            return str;
        }

        public static bool IsExternalLink(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            return str.ToLower().StartsWith("http://") || str.ToLower().StartsWith("https://");
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string TrimToMaxSize(this string input, int max)
        {
            return ((input != null) && (input.Length > max)) ?
                input.Substring(0, max) : input;
        }
    }
}
