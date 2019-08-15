using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using Etch.OrchardCore.Fields.ResponsiveMedia.Models;
using Etch.OrchardCore.Fields.ResponsiveMedia.Settings;
using Etch.OrchardCore.Fields.ResponsiveMedia.ViewModels;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Media;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Drivers
{
    public class ResponsiveMediaFieldDisplayDriver : ContentFieldDisplayDriver<ResponsiveMediaField>
    {
        #region Dependencies

        private readonly IMediaFileStore _mediaFileStore;

        public IStringLocalizer S { get; set; }

        #endregion

        #region Constructor

        public ResponsiveMediaFieldDisplayDriver(IMediaFileStore mediaFileStore, IStringLocalizer<ResponsiveMediaFieldDisplayDriver> localizer)
        {
            _mediaFileStore = mediaFileStore;
            S = localizer;
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
            .Location("SummaryAdmin", "")
            .Location("DetailAdmin", ""); 
        }

        public override IDisplayResult Edit(ResponsiveMediaField field, BuildFieldEditorContext context)
        {
            var settings = context.PartFieldDefinition.Settings.ToObject<ResponsiveMediaFieldSettings>();

            if (!settings.IsConfigured)
            {
                return Initialize<EditResponsiveMediaFieldViewModel>("ResponsiveMediaField_Unconfigured", model =>
                {
                    model.Field = field;
                    model.Part = context.ContentPart;
                    model.PartFieldDefinition = context.PartFieldDefinition;
                });
            }

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
            if (await updater.TryUpdateModelAsync(field, Prefix, f => f.Data))
            {
                var settings = context.PartFieldDefinition.Settings.ToObject<ResponsiveMediaFieldSettings>();

                if (settings.Required && !JsonConvert.DeserializeObject<IList<ResponsiveMediaItem>>(field.Data).Any())
                {
                    updater.ModelState.AddModelError(Prefix, S["{0}: Media is required.", context.PartFieldDefinition.DisplayName()]);
                }

            }

            return Edit(field, context);
        }

        public IList<ResponsiveMediaItem> ParseMedia(string data)
        {
            var media = new List<ResponsiveMediaItem>();

            if (!string.IsNullOrWhiteSpace(data)) {
                media = data.StartsWith("[") ? JsonConvert.DeserializeObject<List<ResponsiveMediaItem>>(data) : new List<ResponsiveMediaItem> { JsonConvert.DeserializeObject<ResponsiveMediaItem>(data) };
            }
            
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
