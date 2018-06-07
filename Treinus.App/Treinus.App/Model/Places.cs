using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{

    public class Places
    {
        [JsonProperty(PropertyName = "html_attributions")]
        public List<object> HtmlAttributions { get; set; }

        [JsonProperty(PropertyName = "next_page_token")]
        public string NextPageToken { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Result> Results { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
