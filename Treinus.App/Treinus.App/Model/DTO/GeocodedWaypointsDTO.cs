using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class GeocodedWaypointsDTO
    {
        [JsonProperty(PropertyName = "geocoder_status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "place_id")]
        public string PlaceId { get; set; }

        [JsonProperty(PropertyName = "types")]
        public List<string> Types { get; set; }
    }
}
