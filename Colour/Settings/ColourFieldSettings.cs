using System;

namespace Etch.OrchardCore.Fields.Colour.Settings
{
    public class ColourFieldSettings
    {
        public bool AllowCustom { get; set; } = true;
        public bool AllowTransparent { get; set; } = true;
        public string[] Colours { get; set; } = Array.Empty<string>();
        public string Hint { get; set; }
    }
}
