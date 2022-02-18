using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Exercises.Models;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises03
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
        }
    }
}
