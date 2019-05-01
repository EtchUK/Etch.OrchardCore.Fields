using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace Moov2.OrchardCore.Fields.Dictionary.Fields
{
    public class DictionaryField : ContentField
    {
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
    }
}
