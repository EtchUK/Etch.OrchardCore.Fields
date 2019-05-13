using Microsoft.Extensions.Localization;
using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Settings
{
    public class ResponsiveMediaFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<ResponsiveMediaField>
    {
        #region Dependencies

        private readonly IStringLocalizer<ResponsiveMediaFieldSettingsDriver> T;

        #endregion

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<ResponsiveMediaFieldSettings>("ResponsiveMediaFieldSettings_Edit", model => partFieldDefinition.Settings.Populate(model))
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var model = new UpdateResponsiveMediaFieldSettingsViewModel();

            await context.Updater.TryUpdateModelAsync(model, Prefix);

            var settings = new ResponsiveMediaFieldSettings
            {
                Hint = model.Hint
            };

            try
            {
                settings.Breakpoints = model.Breakpoints;
                settings.GetBreakpoints();
            } catch
            {
                context.Updater.ModelState.AddModelError(Prefix, T["Failed to parse breakpoints, make sure it only contains numeric values."]);
            }

            context.Builder.MergeSettings(settings);

            return Edit(partFieldDefinition);
        }
    }
}
