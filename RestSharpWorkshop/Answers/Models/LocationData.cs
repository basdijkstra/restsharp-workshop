using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSharpWorkshop.Answers.Models
{
    public class LocationData
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
}
