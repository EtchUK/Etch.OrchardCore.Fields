﻿using Etch.OrchardCore.Fields.EventBrite.Models.Dto;
using System;

namespace Etch.OrchardCore.Fields.EventBrite.Models
{
    public class EventBriteEvent
    {
        #region Constructors

        public EventBriteEvent(EventBriteEventDto eventDto = null, EventBriteVenueDto venueDto = null)
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

        private void UpdateEventFields(EventBriteEventDto eventBriteEventDto)
        {
            Name = eventDto.name.text;
            StartDate = eventDto.start.utc;
            EndDate = eventDto.end.utc;
            Url = eventDto.url;
        }

        private void UpdateVenueFields(EventBriteVenueDto eventBriteVenueDto)
        {
            Address = string.Join(string.Format(",{0}", Environment.NewLine), venueDto.address.localized_multi_line_address_display);
        }

        #endregion Helpers
    }
}