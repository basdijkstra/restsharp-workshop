using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers01
    {
        // The base URL for our example tests
        private const string BASE_URL = "http://api.zippopotam.us";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the HTTP response code is equal to HttpStatusCode.OK.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckStatusCode_ShouldBeHttpOK()
        {
            RestRequest request = new RestRequest("/us/90210", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the response content type contains 'application/json'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckContentType_ShouldContainApplicationJson()
        {
            RestRequest request = new RestRequest("/us/90210", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.ContentType, Does.Contain("application/json"));
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the response contains a header 'charset' with value 'UTF-8'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckCharsetHeader_ShouldBeUTF8()
        {
            RestRequest request = new RestRequest("/us/90210", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            string charsetHeaderValue = response.Headers
                .Where(x => x.Name.Equals("charset"))
                .Select(x => x.Value.ToString())
                .FirstOrDefault();

            Assert.That(charsetHeaderValue, Is.EqualTo("UTF-8"));
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the response body contains a JSON field 'country' with value 'United States'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckCountry_ShouldBeUnitedStates()
        {
            RestRequest request = new RestRequest("/us/90210", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("country").ToString(), Is.EqualTo("United States"));
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the first place in the response body contains a JSON field 'state' with value 'California'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckStateForFirstPlace_ShouldBeCalifornia()
        {
            RestRequest request = new RestRequest("/us/90210", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("places[0].state").ToString(), Is.EqualTo("California"));
        }
    }
}
