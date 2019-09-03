using Etch.OrchardCore.Fields.EventBrite.Models;
using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.EventBrite.Fields
{
    public class EventBriteField : ContentField
    {
        public string Value { get; set; }
        public EventBriteItem EventBriteData { get; set; }
    }
}