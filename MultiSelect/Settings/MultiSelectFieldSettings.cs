using System.ComponentModel.DataAnnotations.Schema;

namespace Etch.OrchardCore.Fields.MultiSelect.Settings
{
    public class MultiSelectFieldSettings
    {
        public string Hint { get; set; }
        public string[] Options { get; set; }
        public string OptionsJson { get; set; }
    }
}
