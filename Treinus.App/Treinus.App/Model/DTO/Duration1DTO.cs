using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model.DTO
{
    public class Duration1DTO
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
    }
}
