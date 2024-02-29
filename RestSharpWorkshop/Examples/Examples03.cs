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

        [Test]
        public async Task SetBasicAuthentication()
        {
            var options = new RestClientOptions(BASE_URL)
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };

            var client = new RestClient(options);
        }

        [Test]
        public async Task SetOAuth2Authentication()
        {
            var options = new RestClientOptions(BASE_URL)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("access_token", "Bearer")
            };

            var client = new RestClient(options);
        }
    }
}
