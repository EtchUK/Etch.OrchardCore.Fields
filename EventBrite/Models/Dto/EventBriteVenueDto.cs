using System;
using System.Collections.Generic;
using System.Text;

namespace Etch.OrchardCore.Fields.EventBrite.Models.Dto
{
    public class EventBriteVenueDto
    {
        public Address address { get; set; }
        public string resource_uri { get; set; }
        public string id { get; set; }
        public object age_restriction { get; set; }
        public object capacity { get; set; }
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Address
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string localized_address_display { get; set; }
        public string localized_area_display { get; set; }
        public string[] localized_multi_line_address_display { get; set; }
    }
}