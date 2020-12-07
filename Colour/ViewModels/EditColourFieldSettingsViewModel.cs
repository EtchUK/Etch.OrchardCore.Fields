namespace Etch.OrchardCore.Fields.Colour.ViewModels
{
    public class EditColourFieldSettingsViewModel
    {
        public bool AllowCustom { get; set; }
        public bool AllowTransparent { get; set; }
        public string Colours { get; set; }
        public string DefaultValue { get; set; }
        public string Hint { get; set; }
    }
}
