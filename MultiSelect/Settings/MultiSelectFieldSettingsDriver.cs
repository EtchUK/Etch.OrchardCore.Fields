using Etch.OrchardCore.Fields.MultiSelect.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                partFieldDefinition.Settings.Populate(model);
            })
            .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var settings = new MultiSelectFieldSettings();

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

