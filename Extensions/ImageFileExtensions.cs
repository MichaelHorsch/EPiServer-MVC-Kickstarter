using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Routing;
using EPiServerMvcBootstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcBootstrap.Extensions
{
    public static class ImageFileExtensions
    {
        /// <summary>
        /// Doing this complicated way for both cms preview and site images to work.
        /// </summary>
        /// <param name="imageFile">Pass in ContentReference image property</param>
        /// <param name="model">Model that property is on</param>
        /// <returns></returns>
        /// for pages
        public static string GetImageSrc(this ContentReference imageFile, BlockData model)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile)
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile)
                : null;

            string language = null;
            var iLocalizable = model as ILocalizable;
            if (iLocalizable != null && iLocalizable.Language != null)
            {
                language = iLocalizable.Language.Name;
            }

            var image = (ImageFile)currentContent;
            string imageUrl;
            if (image != null)
            {
                imageUrl = UrlResolver.Current.GetUrl(image.ContentLink, language, new VirtualPathArguments() { ContextMode = ContextMode.Default });
            }
            else
                imageUrl = "";


            return imageUrl;
        }

        //for blocks
        public static string GetImageSrc(this ContentReference imageFile, PageData model)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile)
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile)
                : null;

            string language = null;
            var iLocalizable = model as ILocalizable;
            if (iLocalizable != null && iLocalizable.Language != null)
            {
                language = iLocalizable.Language.Name;
            }

            var image = (ImageFile)currentContent;
            var imageUrl = UrlResolver.Current.GetUrl(image.ContentLink, language, new VirtualPathArguments() { ContextMode = ContextMode.Default });

            return imageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageFile">Pass in ImageFile directly from media assets</param>
        /// <param name="model">model that will hold media item</param>
        /// <returns></returns>
        /// for pages
        public static string GetImageSrc(this ImageFile imageFile, PageData model)
        {
            var currentContent = imageFile != null
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile.ContentGuid)
                : null;

            string language = null;
            var iLocalizable = model as ILocalizable;
            if (iLocalizable != null && iLocalizable.Language != null)
            {
                language = iLocalizable.Language.Name;
            }

            var image = (ImageFile)currentContent;
            var imageUrl = UrlResolver.Current.GetUrl(image.ContentLink, language, new VirtualPathArguments() { ContextMode = ContextMode.Default });

            return imageUrl;
        }

        //for blocks
        public static string GetImageSrc(this ImageFile imageFile, BlockData model)
        {
            var currentContent = imageFile != null
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile.ContentGuid)
                : null;

            string language = null;
            var iLocalizable = model as ILocalizable;
            if (iLocalizable != null && iLocalizable.Language != null)
            {
                language = iLocalizable.Language.Name;
            }

            var image = (ImageFile)currentContent;
            var imageUrl = UrlResolver.Current.GetUrl(image.ContentLink, language, new VirtualPathArguments() { ContextMode = ContextMode.Default });

            return imageUrl;
        }

        public static string GetImageAlt(this ContentReference imageFile)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile)
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile)
                : null;

            var image = (ImageFile)currentContent;

            return image.Description;
        }

        public static string GetImageAlt(this ImageFile imageFile)
        {
            var currentContent = imageFile != null
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile.ContentGuid)
                : null;

            var image = (ImageFile)currentContent;

            return image.Description;
        }
    }
}
