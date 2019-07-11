using Newtonsoft.Json;

namespace Etch.OrchardCore.Fields.MultiSelect.Settings
{
    public class MultiSelectFieldSettings
    {
        public string Hint { get; set; }

        public string Options { get; set; } = "[]";

        public string[] GetOptions()
        {
            if (string.IsNullOrWhiteSpace(Options))
            {
                return new string[0];
            }
            
            return JsonConvert.DeserializeObject<string[]>(Options);
        }
    }
}
