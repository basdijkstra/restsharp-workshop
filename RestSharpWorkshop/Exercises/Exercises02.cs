using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises02 : TestBase
    {
        // The base URL for our example tests
        private const string BASE_URL = "http://localhost:9876";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * Refactor these three tests into a single, data driven test using the
         * [TestCase] attribute.
         * Add parameters to the test method and think about their data types.
         * Replace fixed values with parameterized values to make the tests data driven.
         */
        [Test]
        public async Task GetDataForCustomer12212_CheckFirstName_ShouldBeJohn()
        {
            RestRequest request = new RestRequest($"/customer/12212", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("firstName").ToString(), Is.EqualTo("John"));
        }

        [Test]
        public async Task GetDataForCustomer12345_CheckFirstName_ShouldBeSusan()
        {
            RestRequest request = new RestRequest($"/customer/12345", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("firstName").ToString(), Is.EqualTo("Susan"));
        }

        [Test]
        public async Task GetDataForCustomer12456_CheckFirstName_ShouldBeAnna()
        {
            RestRequest request = new RestRequest($"/customer/12456", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("firstName").ToString(), Is.EqualTo("Anna"));
        }

        /**
         * Do the same, but now using the [TestCaseSource] attribute. Refer to the CustomerData
         * method defined below.
         */
        [Test]
        public async Task GetDataFor_CheckPlace_ShouldEqualExpectedPlace_UsingTestCaseSource()
        {
            // Copy the test method body from the previous exercise,
            // you should be able to reuse it without changes.
        }

        /**
         * Complete the body of this method to return the required test data:
         * | customerId | expectedFirstName |
         * | ---------- | ----------------- |
         * |      12212 |              John |
         * |      12345 |             Susan |
         * |      12456 |              Anna |
         * Set the test name for each iteration using the .SetName() method.
         * Make sure to use a different test name compared to the previous exercise
         * to ensure that all iterations are seen as different tests!
         */
        private static IEnumerable<TestCaseData> CustomerData()
        {
            return null;
        }
    }
}
