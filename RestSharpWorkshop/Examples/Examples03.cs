using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Examples.Models;
using System.Net;
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

        [Test]
        public async Task PostNewPost_CheckStatusCode_ShouldBeHttpCreated()
        {
            Post post = new Post
            {
                UserId = 1,
                Title = "My new post title",
                Body = "This is the body of my new post"
            };

            RestRequest request = new RestRequest($"/posts", Method.Post);

            request.AddJsonBody(post);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
