using System.Threading.Tasks;
using Etch.OrchardCore.Fields.EventBrite.Models;
using Etch.OrchardCore.Fields.EventBrite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.EventBrite.Drivers
{
    public class EventBriteSettingsDisplayDriver : SectionDisplayDriver<ISite, EventBriteSettings>
    {
        #region Constants

        public const string GroupId = "EventBrite";

        #endregion Constants

        #region Dependencies

        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Dependencies

        #region Constructor

        public EventBriteSettingsDisplayDriver(IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructor

        #region Overrides

        public override async Task<IDisplayResult> EditAsync(EventBriteSettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageEventBriteAPI))
            {
                return null;
            }

            return Initialize<EventBriteSettingsViewModel>("ManageEventBriteSettings_Edit", model =>
            {
                model.PrivateToken = settings.PrivateToken;
            }).Location("Content:3").OnGroup(GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(EventBriteSettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageEventBriteAPI))
            {
                return null;
            }

            if (context.GroupId == GroupId)
            {
                var model = new EventBriteSettingsViewModel();

                await context.Updater.TryUpdateModelAsync(model, Prefix);

                settings.PrivateToken = model.PrivateToken;
            }

            return await EditAsync(settings, context);
        }

        #endregion Overrides
    }
}