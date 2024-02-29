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

        /**
         * Create a new RestClient that uses basic authentication,
         * with username 'john' and password 'demo'. Pass in the BASE_URL
         * as a constructor argument.
         * 
         * Use that client to perform a GET request to /token 
         * 
         * Extract the value of the 'token' element in the
         * response into a string variable
         * 
         * Create another RestClient that uses OAuth2 authentication,
         * using the token you retrieved in the previous step. Pass in the BASE_URL
         * as a constructor argument here, too.
         * 
         * Use the new RestClient to send a GET request to /secure/customer/12212
         * 
         * Verify that the status code of this response is equal to HTTP 200
         */
        [Test]
        public async Task GetTokenUsingBasicAuth_UseInOAuth2_CheckResponseStatusCode()
        {
            // Create the RestClient using basic authentication
            var options = new RestClientOptions(BASE_URL)
            {
                Authenticator = new HttpBasicAuthenticator("john", "demo")
            };

            var client = new RestClient(options);

            // Perform the first request using basic auth
            RestRequest request = new RestRequest("/token", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            // Store the token in a string
            string token = responseData.SelectToken("token").ToString();

            // Create a new RestClient using OAuth2 authentication
            options = new RestClientOptions(BASE_URL)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };

            client = new RestClient(options);

            // Perform the second request using OAuth2
            request = new RestRequest("/secure/customer/12212", Method.Get);

            response = await client.ExecuteAsync(request);

            // Check that the status code is equal to 200
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
