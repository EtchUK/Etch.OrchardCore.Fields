using Moov2.OrchardCore.Fields.Dictionary.Fields;
using Moov2.OrchardCore.Fields.Dictionary.Models;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Fields.Dictionary.Settings
{
    public class DictionaryFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<DictionaryField>
    {
        #region ContentPartFieldDefinitionDisplayDriver<DictionaryField>

        #region Edit

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<DictionaryFieldSettings>("DictionaryFieldSettings_Edit", model =>
                {
                    partFieldDefinition.Settings.Populate(model);
                })
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var settings = new DictionaryFieldSettings();

            if (await context.Updater.TryUpdateModelAsync(settings, Prefix))
            {
                // This makes sure the JSON is correctly formatted as it comes from the front end
                // with incorrect casing
                settings.DefaultData = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<IList<DictionaryItem>>(settings.DefaultData));
                context.Builder.MergeSettings(settings);
            }

            return Edit(partFieldDefinition);
        }

        #endregion Edit

        #endregion ContentPartFieldDefinitionDisplayDriver<DictionaryField>
    }
}
