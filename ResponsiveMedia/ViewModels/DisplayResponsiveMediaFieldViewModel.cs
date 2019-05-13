using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using Etch.OrchardCore.Fields.ResponsiveMedia.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.ViewModels
{
    public class DisplayResponsiveMediaFieldViewModel
    {
        public ResponsiveMediaField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public IList<Models.ResponsiveMediaItem> Media { get; set; }
    }
}
