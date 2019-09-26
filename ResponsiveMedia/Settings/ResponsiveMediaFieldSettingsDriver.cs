using Microsoft.Extensions.Localization;
using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Etch.OrchardCore.Fields.ResponsiveMedia.Utils;
using OrchardCore.Media;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Settings
{
    public class ResponsiveMediaFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<ResponsiveMediaField>
    {
        #region Dependencies

        private readonly IMediaFileStore _mediaFileStore;
        private readonly IStringLocalizer<ResponsiveMediaFieldSettingsDriver> T;

        #endregion

        #region Constructor

        public ResponsiveMediaFieldSettingsDriver(IStringLocalizer<ResponsiveMediaFieldSettingsDriver> localizer, IMediaFileStore mediaFileStore)
        {
            T = localizer;
            _mediaFileStore = mediaFileStore;
        }

        #endregion

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<ResponsiveMediaFieldSettings>("ResponsiveMediaFieldSettings_Edit", model => partFieldDefinition.PopulateSettings(model))
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var model = new UpdateResponsiveMediaFieldSettingsViewModel();

            await context.Updater.TryUpdateModelAsync(model, Prefix);

            var settings = new ResponsiveMediaFieldSettings
            {
                Hint = model.Hint,
                Multiple = model.Multiple,
                Required = model.Required,
                FallbackData = JsonConvert.SerializeObject(ResponsiveMediaUtils.ParseMedia(_mediaFileStore, model.FallbackData))
            };

            try
            {
                settings.Breakpoints = model.Breakpoints;
                settings.GetBreakpoints();
            } catch
            {
                context.Updater.ModelState.AddModelError(Prefix, T["Failed to parse breakpoints, make sure it only contains numeric values."]);
            }

            context.Builder.WithSettings(settings);

            return Edit(partFieldDefinition);
        }
    }
}
