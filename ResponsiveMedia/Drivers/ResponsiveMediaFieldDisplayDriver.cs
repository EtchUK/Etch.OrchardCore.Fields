using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using Etch.OrchardCore.Fields.ResponsiveMedia.Models;
using Etch.OrchardCore.Fields.ResponsiveMedia.Settings;
using Etch.OrchardCore.Fields.ResponsiveMedia.ViewModels;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Media;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Drivers
{
    public class ResponsiveMediaFieldDisplayDriver : ContentFieldDisplayDriver<ResponsiveMediaField>
    {
        #region Dependencies

        private readonly IMediaFileStore _mediaFileStore;

        #endregion

        #region Constructor

        public ResponsiveMediaFieldDisplayDriver(IMediaFileStore mediaFileStore)
        {
            _mediaFileStore = mediaFileStore;
        }

        #endregion

        public override IDisplayResult Display(ResponsiveMediaField field, BuildFieldDisplayContext context)
        {
            return Initialize<DisplayResponsiveMediaFieldViewModel>(GetDisplayShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Media = ParseMedia(field.Data, context.PartFieldDefinition.Settings.ToObject<ResponsiveMediaFieldSettings>().GetBreakpoints());
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
                model.Data = JsonConvert.SerializeObject(ParseMedia(field.Data));
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(ResponsiveMediaField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            await updater.TryUpdateModelAsync(field, Prefix, f => f.Data);

            return Edit(field, context);
        }

        public IList<ResponsiveMediaItem> ParseMedia(string data)
        {
            var media = string.IsNullOrWhiteSpace(data) ? new List<ResponsiveMediaItem>() : JsonConvert.DeserializeObject<IList<ResponsiveMediaItem>>(data);
            
            foreach (var mediaItem in media)
            {
                if (mediaItem.Sources == null)
                {
                    continue;
                }

                foreach (var source in mediaItem.Sources)
                {
                    source.Name = Path.GetFileName(source.Path);
                    source.Url = _mediaFileStore.MapPathToPublicUrl(source.Path);
                }
            }

            return media;
        }

        public IList<ResponsiveMediaItem> ParseMedia(string data, int[] breakpoints)
        {
            var media = ParseMedia(data);

            foreach (var mediaItem in media)
            {
                mediaItem.Sources = mediaItem.GetSourceSets(breakpoints);
            }

            return media;
        }
    }
}
