using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.Values.Fields
{
    public class ValuesField : ContentField
    {
        public IList<string> Data { get; set; } = new List<string>();
    }
}
