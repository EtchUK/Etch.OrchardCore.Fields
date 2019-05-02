using Moov2.OrchardCore.Fields.Dictionary.Models;
using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace Moov2.OrchardCore.Fields.Dictionary.Fields
{
    public class DictionaryField : ContentField
    {
        public IList<DictionaryItem> Data { get; set; } = new List<DictionaryItem>();
    }
}
