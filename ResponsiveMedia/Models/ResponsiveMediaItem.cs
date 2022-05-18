using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Models
{
    public class ResponsiveMediaItem
    {
        [JsonProperty("mediaText")]
        public string MediaText { get; set; }

        [JsonProperty("sources")]
        public IList<ResponsiveMediaSource> Sources { get; set; }

        /// <summary>
        /// Returns image for smallest breakpoint. If an image hasn't been specified
        /// for the breakpoint, a path for a resized version of the largest image is 
        /// returned.
        /// </summary>
        public string SmallestImageUrl { get; set; }

        /// <summary>
        /// Returns a collection of source sets that can be used to construct
        /// a `picture` element.
        /// </summary>
        public IList<ResponsiveMediaSource> GetSourceSets(int[] breakpoints)
        {
            var sourceSets = new List<ResponsiveMediaSource>();
            var orderedBreakpoints = breakpoints.OrderByDescending(x => x).ToList();
            ResponsiveMediaSource lastMedia = null;
            for (var i = 0; i < orderedBreakpoints.Count; i++)
            {
                var media = Sources.FirstOrDefault(x => x.Breakpoint == orderedBreakpoints[i]);
                var isLastBreakpoint = i + 1 == orderedBreakpoints.Count;
                var nextBreakpoint = isLastBreakpoint ? 0 : orderedBreakpoints[i + 1];

                if (media != null)
                {
                    lastMedia = new ResponsiveMediaSource { Breakpoint = nextBreakpoint + 1, Url = Uri.EscapeUriString(media.Url) };
                    sourceSets.Add(lastMedia);
                    continue;
                }

                if (!sourceSets.Any() || lastMedia == null)
                {
                    continue;
                }

                sourceSets.Add(new ResponsiveMediaSource { Breakpoint = nextBreakpoint + 1, Url = $"{lastMedia.Url}?width={orderedBreakpoints[i]}" });
            }

            if (!sourceSets.Any())
            {
                return sourceSets;
            }

            SmallestImageUrl = sourceSets.Last().Url;
            sourceSets.Remove(sourceSets.Last());

            return sourceSets;
        }
    }
}
