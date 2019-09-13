using Etch.OrchardCore.Fields.Eventbrite.Models.Dto;
using System;

namespace Etch.OrchardCore.Fields.Eventbrite.Models
{
    public class EventbriteEvent
    {
        #region Constructors

        public EventbriteEvent(EventbriteEventDto eventDto = null, EventbriteVenueDto venueDto = null)
        {
            if (eventDto != null)
            {
                UpdateEventFields(eventDto);
            }

            if (venueDto != null)
            {
                UpdateVenueFields(venueDto);
            }
        }

        #endregion Constructors

        #region Event Fields

        public int Capacity { get; set; }
        public Description Description { get; set; }
        public DateTime EndUtc { get; set; }
        public bool HideEndDate { get; set; }
        public bool HideStartDate { get; set; }
        public string Name { get; set; }
        public DateTime StartUtc { get; set; }
        public string Url { get; set; }
        public string VanityUrl { get; set; }

        #endregion Event Fields

        #region Venue Fields

        public Address Address { get; set; }
        public string MultiLineAddress { get; set; }
        public DateTime Published { get; set; }
        public string Summary { get; set; }
        public object VenueCapacity { get; set; }
        public string VenueName { get; set; }

        #endregion Venue Fields

        #region Helpers

        private void UpdateEventFields(EventbriteEventDto eventBriteEventDto)
        {
            Capacity = eventBriteEventDto.Capacity;
            Description = eventBriteEventDto.Description;
            EndUtc = eventBriteEventDto.End.Utc;
            HideEndDate = eventBriteEventDto.HideEndDate;
            HideStartDate = eventBriteEventDto.HideStartDate;
            Name = eventBriteEventDto.Name.Text;
            Published = eventBriteEventDto.Published;
            StartUtc = eventBriteEventDto.Start.Utc;
            Summary = eventBriteEventDto.Summary;
            Url = eventBriteEventDto.Url;
            VanityUrl = eventBriteEventDto.VanityUrl;
        }

        private void UpdateVenueFields(EventbriteVenueDto eventBriteVenueDto)
        {
            Address = eventBriteVenueDto.Address;
            MultiLineAddress = string.Join(string.Format(",{0}", Environment.NewLine), eventBriteVenueDto.Address.LocalizedMultiLineAddressDisplay);
            VenueCapacity = eventBriteVenueDto.Capacity;
            VenueName = eventBriteVenueDto.Name;
        }

        #endregion Helpers
    }
}