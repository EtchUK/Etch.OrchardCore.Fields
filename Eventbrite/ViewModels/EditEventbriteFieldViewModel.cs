using Etch.OrchardCore.Fields.Eventbrite.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.Eventbrite.ViewModels
{
    public class EditEventbriteFieldViewModel
    {
        public EventbriteField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }
        
        public string Value { get; set; }
    }
}