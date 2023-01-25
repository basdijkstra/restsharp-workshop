using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers03 : TestBase
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
         * Perform a GET request to /token and pass in basic
         * authentication details with username 'john' and
         * password 'demo'.
         * 
         * Extract the value of the 'token' element in the
         * response into a string variable.
         * 
         * Use the token to authenticate using OAuth2 when sending
         * a GET request to /secure/customer/12212
         * 
         * Verify that the status code of this response is equal to HTTP 200
         */
        [Test]
        public async Task GetTokenUsingBasicAuth_UseInOAuht2_CheckResponseStatusCode()
        {
            // Set the correct basic auth credentials on the client
            client.Authenticator = new HttpBasicAuthenticator("john", "demo");

            // Perform the first request using basic auth
            RestRequest request = new RestRequest("/token", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            // Store the token in a string
            string token = responseData.SelectToken("token").ToString();

            // Set OAuth2 authentication using the token retrieved before
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

            // Perform the second request using OAuth2
            request = new RestRequest("/secure/customer/12212", Method.Get);

            response = await client.ExecuteAsync(request);

            // Check that the status code is equal to 200
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
