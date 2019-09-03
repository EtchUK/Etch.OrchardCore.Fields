using Etch.OrchardCore.Fields.EventBrite.Fields;
using Etch.OrchardCore.Fields.EventBrite.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.EventBrite.ViewModels
{
    public class DisplayEventBriteFieldViewModel
    {
        public EventBriteField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public bool HasData
        {
            get
            {
                return Field.EventBriteData != null;
            }
        }

        public EventBriteItem Data
        {
            get
            {
                return Field.EventBriteData;
            }
        }
    }
}