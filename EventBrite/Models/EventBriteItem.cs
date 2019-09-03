using Etch.OrchardCore.Fields.EventBrite.Models.Dto;
using System;

namespace Etch.OrchardCore.Fields.EventBrite.Models
{
    public class EventBriteItem
    {
        public EventBriteItem()
        {
        }

        public EventBriteItem(EventBriteEventDto eventDto)
        {
            UpdateFromEventDto(eventDto);
        }

        public EventBriteItem(EventBriteEventDto eventDto, EventBriteVenueDto venueDto)
        {
            UpdateFromEventDto(eventDto);

            Address = string.Join(",\n", venueDto.address.localized_multi_line_address_display);
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Url { get; set; }

        public string Address { get; set; }

        #region Helpers

        private void UpdateFromEventDto(EventBriteEventDto eventDto)
        {
            Name = eventDto.name.text;
            StartDate = eventDto.start.utc;
            EndDate = eventDto.end.utc;
            Url = eventDto.url;
        }

        #endregion Helpers
    }
}