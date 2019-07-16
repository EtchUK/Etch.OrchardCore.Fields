using System;
using System.Threading.Tasks;
using Etch.OrchardCore.Fields.MultiSelect.Fields;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;

namespace Etch.OrchardCore.Fields.MultiSelect.Settings
{
    public class MultiSelectFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<MultiSelectField>
    {
        #region Driver Methods

        #region Edit

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<MultiSelectFieldSettings>("MultiSelectFieldSettings_Edit", model =>
            {
                var settings = partFieldDefinition.GetSettings<MultiSelectFieldSettings>();

                model.OptionsJson = JsonConvert.SerializeObject(settings.Options ?? Array.Empty<string>(), Formatting.Indented);
            })
            .Location("Content");

        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var settings = new MultiSelectFieldSettings();

            if (await context.Updater.TryUpdateModelAsync(settings, Prefix)) {
                settings.Options = string.IsNullOrWhiteSpace(settings.OptionsJson) ? Array.Empty<string>() : JsonConvert.DeserializeObject<string[]>(settings.OptionsJson);
                settings.OptionsJson = string.Empty;
                context.Builder.WithSettings(settings);
            }

            return Edit(partFieldDefinition);
        }

        #endregion

        #endregion
    }
}

