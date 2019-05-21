using Newtonsoft.Json;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Models
{
    public class ResponsiveMediaSource
    {
        [JsonProperty("breakpoint")]
        public int? Breakpoint { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
