using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Examples.Models;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Examples
{
    [TestFixture]
    public class Examples05
    {
        // The base URL for our example tests
        private const string BASE_URL = "https://graphql-weather-api.herokuapp.com/";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetWeatherForAmsterdam_CheckSummaryTitle()
        {
            string query = @"
                {
                    getCityByName(name: ""Amsterdam"") {
                        weather {
                            summary {
                                title
                            }
                        }
                    }
                }
            ";

            GraphQLQuery graphQLQuery = new GraphQLQuery
            {
                Query = query,
            };

            RestRequest request = new RestRequest("/", Method.Post);

            request.AddJsonBody(graphQLQuery);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(
                responseData.SelectToken("data.getCityByName.weather.summary.title").ToString(),
                Is.EqualTo("Clouds")
            );
        }

        [TestCase("Amsterdam", "Clouds", TestName = "In Amsterdam the weather is cloudy")]
        [TestCase("Berlin", "Clouds", TestName = "In Berlin the weather is cloudy")]
        [TestCase("Rome", "Clear", TestName = "In Rome the weather is clear")]
        public async Task GetWeatherForAmsterdam_CheckSummaryTitle_UsingParameterizedQuery
            (string city, string expectedWeather)
        {
            string query = @"
                query GetWeatherForCity($name: String!)
                {
                    getCityByName(name: $name) {
                        weather {
                            summary {
                                title
                            }
                        }
                    }
                }
            ";

            var variables = new
            {
                name = city
            };

            GraphQLQuery graphQLQuery = new GraphQLQuery
            {
                Query = query,
                Variables = JsonConvert.SerializeObject(variables)
            };

            RestRequest request = new RestRequest("/", Method.Post);

            request.AddJsonBody(graphQLQuery);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(
                responseData.SelectToken("data.getCityByName.weather.summary.title").ToString(),
                Is.EqualTo(expectedWeather)
            );
        }
    }
}
