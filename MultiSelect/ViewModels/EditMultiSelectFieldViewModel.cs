using Etch.OrchardCore.Fields.MultiSelect.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System;

namespace Etch.OrchardCore.Fields.MultiSelect.ViewModels
{
    public class EditMultiSelectFieldViewModel
    {
        public MultiSelectField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string[] SelectedValues { get; set; } = Array.Empty<string>();
    }
}
