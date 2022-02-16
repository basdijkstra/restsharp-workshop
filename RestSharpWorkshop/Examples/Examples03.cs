using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Examples.Models;
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
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            RestRequest request = new RestRequest($"/users/1", Method.Get);

            RestResponse<User> response = await client.ExecuteAsync<User>(request);

            User user = response.Data;

            Assert.That(user.Name, Is.EqualTo("Leanne Graham"));
        }
    }
}
