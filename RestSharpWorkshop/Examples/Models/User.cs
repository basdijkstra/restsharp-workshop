using Newtonsoft.Json;

namespace RestSharpWorkshop.Examples.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("company")]
        public Company Company { get; set; }
    }
}
