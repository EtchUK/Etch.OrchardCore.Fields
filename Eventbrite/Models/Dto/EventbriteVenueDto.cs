using Newtonsoft.Json;

namespace Etch.OrchardCore.Fields.Eventbrite.Models.Dto
{
    public class EventbriteVenueDto
    {
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "resource_uri")]
        public string ResourceUri { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "age_restriction")]
        public object AgeRestriction { get; set; }

        [JsonProperty(PropertyName = "capacity")]
        public object Capacity { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }
    }

    public class Address
    {
        [JsonProperty(PropertyName = "address_1")]
        public string Address1 { get; set; }

        [JsonProperty(PropertyName = "address_2")]
        public string Address2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "localized_address_display")]
        public string LocalizedAddressDisplay { get; set; }

        [JsonProperty(PropertyName = "localized_area_display")]
        public string LocalizedAreaDisplay { get; set; }

        [JsonProperty(PropertyName = "localized_multi_line_address_display")]
        public string[] LocalizedMultiLineAddressDisplay { get; set; }
    }
}