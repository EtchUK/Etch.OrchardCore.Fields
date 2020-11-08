using Etch.OrchardCore.Fields.Eventbrite.Fields;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.Eventbrite.ViewModels
{
    public class DisplayEventbriteFieldViewModel
    {
        public EventbriteField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public EventbriteEvent Data
        {
            get
            {
                return Field.Data;
            }
        }
    }
}