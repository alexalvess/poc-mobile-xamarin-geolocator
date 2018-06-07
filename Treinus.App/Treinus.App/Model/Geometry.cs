using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{
    public class Geometry
    {
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
    }
}
