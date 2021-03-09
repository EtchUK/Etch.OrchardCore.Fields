using System;

namespace Etch.OrchardCore.Fields.Colour.Settings
{
    public class ColourFieldSettings
    {
        public bool AllowCustom { get; set; }
        public bool AllowTransparent { get; set; }
        public ColourItem[] Colours { get; set; } = Array.Empty<ColourItem>();
        public string DefaultValue { get; set; }
        public string Hint { get; set; }
        public bool UseGlobalColours { get; set; }
    }
}
