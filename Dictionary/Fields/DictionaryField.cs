using Etch.OrchardCore.Fields.Dictionary.Models;
using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.Dictionary.Fields
{
    public class DictionaryField : ContentField
    {
        public IList<DictionaryItem> Data { get; set; }
    }
}
