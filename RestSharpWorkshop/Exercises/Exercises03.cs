using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using RestSharp.Authenticators;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises03 : TestBase
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
        }
    }
}
