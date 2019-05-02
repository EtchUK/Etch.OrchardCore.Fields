using Moov2.OrchardCore.Fields.Dictionary.Fields;
using Moov2.OrchardCore.Fields.Dictionary.Models;
using Moov2.OrchardCore.Fields.Dictionary.ViewModels;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Fields.Dictionary.Drivers
{
    public class DictionaryFieldDisplayDriver : ContentFieldDisplayDriver<DictionaryField>
    {
        #region ContentFieldDisplayDriver<DictionaryField>

        #region Edit

        public override IDisplayResult Edit(DictionaryField field, BuildFieldEditorContext context)
        {
            return Initialize<EditDictionaryFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;

                model.Data = JsonConvert.SerializeObject(field.Data);
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
    }
}
