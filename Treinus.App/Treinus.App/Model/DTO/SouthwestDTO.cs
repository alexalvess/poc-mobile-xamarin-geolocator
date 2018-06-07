using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class SouthwestDTO
    {
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public float Longitude { get; set; }
    }
}
