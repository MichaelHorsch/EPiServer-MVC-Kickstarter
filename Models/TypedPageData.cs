using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiServerMvcKickstarter.Models
{
    public abstract class TypedPageData : PageData
    {
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "META Description",
            Description = "The text that will be inserted into the 'Description' META element. ",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string MetaDescription { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "META Keywords",
            Description = "The text that will be inserted into the 'Keywords' META element. ",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string MetaKeywords { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Page Title",
            Description = "The text that will be inserted into the HTML 'Title' element. ",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string PageTitle { get; set; }
    }
}
