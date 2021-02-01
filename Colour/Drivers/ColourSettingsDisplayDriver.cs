using Etch.OrchardCore.Fields.Colour.Settings;
using Etch.OrchardCore.Fields.Colour.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Colour.Drivers
{
    public class ColourSettingsDisplayDriver : SectionDisplayDriver<ISite, ColourSettings>
    {
        #region Dependencies

        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Constructor

        public ColourSettingsDisplayDriver(IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Overrides

        public override async Task<IDisplayResult> EditAsync(ColourSettings section, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageColourSettings))
            {
                return null;
            }

            return Initialize<ColourSettingsViewModel>("ColourSettings_Edit", model =>
            {
                model.Colours = JsonConvert.SerializeObject(section.Colours);
            }).Location("Content:3").OnGroup(Constants.GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(ColourSettings section, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageColourSettings))
            {
                return null;
            }

            if (context.GroupId == Constants.GroupId)
            {
                var model = new ColourSettingsViewModel();

                if (await context.Updater.TryUpdateModelAsync(model, Prefix))
                {
                    section.Colours = JsonConvert.DeserializeObject<ColourItem[]>(model.Colours);
                }
            }

            return await EditAsync(section, context);
        }

        #endregion
    }
}