using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Practice.ClassModels
{
    public partial class LocationResponse
    {
        [JsonProperty("post code")]
        public string PostCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonProperty("places")]
        public List<Place> Places { get; set; }
    }
    public partial class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }
}
