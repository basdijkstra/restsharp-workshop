using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers02 : TestBase
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
        [TestCase(12212, "John", TestName = "Customer 12212 is John")]
        [TestCase(12345, "Susan", TestName = "Customer 12345 is Susan")]
        [TestCase(12456, "Anna", TestName = "Customer 12456 is Anna")]
        public async Task GetDataFor_CheckFirstName_ShouldEqualExpectedName
            (int customerId, string expectedFirstName)
        {
            RestRequest request = new RestRequest($"/customer/{customerId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("firstName").ToString(), Is.EqualTo(expectedFirstName));
        }

        /**
         * Do the same, but now using the [TestCaseSource] attribute. Refer to the CustomerData
         * method defined below.
         */
        [Test, TestCaseSource(nameof(CustomerData))]
        public async Task GetDataFor_CheckFirstName_ShouldEqualExpectedName_UsingTestCaseSource
            (int customerId, string expectedFirstName)
        {
            RestRequest request = new RestRequest($"/customer/{customerId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("firstName").ToString(), Is.EqualTo(expectedFirstName));
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
            yield return new TestCaseData(12212, "John").
                SetName("Customer 12212 is John - using TestCaseSource");
            yield return new TestCaseData(12345, "Susan").
                SetName("Customer 12345 is Susan - using TestCaseSource");
            yield return new TestCaseData(12456, "Anna").
                SetName("Customer 12456 is Anna - using TestCaseSource");
        }
    }
}
