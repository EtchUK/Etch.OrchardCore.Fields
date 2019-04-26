using Moov2.OrchardCore.Fields.ResponsiveMedia.Fields;
using Moov2.OrchardCore.Fields.ResponsiveMedia.Models;
using Moov2.OrchardCore.Fields.ResponsiveMedia.ViewModels;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Fields.ResponsiveMedia.Drivers
{
    public class ResponsiveMediaFieldDisplayDriver : ContentFieldDisplayDriver<ResponsiveMediaField>
    {
        public override IDisplayResult Display(ResponsiveMediaField field, BuildFieldDisplayContext context)
        {
            return Initialize<DisplayResponsiveMediaFieldViewModel>(GetDisplayShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Media = string.IsNullOrEmpty(field.Data) ? null : JsonConvert.DeserializeObject<IList<ResponsiveMediaItem>>(field.Data);
            })
            .Location("Content")
            .Location("SummaryAdmin", "");
        }

        public override IDisplayResult Edit(ResponsiveMediaField field, BuildFieldEditorContext context)
        {
            return Initialize<EditResponsiveMediaFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Data = field.Data;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(ResponsiveMediaField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            await updater.TryUpdateModelAsync(field, Prefix, f => f.Data);

            return Edit(field, context);
        }
    }
}
