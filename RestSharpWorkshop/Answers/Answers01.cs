using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers01 : TestBase
    {
        // The base URL for our example tests
        private const string BASE_URL = "http://localhost:9876";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the HTTP response code is equal to HttpStatusCode.OK.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckStatusCode_ShouldBeHttpOK()
        {
            RestRequest request = new RestRequest("/customer/12212", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the response content type is equal to 'application/json'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckContentType_ShouldContainApplicationJson()
        {
            RestRequest request = new RestRequest("/customer/12212", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the response contains a header 'Server' with value 'MockServer'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckServerHeader_ShouldBeMockServer()
        {
            RestRequest request = new RestRequest("/customer/12212", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            string serverHeaderValue = response.Headers
                .Where(x => x.Name.Equals("Server"))
                .Select(x => x.Value.ToString())
                .FirstOrDefault();

            Assert.That(serverHeaderValue, Is.EqualTo("MockServer"));
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the response body contains a JSON field 'firstName' with value 'John'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckFirstName_ShouldBeJohn()
        {
            RestRequest request = new RestRequest("/customer/12212", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("firstName").ToString(), Is.EqualTo("John"));
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the JSON field 'city', which is a child element of 'address', has value 'Beverly Hills'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckCityInAddress_ShouldBeBeverlyHills()
        {
            RestRequest request = new RestRequest("/customer/12212", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("address.city").ToString(), Is.EqualTo("Beverly Hills"));
        }
    }
}
