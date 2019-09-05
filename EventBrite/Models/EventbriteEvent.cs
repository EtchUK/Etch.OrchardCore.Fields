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

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Url { get; set; }

        #endregion Event Fields

        #region Venue Fields

        public string Address { get; set; }

        #endregion Venue Fields

        #region Helpers

        private void UpdateEventFields(EventbriteEventDto eventBriteEventDto)
        {
            Name = eventBriteEventDto.Name.Text;
            StartDate = eventBriteEventDto.Start.Utc;
            EndDate = eventBriteEventDto.End.Utc;
            Url = eventBriteEventDto.Url;
        }

        private void UpdateVenueFields(EventbriteVenueDto eventBriteVenueDto)
        {
            Address = string.Join(string.Format(",{0}", Environment.NewLine), eventBriteVenueDto.Address.LocalizedMultiLineAddressDisplay);
        }

        #endregion Helpers
    }
}