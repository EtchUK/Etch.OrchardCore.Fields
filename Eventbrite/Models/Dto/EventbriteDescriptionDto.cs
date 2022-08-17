using Newtonsoft.Json;

namespace Etch.OrchardCore.Fields.Eventbrite.Models.Dto
{
    public class EventbriteDescriptionDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
