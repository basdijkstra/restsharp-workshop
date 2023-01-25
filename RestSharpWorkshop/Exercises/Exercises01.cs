using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises01 : TestBase
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
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the response content type is equal to 'application/json'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckContentType_ShouldContainApplicationJson()
        {
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the response contains a header 'Server' with value 'MockServer'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckServerHeader_ShouldBeMockServer()
        {
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the response body contains a JSON field 'firstName' with value 'John'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckFirstName_ShouldBeJohn()
        {
        }

        /**
         * Send a new GET request to /customer/12212 using the client defined above.
         * Check that the JSON field 'city', which is a child element of 'address', has value 'Beverly Hills'.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckCityInAddress_ShouldBeBeverlyHills()
        {
        }
    }
}
