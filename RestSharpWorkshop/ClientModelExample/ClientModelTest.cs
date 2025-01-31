using NUnit.Framework;
using RestSharpWorkshop.ClientModelExample.Client;
using RestSharpWorkshop.ClientModelExample.Models;
using System;
using System.Net;

namespace RestSharpWorkshop.ClientModelExample
{
    [TestFixture]
    public class ClientModelTest
    {
        private Uri baseUri = new Uri("https://jsonplaceholder.typicode.com");

        private PostClient postClient;

        [SetUp]
        public void CreateRestClient()
        {
            postClient = new PostClient(baseUri);
        }

        [Test]
        public void TestClientModel()
        {
            Post post = new Post
            {
                UserId = 1,
                Title = "My new blog post",
                Body = "This is awesome",
            };

            var response = postClient.CreatePost(post);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void TestClientModelWithGet()
        {
            var response = postClient.GetPost("1");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
