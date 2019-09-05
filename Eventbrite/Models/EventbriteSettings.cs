namespace Etch.OrchardCore.Fields.Eventbrite.Models
{
    public class EventbriteSettings
    {
        public string PrivateToken { get; set; }

        public bool IsConfigured
        {
            get { return !string.IsNullOrWhiteSpace(PrivateToken); }
        }
    }
}