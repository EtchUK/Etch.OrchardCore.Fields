using Etch.OrchardCore.Fields.Values.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Values.Settings
{
    public class ValuesFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<ValuesField>
    {
        #region Driver Methods

        #region Edit

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<ValuesFieldSettings>("ValuesFieldSettings_Edit", model =>
            {
                partFieldDefinition.Settings.Populate(model);
            })
            .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var settings = new ValuesFieldSettings();

            if (await context.Updater.TryUpdateModelAsync(settings, Prefix))
            {
                context.Builder.MergeSettings(settings);
            }

            return Edit(partFieldDefinition);
        }

        #endregion

        #endregion
    }
}

