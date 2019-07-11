using OrchardCore.ContentManagement;
using System;

namespace Etch.OrchardCore.Fields.MultiSelect.Fields
{
    public class MultiSelectField : ContentField
    {
        public string[] SelectedValues { get; set; } = Array.Empty<string>();
    }
}
