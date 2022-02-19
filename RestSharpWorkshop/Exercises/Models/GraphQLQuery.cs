using Newtonsoft.Json;

namespace RestSharpWorkshop.Exercises.Models
{
    public class GraphQLQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("variables")]
        public string Variables { get; set; }
    }
}
