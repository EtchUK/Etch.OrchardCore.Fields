using Etch.OrchardCore.Fields.EventBrite.Models.Dto;
using System;

namespace Etch.OrchardCore.Fields.EventBrite.Models
{
    public class EventBriteItem
    {
        #region Constructors

        public EventBriteItem()
        {
        }

        public EventBriteItem(EventBriteEventDto eventDto, EventBriteVenueDto venueDto)
        {
            Name = eventDto.name.text;
            StartDate = eventDto.start.utc;
            EndDate = eventDto.end.utc;
            Url = eventDto.url;

            if (venueDto == null)
            {
                return;
            }

            Address = string.Join(string.Format(",{0}", Environment.NewLine), venueDto.address.localized_multi_line_address_display);
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
    }
}