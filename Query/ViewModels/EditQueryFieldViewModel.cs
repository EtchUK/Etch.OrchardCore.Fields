using Etch.OrchardCore.Fields.Query.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.Query.ViewModels
{
    public class EditQueryFieldViewModel
    {
        public QueryField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public IEnumerable<string> Queries { get; set; }
        public string Value { get; set; }
    }
}
