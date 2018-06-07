using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class RouteDTO
    {
        [JsonProperty(PropertyName = "bounds")]
        public BoundsDTO Bounds { get; set; }

        [JsonProperty(PropertyName = "copyrights")]
        public string Copyrights { get; set; }

        [JsonProperty(PropertyName = "legs")]
        public List<LegDTO> Legs { get; set; }

        [JsonProperty(PropertyName = "overview_polyline")]
        public OverviewPolylineDTO OverviewPolyline { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public List<object> Warnings { get; set; }

        [JsonProperty(PropertyName = "waypoint_order")]
        public List<object> WaypointOrder { get; set; }
    }
}
