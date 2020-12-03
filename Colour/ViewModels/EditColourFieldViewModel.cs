using Etch.OrchardCore.Fields.Colour.Fields;
using Etch.OrchardCore.Fields.Colour.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Linq;

namespace Etch.OrchardCore.Fields.Colour.ViewModels
{
    public class EditColourFieldViewModel
    {
        public ColourField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Value { get; set; }

        public bool IsCustomColour
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Value) && Value != "transparent" && !PartFieldDefinition.GetSettings<ColourFieldSettings>().Colours.Any(x => x == Value);
            }
        }

        public bool IsTransparent
        {
            get { return Value == "transparent"; }
        }
    }
}
