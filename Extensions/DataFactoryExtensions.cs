using EPiServer;
using EPiServer.Core;
using EPiServerMvcBootstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcBootstrap.Extensions
{
    public static class DataFactoryExtensions
    {
        /// <summary>
        /// Gets the start page and casts it.
        /// </summary>
        /// <typeparam name="T">The type of the start page</typeparam>
        /// <param name="factory">The datafactory</param>
        /// <returns>The start page casted as type T.</returns>
        public static T CastedStartPage<T>(this DataFactory factory) where T : TypedPageData
        {
            var start = DataFactory.Instance.GetPage(PageReference.StartPage);
            return (T)start;
        }

        /// <summary>
        /// Retrieves all child pages (first-level, only) of a particular type.
        /// </summary>
        /// <typeparam name="T">Type of child pages that should be returned</typeparam>
        /// <param name="dataFactory">A reference to the DataFactory used to perform the query.</param>
        /// <param name="pageLink">A link to the page that should serve as the starting point of the search (the parent).</param>
        /// <returns>An IEnumerable object containing all of the child pages of the type.</returns>
        public static IEnumerable<T> GetChildrenOfType<T>(this DataFactory dataFactory, PageReference pageLink)
            where T : PageData
        {
            return dataFactory.GetChildren(pageLink).OfType<T>();
        }

        /// <summary>
        /// Retrieves all child pages (possibly recursively) of a particular type.
        /// </summary>
        /// <typeparam name="T">Type of child pages that should be returned</typeparam>
        /// <param name="dataFactory">A reference to the DataFactory used to perform the query.</param>
        /// <param name="pageLink">A link to the page that should serve as the starting point of the search (the parent).</param>
        /// <param name="recursive">Determines if the fetch should search recursively through child nodes.</param>
        /// <returns>An IEnumerable object containing all of the child pages of the type.</returns>
        public static IEnumerable<T> GetChildrenOfType<T>(this DataFactory dataFactory, PageReference pageLink, bool recursive)
            where T : PageData
        {
            // Get all children and iterate over them.
            // Get matching children and add to our results list.
            // -- Inside iteration, we call GetChildrenOfTypeRecursive and append the results to our list.

            var children = dataFactory.GetChildren(pageLink);
            var results = dataFactory.GetChildrenOfType<T>(pageLink).ToList();

            foreach (var child in children)
            {
                results.AddRange(dataFactory.GetChildrenOfType<T>((PageReference)child.ContentLink, recursive));
            }

            return results;
        }
    }
}
