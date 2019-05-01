using Moov2.OrchardCore.Fields.Dictionary.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
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
                partFieldDefinition.Settings.Populate(model))
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var model = new UpdateDictionaryFieldSettingsViewModel();

            await context.Updater.TryUpdateModelAsync(model, Prefix);

            var settings = new DictionaryFieldSettings
            {
                Hint = model.Hint
            };

            context.Builder.MergeSettings(settings);

            return Edit(partFieldDefinition);
        }

        #endregion Edit

        #endregion ContentPartFieldDefinitionDisplayDriver<DictionaryField>
    }
}
