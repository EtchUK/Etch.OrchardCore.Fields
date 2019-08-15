using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.Fields.ResponsiveMedia.Fields
{
    public class ResponsiveMediaField : ContentField
    {
        public string Data { get; set; }

        public bool HasData
        {
            get { return !(string.IsNullOrWhiteSpace(Data) || Data == "[]"); }
        }
    }
}
