using System;
using System.Linq;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Settings
{
    public class ResponsiveMediaFieldSettings
    {
        public string Breakpoints { get; set; }

        public string Hint { get; set; }

        public bool Required { get; set; }

        public int[] GetBreakpoints()
        {
            if (string.IsNullOrWhiteSpace(Breakpoints))
            {
                return new int[] { };
            }

            return Breakpoints.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
        }
    }
}
