using Etch.OrchardCore.Fields.EventBrite.Fields;
using Etch.OrchardCore.Fields.EventBrite.Models;
using Etch.OrchardCore.Fields.EventBrite.Models.Dto;
using Etch.OrchardCore.Fields.EventBrite.Services;
using Etch.OrchardCore.Fields.EventBrite.ViewModels;
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

namespace Etch.OrchardCore.Fields.EventBrite.Drivers
{
    public class EventBriteFieldDisplayDriver : ContentFieldDisplayDriver<EventBriteField>
    {
        #region PublicVariables

        public IStringLocalizer T { get; set; }

        #endregion PublicVariables

        #region Dependencies

        private readonly IEventBriteSettingsService _eventBriteSettingsService;
        private readonly IHttpClientFactory _clientFactory;

        #endregion Dependencies

        #region Constructor

        public EventBriteFieldDisplayDriver(IStringLocalizer<EventBriteFieldDisplayDriver> localizer, IEventBriteSettingsService eventBriteSettingsService, IHttpClientFactory clientFactory)
        {
            T = localizer;
            _eventBriteSettingsService = eventBriteSettingsService;
            _clientFactory = clientFactory;
        }

        #endregion Constructor

        #region Implementation

        #region Display

        public override IDisplayResult Display(EventBriteField field, BuildFieldDisplayContext context)
        {
            return Initialize<DisplayEventBriteFieldViewModel>(GetDisplayShapeType(context), model =>
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

        public override async Task<IDisplayResult> EditAsync(EventBriteField field, BuildFieldEditorContext context)
        {
            var settings = await _eventBriteSettingsService.GetSettingsAsync();

            return Initialize<EditEventBriteFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;

                model.Data = JsonConvert.SerializeObject(field.EventBriteData == null ? new EventBriteItem() : field.EventBriteData);
                model.HasApiKey = !string.IsNullOrWhiteSpace(settings.PrivateToken);
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(EventBriteField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            var model = new EditEventBriteFieldViewModel();

            await updater.TryUpdateModelAsync(model, Prefix, m => m.Data);

            try
            {
                var settings = await _eventBriteSettingsService.GetSettingsAsync();

                if (string.IsNullOrWhiteSpace(settings.PrivateToken))
                {
                    updater.ModelState.AddModelError("Value", "Eventbrite API settings are not set correctly, please check these and try again.");
                }

                var url = GetUrl(updater, model);

                var eventBriteEventDto = await GetEventBriteEventDtoAsync(updater, settings, url);

                EventBriteVenueDto eventBriteVenueDto = await GetEventBriteVenueDtoAsync(updater, settings, eventBriteEventDto);

                if (updater.ModelState.ErrorCount > 0)
                {
                    return Edit(field, context);
                }

                field.EventBriteData = new EventBriteItem(eventBriteEventDto, eventBriteVenueDto);
            }
            catch (Exception e)
            {
                updater.ModelState.AddModelError("Value", "Something went wrong saving the event");
            }

            return Edit(field, context);
        }

        private async Task<EventBriteEventDto> GetEventBriteEventDtoAsync(IUpdateModel updater, EventBriteSettings settings, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", string.Format("Bearer {0}", settings.PrivateToken));

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                updater.ModelState.AddModelError("Value", "Error fetching event from EventBrite API, please check the Event ID and API Credentials");
                return null;
            }
            return JsonConvert.DeserializeObject<EventBriteEventDto>(await response.Content.ReadAsStringAsync());
        }

        private async Task<EventBriteVenueDto> GetEventBriteVenueDtoAsync(IUpdateModel updater, EventBriteSettings settings, EventBriteEventDto eventBriteEventDto)
        {
            if (string.IsNullOrWhiteSpace(eventBriteEventDto.venue_id))
            {
                return null;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("https://www.eventbriteapi.com/v3/venues/{0}/", eventBriteEventDto.venue_id));
            request.Headers.Add("Authorization", string.Format("Bearer {0}", settings.PrivateToken));

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<EventBriteVenueDto>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        private string GetUrl(IUpdateModel updater, EditEventBriteFieldViewModel model)
        {
            if (model.Field.Value.Contains("eid"))
            {
                if (int.TryParse(model.Field.Value.Split('=').Last(), out var eventId))
                {
                    string.Format("https://www.eventbriteapi.com/v3/events/{0}/", eventId);
                }
                else
                {
                    updater.ModelState.AddModelError("Value", "Error parsing EventId from Url, please check the format and try again.");
                }
            }
            else
            {
                if (int.TryParse(model.Field.Value.Split('=').Last(), out var eventId))
                {
                    return string.Format("https://www.eventbriteapi.com/v3/events/{0}/", model.Field.Value);
                }
                else
                {
                    updater.ModelState.AddModelError("Value", "Error parsing EventId, please check the Id and try again.");
                }
            }

            return string.Empty;
        }

        #endregion Edit

        #endregion Implementation
    }
}