using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{
    public class Photo
    {
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "html_attributions")]
        public List<object> HtmlAttributions { get; set; }

        [JsonProperty(PropertyName = "photo_reference")]
        public string PhotoReference { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
    }
}
