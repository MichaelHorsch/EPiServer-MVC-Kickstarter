using EPiServer;
using EPiServer.Core;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcBootstrap.Extensions
{
    public static class LinkItemCollectionExtensions
    {
        /// <summary>
        /// Converts a LinkItemCollection object to a list of PageData objects representing the pages
        /// that each individual link in the collection is pointing at.
        /// </summary>
        /// <param name="col">The collection to convert.</param>
        /// <param name="publishedPagesOnly">Boolean which determines if only published pages are returned.</param>
        /// <returns>A list of PageData objects representing the pages that each individual link in the collection points at.</returns>
        public static List<PageData> ConvertToPageDataList(this LinkItemCollection col, bool publishedPagesOnly)
        {
            List<PageData> children = new List<PageData>();

            if (col != null)
            {
                foreach (LinkItem item in col)
                {
                    string childUrl = string.Empty;

                    PermanentLinkMapStore.TryToMapped(item.Href, out childUrl);

                    if (!string.IsNullOrEmpty(childUrl))
                    {
                        PageReference pageReference = PageReference.ParseUrl(childUrl);

                        if (!PageReference.IsNullOrEmpty(pageReference))
                        {
                            children.Add(DataFactory.Instance.GetPage(pageReference));
                        }
                    }

                    if (publishedPagesOnly)
                    {
                        children = children.Where(x => x.CheckPublishedStatus(PagePublishedStatus.Published)).ToList();
                    }
                }
            }

            return children;
        }
    }
}
