using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
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

        [TestCase(1, "Leanne Graham", TestName = "User 1 is Leanne Graham")]
        [TestCase(2, "Ervin Howell", TestName = "User 2 is Ervin Howell")]
        [TestCase(3, "Clementine Bauch", TestName = "User 3 is Clementine Bauch")]
        public async Task GetDataForUser_CheckName_ShouldEqualExpectedName_UsingTestCase
            (int userId, string expectedName)
        {
            RestRequest request = new RestRequest($"/users/{userId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("name").ToString(), Is.EqualTo(expectedName));
        }

        [TestCase(1, "Leanne Graham", TestName = "User 1 is Leanne Graham")]
        [TestCase(2, "Ervin Howell", TestName = "User 2 is Ervin Howell")]
        [TestCase(3, "Clementine Bauch", TestName = "User 3 is Clementine Bauch")]
        public async Task GetDataForUser_CheckName_ShouldEqualExpectedName_UsingTestCase_ExplicitPathSegment
            (int userId, string expectedName)
        {
            RestRequest request = new RestRequest("/users/{userId}", Method.Get);

            request.AddUrlSegment("userId", userId);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("name").ToString(), Is.EqualTo(expectedName));
        }

        [Test, TestCaseSource("UserData")]
        public async Task GetDataForUser_CheckName_ShouldEqualExpectedName_UsingTestCaseSource
            (int userId, string expectedName)
        {
            RestRequest request = new RestRequest($"/users/{userId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("name").ToString(), Is.EqualTo(expectedName));
        }

        private static IEnumerable<TestCaseData> UserData()
        {
            yield return new TestCaseData(1, "Leanne Graham").
                SetName("User 1 is Leanne Graham - using TestCaseSource");
            yield return new TestCaseData(2, "Ervin Howell").
                SetName("User 2 is Ervin Howell - using TestCaseSource");
            yield return new TestCaseData(3, "Clementine Bauch").
                SetName("User 3 is Clementine Bauch - using TestCaseSource");
        }
    }
}
