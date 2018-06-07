using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class PolylineDTO
    {
        [JsonProperty(PropertyName = "points")]
        public string Points { get; set; }
    }
}
