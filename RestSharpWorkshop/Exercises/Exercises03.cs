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
        }
    }
}
