using Etch.OrchardCore.Fields.Query.Fields;
using Etch.OrchardCore.Fields.Query.ViewModels;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Query.Settings
{
    public class QueryFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<QueryField>
    {
        public override IDisplayResult Edit(ContentPartFieldDefinition model)
        {
            return Initialize<EditQueryFieldSettingsViewModel>("QueryFieldSettings_Edit", viewModel =>
            {
                var settings = model.GetSettings<QueryFieldSettings>();

                viewModel.Hint = settings.Hint;
            })
            .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition model, UpdatePartFieldEditorContext context)
        {
            var viewModel = new EditQueryFieldSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                context.Builder.WithSettings(new QueryFieldSettings
                {
                    Hint = viewModel.Hint
                });
            }

            return Edit(model);
        }
    }
}