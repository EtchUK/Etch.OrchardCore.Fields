using Etch.OrchardCore.Fields.Code.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.Code.ViewModels
{
    public class EditCodeFieldViewModel
    {
        public CodeField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Value { get; set; }
    }
}
