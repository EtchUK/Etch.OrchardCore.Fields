using Newtonsoft.Json;
using System;

namespace Etch.OrchardCore.Fields.Eventbrite.Models.Dto
{
    public class EventbriteEventDto
    {
        [JsonProperty(PropertyName = "name")]
        public Name Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public Description Description { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "vanity_url")]
        public string VanityUrl { get; set; }

        [JsonProperty(PropertyName = "start")]
        public Start Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public End End { get; set; }

        [JsonProperty(PropertyName = "organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "changed")]
        public DateTime Changed { get; set; }

        [JsonProperty(PropertyName = "published")]
        public DateTime Published { get; set; }

        [JsonProperty(PropertyName = "capacity")]
        public int Capacity { get; set; }

        [JsonProperty(PropertyName = "capacity_is_custom")]
        public bool CapacityIsCustom { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "listed")]
        public bool Listed { get; set; }

        [JsonProperty(PropertyName = "shareable")]
        public bool Shareable { get; set; }

        [JsonProperty(PropertyName = "invite_only")]
        public bool InviteOnly { get; set; }

        [JsonProperty(PropertyName = "online_event")]
        public bool OnlineEvent { get; set; }

        [JsonProperty(PropertyName = "show_remaining")]
        public bool ShowRemaining { get; set; }

        [JsonProperty(PropertyName = "tx_time_limit")]
        public int TxTimeLimit { get; set; }

        [JsonProperty(PropertyName = "hide_start_date")]
        public bool HideStartDate { get; set; }

        [JsonProperty(PropertyName = "hide_end_date")]
        public bool HideEndDate { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "is_locked")]
        public bool IsLocked { get; set; }

        [JsonProperty(PropertyName = "privacy_setting")]
        public string PrivacySetting { get; set; }

        [JsonProperty(PropertyName = "is_series")]
        public bool IsSeries { get; set; }

        [JsonProperty(PropertyName = "is_series_parent")]
        public bool IsSeriesParent { get; set; }

        [JsonProperty(PropertyName = "inventory_type")]
        public string InventoryType { get; set; }

        [JsonProperty(PropertyName = "is_reserved_seating")]
        public bool IsReservedSeating { get; set; }

        [JsonProperty(PropertyName = "show_pick_a_seat")]
        public bool ShowPickASeat { get; set; }

        [JsonProperty(PropertyName = "show_seatmap_thumbnail")]
        public bool ShowSeatmapThumbnail { get; set; }

        [JsonProperty(PropertyName = "show_colors_in_seatmap_thumbnail")]
        public bool ShowColorsInSeatmapThumbnail { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "is_free")]
        public bool IsFree { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "logo_id")]
        public string LogoId { get; set; }

        [JsonProperty(PropertyName = "organizer_id")]
        public string OrganizerId { get; set; }

        [JsonProperty(PropertyName = "venue_id")]
        public string VenueId { get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public string CategoryId { get; set; }

        [JsonProperty(PropertyName = "subcategory_id")]
        public object SubcategoryId { get; set; }

        [JsonProperty(PropertyName = "format_id")]
        public string FormatId { get; set; }

        [JsonProperty(PropertyName = "resource_uri")]
        public string ResourceUri { get; set; }

        [JsonProperty(PropertyName = "is_externally_ticketed")]
        public bool IsExternallyTicketed { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public Logo Logo { get; set; }
    }

    public class Name
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }
    }

    public class Description
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }
    }

    public class Start
    {
        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "local")]
        public DateTime Local { get; set; }

        [JsonProperty(PropertyName = "utc")]
        public DateTime Utc { get; set; }
    }

    public class End
    {
        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "local")]
        public DateTime Local { get; set; }

        [JsonProperty(PropertyName = "utc")]
        public DateTime Utc { get; set; }
    }

    public class Logo
    {
        [JsonProperty(PropertyName = "crop_mask")]
        public CropMask CropMask { get; set; }

        [JsonProperty(PropertyName = "original")]
        public Original Original { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "aspect_ratio")]
        public string AspectRatio { get; set; }

        [JsonProperty(PropertyName = "edge_color")]
        public object EdgeColor { get; set; }

        [JsonProperty(PropertyName = "edge_color_set")]
        public bool EdgeColorSet { get; set; }
    }

    public class CropMask
    {
        [JsonProperty(PropertyName = "top_left")]
        public TopLeft TopLeft { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }

    public class TopLeft
    {
        [JsonProperty(PropertyName = "x")]
        public int X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public int Y { get; set; }
    }

    public class Original
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }
}