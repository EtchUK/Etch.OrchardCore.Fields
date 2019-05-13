using Etch.OrchardCore.Fields.Values.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.Values.ViewModels
{
    public class DisplayValuesFieldViewModel
    {
        public ValuesField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public IList<string> Data { get; set; }
    }
}
