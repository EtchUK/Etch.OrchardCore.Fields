using Etch.OrchardCore.Fields.Eventbrite.Models;
using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.Fields.Eventbrite.Fields
{
    public class EventbriteField : ContentField
    {
        public string Value { get; set; }
        public EventbriteEvent Data { get; set; }
    }
}