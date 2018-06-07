using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class RoutesDTO
    {
        [JsonProperty(PropertyName = "geocoded_waypoints")]
        public List<GeocodedWaypointsDTO> GeocodedWaypoints { get; set; }

        [JsonProperty(PropertyName = "routes")]
        public List<RouteDTO> Routes { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
