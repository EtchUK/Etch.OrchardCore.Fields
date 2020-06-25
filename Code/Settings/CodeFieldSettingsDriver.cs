using Etch.OrchardCore.Fields.Code.Fields;
using Etch.OrchardCore.Fields.Code.ViewModels;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Code.Settings
{
    public class CodeFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<CodeField>
    {
        #region Driver Methods

        #region Edit

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<EditCodeFieldSettingsViewModel>("CodeFieldSettings_Edit", model =>
            {
                model.Language = partFieldDefinition.GetSettings<CodeFieldSettings>().Language;

                if (string.IsNullOrWhiteSpace(model.Language))
                {
                    model.Language = Constants.DefaultLanguage;
                }
            })
            .Location("Content");

        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var model = new EditCodeFieldSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix))
            {
                context.Builder.WithSettings(new CodeFieldSettings
                {
                    Language = model.Language
                });
            }

            return Edit(partFieldDefinition);
        }

        #endregion

        #endregion
    }
}
