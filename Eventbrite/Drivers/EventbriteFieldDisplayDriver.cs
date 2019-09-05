using Etch.OrchardCore.Fields.Eventbrite.Fields;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using Etch.OrchardCore.Fields.Eventbrite.Models.Dto;
using Etch.OrchardCore.Fields.Eventbrite.Services;
using Etch.OrchardCore.Fields.Eventbrite.ViewModels;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Eventbrite.Drivers
{
    public class EventbriteFieldDisplayDriver : ContentFieldDisplayDriver<EventbriteField>
    {
        #region PublicVariables

        public IStringLocalizer T { get; set; }

        #endregion PublicVariables

        #region Dependencies

        private readonly IEventbriteSettingsService _eventbriteSettingsService;
        private readonly IHttpClientFactory _clientFactory;

        #endregion Dependencies

        #region Constructor

        public EventbriteFieldDisplayDriver(IStringLocalizer<EventbriteFieldDisplayDriver> localizer, IEventbriteSettingsService eventbriteSettingsService, IHttpClientFactory clientFactory)
        {
            T = localizer;
            _eventbriteSettingsService = eventbriteSettingsService;
            _clientFactory = clientFactory;
        }

        #endregion Constructor

        #region Implementation

        #region Display

        public override IDisplayResult Display(EventbriteField field, BuildFieldDisplayContext context)
        {
            if (field == null || field.Data == null)
            {
                return null;
            }

            return Initialize<DisplayEventbriteFieldViewModel>(GetDisplayShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
            })
            .Location("Content")
            .Location("SummaryAdmin", "");
        }

        #endregion Display

        #region Edit

        public override async Task<IDisplayResult> EditAsync(EventbriteField field, BuildFieldEditorContext context)
        {
            var settings = await _eventbriteSettingsService.GetSettingsAsync();

            return Initialize<EditEventbriteFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Value = field.Value;
                model.HasApiKey = !string.IsNullOrWhiteSpace(settings.PrivateToken);
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(EventbriteField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            var model = new EditEventbriteFieldViewModel();

            await updater.TryUpdateModelAsync(model, Prefix, m => m.Value);

            try
            {
                var settings = await _eventbriteSettingsService.GetSettingsAsync();

                if (string.IsNullOrWhiteSpace(settings.PrivateToken))
                {
                    updater.ModelState.AddModelError("Value", "Eventbrite API settings are not set correctly, please check these and try again.");
                }

                var url = GetUrl(updater, model);

                var eventbriteEventDto = await GetEventbriteEventDtoAsync(updater, settings, url);

                EventbriteVenueDto eventBriteVenueDto = await GetEventbriteVenueDtoAsync(updater, settings, eventbriteEventDto);

                if (updater.ModelState.ErrorCount > 0)
                {
                    return await EditAsync(field, context);
                }

                field.Value = model.Value;
                field.Data = new EventbriteEvent(eventbriteEventDto, eventBriteVenueDto);
            }
            catch
            {
                updater.ModelState.AddModelError("Value", "Something went wrong saving the event.");
            }

            return await EditAsync(field, context);
        }

        private async Task<EventbriteEventDto> GetEventbriteEventDtoAsync(IUpdateModel updater, EventbriteSettings settings, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", string.Format("Bearer {0}", settings.PrivateToken));

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                updater.ModelState.AddModelError("Value", "Error fetching event from Eventbrite API, please check the Event ID and API Credentials");
                return null;
            }
            return JsonConvert.DeserializeObject<EventbriteEventDto>(await response.Content.ReadAsStringAsync());
        }

        private async Task<EventbriteVenueDto> GetEventbriteVenueDtoAsync(IUpdateModel updater, EventbriteSettings settings, EventbriteEventDto eventBriteEventDto)
        {
            if (string.IsNullOrWhiteSpace(eventBriteEventDto.VenueId))
            {
                return null;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("https://www.eventbriteapi.com/v3/venues/{0}/", eventBriteEventDto.VenueId));
            request.Headers.Add("Authorization", string.Format("Bearer {0}", settings.PrivateToken));

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<EventbriteVenueDto>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        private string GetUrl(IUpdateModel updater, EditEventbriteFieldViewModel model)
        {
            if (model.Value.Contains("eid"))
            {
                if (int.TryParse(model.Value.Split('=').Last(), out var eventId))
                {
                    return string.Format("https://www.eventbriteapi.com/v3/events/{0}/", eventId);
                }

                updater.ModelState.AddModelError("Value", "Error parsing EventId from Url, please check the format and try again.");
                return string.Empty;
            }

            return string.Format("https://www.eventbriteapi.com/v3/events/{0}/", model.Value);
        }

        #endregion Edit

        #endregion Implementation
    }
}