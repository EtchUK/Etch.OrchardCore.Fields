﻿using Etch.OrchardCore.Fields.Eventbrite.Fields;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using Etch.OrchardCore.Fields.Eventbrite.Services;
using Etch.OrchardCore.Fields.Eventbrite.ViewModels;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Etch.OrchardCore.Fields.Eventbrite.Drivers
{
    public class EventbriteFieldDisplayDriver : ContentFieldDisplayDriver<EventbriteField>
    {
        #region Constants

        private const string FailedToRetrieveErrorMessage = "Unable to retrieve event from Eventbrite.";
        private const string UnconfiguredErrorMessage = "Unable to retrieve event from Eventbrite because API key hasn't been configured.";

        #endregion

        #region Dependencies

        private readonly IEventbriteService _eventbriteService;
        private readonly IEventbriteSettingsService _eventbriteSettingsService;

        private IStringLocalizer T { get; set; }

        #endregion Dependencies

        #region Constructor

        public EventbriteFieldDisplayDriver(IStringLocalizer<EventbriteFieldDisplayDriver> localizer, IEventbriteService eventbriteService, IEventbriteSettingsService eventbriteSettingsService)
        {
            _eventbriteService = eventbriteService;
            _eventbriteSettingsService = eventbriteSettingsService;

            T = localizer;
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
            var settings = await _eventbriteSettingsService.GetSettingsAsync();

            if (string.IsNullOrWhiteSpace(settings.PrivateToken))
            {
                updater.ModelState.AddModelError(Prefix, nameof(field.Value), T[UnconfiguredErrorMessage]);
                return await EditAsync(field, context);
            }

            await updater.TryUpdateModelAsync(model, Prefix, m => m.Value);

            if (string.IsNullOrWhiteSpace(model.Value))
            {
                return await EditAsync(field, context);
            }

            try
            {
                var eventbriteEvent = await _eventbriteService.GetEventAsync(GetEventbriteId(model.Value));

                if (eventbriteEvent == null)
                {
                    throw new Exception();
                }

                var venue = await _eventbriteService.GetVenueAsync(eventbriteEvent.Id);
                
                field.Value = model.Value;
                field.Data = new EventbriteEvent(eventbriteEvent, venue);
            }
            catch
            {
                updater.ModelState.AddModelError(Prefix, nameof(field.Value), T[FailedToRetrieveErrorMessage]);
            }

            return await EditAsync(field, context);
        }
       
        private string GetEventbriteId(string value)
        {
            try
            {
                return HttpUtility.ParseQueryString(new Uri(value).Query)["eid"];
            }
            catch
            {
                return value;
            }
        }

        #endregion Edit

        #endregion Implementation
    }
}