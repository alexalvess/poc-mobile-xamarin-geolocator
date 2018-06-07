using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class LegDTO
    {
        [JsonProperty(PropertyName = "distance")]
        public DistanceDTO Distance { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public DurationDTO Duration { get; set; }

        [JsonProperty(PropertyName = "end_address")]
        public string EndAddress { get; set; }

        [JsonProperty(PropertyName = "end_location")]
        public EndLocationDTO EndLocation { get; set; }

        [JsonProperty(PropertyName = "start_address")]
        public string StartAddress { get; set; }

        [JsonProperty(PropertyName = "start_location")]
        public StartLocationDTO StartLocation { get; set; }

        [JsonProperty(PropertyName = "steps")]
        public List<StepDTO> Steps { get; set; }

        [JsonProperty(PropertyName = "traffic_speed_entry")]
        public List<object> TrafficSpeedEntry { get; set; }

        [JsonProperty(PropertyName = "via_waypoint")]
        public List<object> ViaWaypoint { get; set; }
    }
}
