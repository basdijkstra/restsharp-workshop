using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Answers.Models;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers05 : TestBase
    {
        // The base URL for our tests
        private const string BASE_URL = "http://localhost:9876";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /*******************************************************
         * Create a new GraphQL query as a string with value
         * { company { name ceo } }
         *
         * Create a new GraphQLQuery object and use the query as
         * the value for the Query property
         * 
         * POST this object to /simple-graphql
         *
         * Assert that the name of the CEO is Elon Musk
         *
         * Use "data.company.ceo" as the argument to SelectToken()
         * to extract the required value from the response
         */
        [Test]
        public async Task GetCompanyData_checkCeo_shouldBeElonMusk()
        {
            string query = "{ company { name ceo } }";

            GraphQLQuery graphQLQuery = new GraphQLQuery
            {
                Query = query
            };

            RestRequest request = new RestRequest("/simple-graphql", Method.Post);

            request.AddJsonBody(graphQLQuery);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(
                responseData.SelectToken("data.company.ceo").ToString(),
                Is.EqualTo("Elon Musk")
            );
        }

        /*******************************************************
         * Create a data driven test with three TestCase iterations:
         * ------------------------------------
         * rocket id   | rocket name  | country
         * ------------------------------------
         * falcon1     | Falcon 1     | Republic of the Marshall Islands
         * falconheavy | Falcon Heavy | United States
         * starship    | Starship     | United States
         *
         * Parameterize the test
         *
         * Create a new GraphQL query from the given query string
         * Pass in the rocket id as a variable value
         *
         * POST this object to https://api.spacex.land/graphql/
         * (that's the base URL, so '/' suffices as an endpoint)
         *
         * Assert that the name of the rocket is equal to the value in the TestCase
         * Use "data.rocket.name" as the argument to SelectToken()
         * to extract the required value from the response
         *
         * Also, assert that the country of the rocket is equal to the value in the TestCase
         * Use "data.rocket.country" as the argument to SelectToken()
         * to extract the required value from the response
         */
        [TestCase("falcon1", "Falcon 1", "Republic of the Marshall Islands", TestName = "Falcon 1 was launched in the Republic of the Marshall Islands")]
        [TestCase("falconheavy", "Falcon Heavy", "United States", TestName = "Falcon Heavy was launched in the United States")]
        [TestCase("starship", "Starship", "United States", TestName = "Starship was launched in the United States")]
        public async Task getRocketDataById_checkNameAndCountry
            (string rocketId, string expectedName, string expectedCountry)
        {
            string query = @"
                query getRocketData($id: ID!)
                {
                    rocket(id: $id) {
                        name
                        country
                    }
                }
            ";

            var variables = new
            {
                id = rocketId
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
                responseData.SelectToken("data.rocket.name").ToString(),
                Is.EqualTo(expectedName)
            );

            Assert.That(
                responseData.SelectToken("data.rocket.country").ToString(),
                Is.EqualTo(expectedCountry)
            );
        }
    }
}
