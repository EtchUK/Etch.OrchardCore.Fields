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

        public override IDisplayResult Edit(ContentPartFieldDefinition model)
        {
            return Initialize<ResponsiveMediaFieldSettings>("ResponsiveMediaFieldSettings_Edit", viewModel => model.PopulateSettings(viewModel))
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition model, UpdatePartFieldEditorContext context)
        {
            var viewModel = new UpdateResponsiveMediaFieldSettingsViewModel();

            await context.Updater.TryUpdateModelAsync(viewModel, Prefix);

            var settings = new ResponsiveMediaFieldSettings
            {
                AllowMediaText = viewModel.AllowMediaText,
                Hint = viewModel.Hint,
                Multiple = viewModel.Multiple,
                Required = viewModel.Required,
                FallbackData = JsonConvert.SerializeObject(ResponsiveMediaUtils.ParseMedia(_mediaFileStore, viewModel.FallbackData))
            };

            try
            {
                settings.Breakpoints = viewModel.Breakpoints;
                settings.GetBreakpoints();
            } catch
            {
                context.Updater.ModelState.AddModelError(Prefix, T["Failed to parse breakpoints, make sure it only contains numeric values."]);
            }

            context.Builder.WithSettings(settings);

            return Edit(model);
        }
    }
}
