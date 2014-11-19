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
        public static string GetImageAlt(this ContentReference imageFile)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile)
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile)
                : null;

            var image = (ImageFile)currentContent;

            return GetImageAlt(image);
        }

        public static string GetImageAlt(this ImageFile imageFile)
        {
            if (imageFile != null)
            {
                return imageFile.Description;
            }
            else
            {
                return null;
            }
        }

        public static string GetImageSrc(this ContentReference imageFile, BlockData model)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile)
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile)
                : null;

            var theFile = (ImageFile)currentContent;
            return theFile.GetImageSrc(model);
        }

        public static string GetImageSrc(this ImageFile imageFile, BlockData model)
        {
            string language = null;
            var iLocalizable = model as ILocalizable;
            if (iLocalizable != null && iLocalizable.Language != null)
            {
                language = iLocalizable.Language.Name;
            }

            string imageUrl = string.Empty;
            if (imageFile != null)
            {
                imageUrl = UrlResolver.Current.GetUrl(imageFile.ContentLink, language, new VirtualPathArguments() { ContextMode = ContextMode.Default });
            }

            return imageUrl;
        }

        public static string GetImageSrc(this ContentReference imageFile, PageData model)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile)
                ? EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageFile)
                : null;

            var theFile = ((ImageFile)currentContent);
            return theFile.GetImageSrc(model);
        }

        public static string GetImageSrc(this ImageFile imageFile, PageData model)
        {
            string language = null;
            var iLocalizable = model as ILocalizable;
            if (iLocalizable != null && iLocalizable.Language != null)
            {
                language = iLocalizable.Language.Name;
            }

            string imageUrl = string.Empty;
            if (imageFile != null)
            {
                imageUrl = UrlResolver.Current.GetUrl(imageFile.ContentLink, language, new VirtualPathArguments() { ContextMode = ContextMode.Default });
            }

            return imageUrl;
        }
    }
}
