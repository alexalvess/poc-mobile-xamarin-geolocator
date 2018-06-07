using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class BoundsDTO
    {
        [JsonProperty(PropertyName = "northeast")]
        public NortheastDTO Northeast { get; set; }

        [JsonProperty(PropertyName = "southwest")]
        public SouthwestDTO Southwest { get; set; }
    }
}
