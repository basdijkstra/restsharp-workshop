using Newtonsoft.Json;

namespace RestSharpWorkshop.Examples.Models
{
    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string BS { get; set; }
    }
}
