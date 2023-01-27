using Newtonsoft.Json;

namespace RestSharpWorkshop.Answers.Models
{
    public class Account
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("balance")]
        public int Balance { get; set; } = 0;
    }
}
