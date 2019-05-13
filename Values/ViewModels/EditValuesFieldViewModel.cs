using Etch.OrchardCore.Fields.Values.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.Values.ViewModels
{
    public class EditValuesFieldViewModel
    {
        public ValuesField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Data { get; set; }
    }
}
