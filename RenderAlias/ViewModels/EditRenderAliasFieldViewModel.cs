using Etch.OrchardCore.Fields.RenderAlias.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Fields.RenderAlias.ViewModels
{
    public class EditRenderAliasFieldViewModel
    {
        public RenderAliasField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Alias { get; set; }
        public string DisplayType { get; set; }
    }
}
