using Moov2.OrchardCore.Fields.Dictionary.Fields;
using Moov2.OrchardCore.Fields.Dictionary.Models;
using Moov2.OrchardCore.Fields.Dictionary.Settings;
using Moov2.OrchardCore.Fields.Dictionary.ViewModels;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Fields.Dictionary.Drivers
{
    public class DictionaryFieldDisplayDriver : ContentFieldDisplayDriver<DictionaryField>
    {
        #region ContentFieldDisplayDriver<DictionaryField>

        #region Display

        public override IDisplayResult Display(DictionaryField field, BuildFieldDisplayContext context)
        {
            return Initialize<DisplayDictionaryFieldViewModel>(GetDisplayShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Data = field.Data;
            })
            .Location("Content")
            .Location("SummaryAdmin", "");
        }

        #endregion Display

        #region Edit

        public override IDisplayResult Edit(DictionaryField field, BuildFieldEditorContext context)
        {
            var isNew = field.ContentItem.Id == 0;
            return Initialize<EditDictionaryFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;

                model.Data = JsonConvert.SerializeObject(isNew ? GetDefaults(context.PartFieldDefinition) : field.Data);
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(DictionaryField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            var model = new EditDictionaryFieldViewModel();

            if (await updater.TryUpdateModelAsync(model, Prefix, m => m.Data))
            {
                field.Data = JsonConvert.DeserializeObject<List<DictionaryItem>>(model.Data);
            }

            return Edit(field, context);
        }

        #endregion Edit

        #endregion ContentFieldDisplayDriver<DictionaryField>

        #region Helpers

        private IList<DictionaryItem> GetDefaults(ContentPartFieldDefinition partFieldDefinition)
        {
            var settingsValue = partFieldDefinition?.Settings?.ToObject<DictionaryFieldSettings>()?.DefaultData;
            if (settingsValue != null)
            {
                return JsonConvert.DeserializeObject<IList<DictionaryItem>>(settingsValue);
            }
            return null;
        }

        #endregion Helpers
    }
}
