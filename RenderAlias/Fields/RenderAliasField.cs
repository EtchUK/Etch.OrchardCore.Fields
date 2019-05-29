using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.Fields.RenderAlias.Fields
{
    public class RenderAliasField : ContentField
    {
        public string Alias { get; set; }
        public string DisplayType { get; set; } = "Detail";
    }
}
