using Etch.OrchardCore.Fields.Dictionary.Fields;
using Etch.OrchardCore.Fields.Dictionary.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.Dictionary.ViewModels
{
    public class DisplayDictionaryFieldViewModel
    {
        public DictionaryField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public IList<DictionaryItem> Data { get; set; }
    }
}
