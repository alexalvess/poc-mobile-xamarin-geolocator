using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{
    public class OpeningHours
    {
        [JsonProperty(PropertyName = "open_now")]
        public bool OpenNow { get; set; }
    }
}
