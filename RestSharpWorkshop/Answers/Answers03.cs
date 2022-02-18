using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Answers.Models;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers03
    {
        // The base URLs for our tests
        private const string BASE_URL_ZIP = "http://api.zippopotam.us";
        private const string BASE_URL_COMMENT = "http://jsonplaceholder.typicode.com";

        // The RestSharp clients we'll use to make our requests
        private RestClient clientZip;
        private RestClient clientComment;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            clientZip = new RestClient(BASE_URL_ZIP);
            clientComment = new RestClient(BASE_URL_COMMENT);
        }

        /**
         * Send a GET request to /us/90210 using the clientZip client defined above.
         * Deserialize the response into an object of type RestResponse<LocationData>
         * and extract its Data property into an object of type LocationData.
         * Assert that the State property of the first Place in the Places property
         * (hint: use the array index [0]) of that object has value 'California'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckState_ShouldEqualCalifornia()
        {
            RestRequest request = new RestRequest($"/us/90210", Method.Get);

            RestResponse<LocationData> response = await clientZip.ExecuteAsync<LocationData>(request);

            LocationData locationData = response.Data;

            Assert.That(locationData.Places[0].State, Is.EqualTo("California"));
        }

        /**
         * Create a new object of type Comment and set values for the PostId (integer, use 1),
         * Name, Email and Body (all string).
         * Send a POST request using the serialized Comment object as JSON body to /comments.
         * Use the clientComment RestSharp client to do this!
         * Check that the response HTTP status code is equal to Created.
         */
        [Test]
        public async Task PostNewComment_CheckStatusCode_ShouldEqualHttpCreated()
        {
            Comment comment = new Comment
            {
                PostId = 1,
                Name = "John Doe",
                Email = "john@doe.com",
                Body = "Here's a comment on your recent post"
            };

            RestRequest request = new RestRequest($"/comments", Method.Post);

            request.AddJsonBody(comment);

            RestResponse response = await clientComment.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
