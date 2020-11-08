using System.Threading.Tasks;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using Etch.OrchardCore.Fields.Eventbrite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.Eventbrite.Drivers
{
    public class EventbriteSettingsDisplayDriver : SectionDisplayDriver<ISite, EventbriteSettings>
    {
        #region Dependencies

        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Dependencies

        #region Constructor

        public EventbriteSettingsDisplayDriver(IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructor

        #region Overrides

        public override async Task<IDisplayResult> EditAsync(EventbriteSettings section, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageEventbriteAPI))
            {
                return null;
            }

            return Initialize<EventbriteSettingsViewModel>("ManageEventBriteSettings_Edit", model =>
            {
                model.PrivateToken = section.PrivateToken;
            }).Location("Content:3").OnGroup(Constants.SettingsGroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(EventbriteSettings section, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageEventbriteAPI))
            {
                return null;
            }

            if (context.GroupId == Constants.SettingsGroupId)
            {
                var model = new EventbriteSettingsViewModel();

                await context.Updater.TryUpdateModelAsync(model, Prefix);

                section.PrivateToken = model.PrivateToken;
            }

            return await EditAsync(section, context);
        }

        #endregion Overrides
    }
}