using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{
    public class Result
    {
        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; } = new Geometry();

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "opening_hours")]
        public OpeningHours OpeningHours { get; set; } = new OpeningHours();

        [JsonProperty(PropertyName = "photos")]
        public List<Photo> Photos { get; set; } = new List<Photo>();

        [JsonProperty(PropertyName = "place_id")]
        public string PlaceId { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        [JsonProperty(PropertyName = "price_level")]
        public int PriceLevel { get; set; } = 0;

        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; } = 0;

        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }

        [JsonProperty(PropertyName = "types")]
        public List<string> Types { get; set; } = new List<string>();

        [JsonProperty(PropertyName = "vicinity")]
        public string Vicinity { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double DistanceCalculate()
        {
            double d2r = 0.017453292519943295769236;

            double dlong = (Geometry.Location.Lng - Longitude) * d2r;
            double dlat = (Geometry.Location.Lat - Latitude) * d2r;

            double temp_sin = Math.Sin(dlat / 2.0);
            double temp_cos = Math.Cos(Latitude * d2r);
            double temp_sin2 = Math.Sin(dlong / 2.0);

            double a = (temp_sin * temp_sin) + (temp_cos * temp_cos) * (temp_sin2 * temp_sin2);
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            return 6368.1 * c;
        }

        public string FormatDisntace
        {
            get => $"a {(DistanceCalculate()/1000).ToString("N2")} km de distância";
        }

        public string FormatName
        {
            get
            {
                if (Name.Length > 18)
                    return Name.Substring(0, 18) + " ...";

                return Name;
            }
        }

        public string FormatRating
        {
            get => Rating.ToString("N1");
        }

        public string FormatOpen
        {
            get
            {
                if (OpeningHours.OpenNow)
                    return "Aberto";
                else
                    return "Fechado";
            }
        }

        public string FormatOpenColor
        {
            get
            {
                if (OpeningHours.OpenNow)
                    return "#04B404";
                else
                    return "#FF0000";
            }
        }
    }
}
