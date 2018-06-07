using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class StepDTO
    {
        [JsonProperty(PropertyName = "distance")]
        public Distance1DTO Distance { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public Duration1DTO Duration { get; set; }

        [JsonProperty(PropertyName = "end_location")]
        public EndLocation1DTO EndLocation { get; set; }

        [JsonProperty(PropertyName = "html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonProperty(PropertyName = "polyline")]
        public PolylineDTO Polyline { get; set; }

        [JsonProperty(PropertyName = "start_location")]
        public StartLocation1DTO StartLocation { get; set; }

        [JsonProperty(PropertyName = "travel_mode")]
        public string TravelMode { get; set; }

        [JsonProperty(PropertyName = "maneuver")]
        public string Maneuver { get; set; }
    }
}
