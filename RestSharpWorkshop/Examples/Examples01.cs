using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Examples
{
    [TestFixture]
    public class Examples01
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
        public async Task GetDataForUser1_CheckStatusCode_ShouldBeHttpOK()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetDataForUser1_CheckStatusCode_ShouldBeHttp200()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task GetDataForUser2_CheckContentType_ShouldBeApplicationJson()
        {
            RestRequest request = new RestRequest("/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.ContentType, Does.Contain("application/json"));
        }

        [Test]
        public async Task GetDataForUser3_CheckServerHeader_ShouldBeCloudflare()
        {
            RestRequest request = new RestRequest("/users/3", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            string serverHeaderValue = response.Headers
                .Where(x => x.Name.Equals("Server"))
                .Select(x => x.Value.ToString())
                .FirstOrDefault();

            Assert.That(serverHeaderValue, Is.EqualTo("cloudflare"));
        }

        [Test]
        public async Task GetDataForUser4_CheckName_ShouldBePatriciaLebsack()
        {
            RestRequest request = new RestRequest("/users/4", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.GetValue("name").ToString(), Is.EqualTo("Patricia Lebsack"));
        }
    }
}
