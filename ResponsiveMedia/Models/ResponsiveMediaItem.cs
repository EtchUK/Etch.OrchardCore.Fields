using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Models
{
    public class ResponsiveMediaItem
    {
        [JsonProperty("sources")]
        public IList<ResponsiveMediaSource> Sources { get; set; }

        /// <summary>
        /// Returns image for smallest breakpoint. If an image hasn't been specified
        /// for the breakpoint, a path for a resized version of the largest image is 
        /// returned.
        /// </summary>
        public string SmallestImageUrl
        {
            get {
                return Sources.OrderBy(x => x.Breakpoint).First().Url;
            }
        }

        /// <summary>
        /// Returns a collection of source sets that can be used to construct
        /// a `picture` element.
        /// </summary>
        public IList<ResponsiveMediaSource> GetSourceSets(int[] breakpoints)
        {
            var sourceSets = new List<ResponsiveMediaSource>();
            var orderedBreakpoints = breakpoints.OrderByDescending(x => x).ToList();

            for (var i = 0; i < orderedBreakpoints.Count - 1; i++)
            {
                var media = Sources.Where(x => x.Breakpoint == orderedBreakpoints[i]).FirstOrDefault();

                if (media != null)
                {
                    sourceSets.Add(new ResponsiveMediaSource { Breakpoint = orderedBreakpoints[i + 1] + 1, Url = media.Url });
                    continue;
                }

                if (!sourceSets.Any())
                {
                    continue;
                }

                var sourceSetToResize = sourceSets.Last();
                sourceSets.Add(new ResponsiveMediaSource { Breakpoint = orderedBreakpoints[i + 1] + 1, Url = $"{sourceSetToResize.Url}?width={orderedBreakpoints[i]}" });
                continue;
            }

            return sourceSets;
        }
    }
}
