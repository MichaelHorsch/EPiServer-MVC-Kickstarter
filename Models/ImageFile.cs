using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcKickstarter.Models
{
    [ContentType(DisplayName = "ImageFile", GUID = "1d497a10-2f4f-4088-b3c0-2abe026fe40c", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png,gif")]
    public class ImageFile : ImageData
    {
        [ImageDescriptor(Width = 48, Height = 48)]
        public override Blob Thumbnail
        {
            get { return base.Thumbnail; }
            set { base.Thumbnail = value; }
        }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Editable(true)]
        [Display(
            Name = "Description",
            Description = "Description field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Description { get; set; }
    }
}
