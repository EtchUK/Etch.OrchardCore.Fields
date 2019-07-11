using Etch.OrchardCore.Fields.MultiSelect.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.MultiSelect.ViewModels
{
    public class DisplayMultiSelectFieldViewModel
    {
        public MultiSelectField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string[] SelectedValues { get; set; }

        public bool HasValues
        {
            get { return SelectedValues != null && SelectedValues.Length > 0; }
        }
    }
}
