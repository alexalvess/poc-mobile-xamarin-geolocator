using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{
    public class Location
    {
        [JsonProperty(PropertyName = "lat")]
        public float Lat { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public float Lng { get; set; }
    }
}
