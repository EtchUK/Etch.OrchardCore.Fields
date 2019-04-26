using Moov2.OrchardCore.Fields.ResponsiveMedia.Fields;
using Moov2.OrchardCore.Fields.ResponsiveMedia.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Collections.Generic;

namespace Moov2.OrchardCore.Fields.ResponsiveMedia.ViewModels
{
    public class DisplayResponsiveMediaFieldViewModel
    {
        public ResponsiveMediaField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public IList<Models.ResponsiveMediaItem> Media { get; set; }
    }
}
