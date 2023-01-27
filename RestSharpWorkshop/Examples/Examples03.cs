using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Examples
{
    [TestFixture]
    public class Examples03
    {
        // The base URL for our example tests
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task SetAuthentication()
        {
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("access_token", "Bearer");
        }
    }
}
