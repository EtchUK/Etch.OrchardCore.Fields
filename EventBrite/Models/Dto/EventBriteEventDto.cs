using System;
using System.Collections.Generic;
using System.Text;

namespace Etch.OrchardCore.Fields.EventBrite.Models.Dto
{
    public class EventBriteEventDto
    {
        public Name name { get; set; }
        public Description description { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string vanity_url { get; set; }
        public Start start { get; set; }
        public End end { get; set; }
        public string organization_id { get; set; }
        public DateTime created { get; set; }
        public DateTime changed { get; set; }
        public DateTime published { get; set; }
        public int capacity { get; set; }
        public bool capacity_is_custom { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public bool listed { get; set; }
        public bool shareable { get; set; }
        public bool invite_only { get; set; }
        public bool online_event { get; set; }
        public bool show_remaining { get; set; }
        public int tx_time_limit { get; set; }
        public bool hide_start_date { get; set; }
        public bool hide_end_date { get; set; }
        public string locale { get; set; }
        public bool is_locked { get; set; }
        public string privacy_setting { get; set; }
        public bool is_series { get; set; }
        public bool is_series_parent { get; set; }
        public string inventory_type { get; set; }
        public bool is_reserved_seating { get; set; }
        public bool show_pick_a_seat { get; set; }
        public bool show_seatmap_thumbnail { get; set; }
        public bool show_colors_in_seatmap_thumbnail { get; set; }
        public string source { get; set; }
        public bool is_free { get; set; }
        public string version { get; set; }
        public string summary { get; set; }
        public string logo_id { get; set; }
        public string organizer_id { get; set; }
        public string venue_id { get; set; }
        public string category_id { get; set; }
        public object subcategory_id { get; set; }
        public string format_id { get; set; }
        public string resource_uri { get; set; }
        public bool is_externally_ticketed { get; set; }
        public Logo logo { get; set; }
    }

    public class Name
    {
        public string text { get; set; }
        public string html { get; set; }
    }

    public class Description
    {
        public string text { get; set; }
        public string html { get; set; }
    }

    public class Start
    {
        public string timezone { get; set; }
        public DateTime local { get; set; }
        public DateTime utc { get; set; }
    }

    public class End
    {
        public string timezone { get; set; }
        public DateTime local { get; set; }
        public DateTime utc { get; set; }
    }

    public class Logo
    {
        public Crop_Mask crop_mask { get; set; }
        public Original original { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string aspect_ratio { get; set; }
        public object edge_color { get; set; }
        public bool edge_color_set { get; set; }
    }

    public class Crop_Mask
    {
        public Top_Left top_left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Top_Left
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Original
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}