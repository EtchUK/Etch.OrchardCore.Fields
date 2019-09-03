using Etch.OrchardCore.Fields.EventBrite.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.EventBrite.ViewModels
{
    public class EditEventBriteFieldViewModel
    {
        public EventBriteField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Data { get; set; }
        public string Value { get; set; }
        public bool HasApiKey { get; set; }
    }
}