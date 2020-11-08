using Etch.OrchardCore.Fields.ResponsiveMedia.Models;
using Newtonsoft.Json;
using OrchardCore.Media;
using System.Collections.Generic;
using System.IO;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Utils
{
    public static class ResponsiveMediaUtils
    {
        public static IList<ResponsiveMediaItem> ParseMedia(IMediaFileStore mediaFileStore, string data)
        {
            var media = new List<ResponsiveMediaItem>();

            if (!string.IsNullOrWhiteSpace(data))
            {
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
                    source.Url = mediaFileStore.MapPathToPublicUrl(source.Path);
                }
            }

            return media;
        }
    }
}
