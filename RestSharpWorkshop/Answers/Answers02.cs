using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Answers02
    {
        // The base URL for our example tests
        private const string BASE_URL = "http://api.zippopotam.us";

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
         * You will need three parameters: country code (input), zip code (input) and
         * state (expected output).
         * Replace fixed values with parameterized values to make the tests data driven.
         */
        [TestCase("us", "90210", "California", TestName = "US zip code 90210 is in California")]
        [TestCase("it", "50123", "Toscana", TestName = "IT zip code 50123 is in Toscana")]
        [TestCase("ca", "Y1A", "Yukon", TestName = "CA zip code Y1A is in Yukon")]
        public async Task GetDataFor_CheckState_ShouldEqualExpectedPlace
            (string countryCode, string zipCode, string expectedState)
        {
            RestRequest request = new RestRequest($"/{countryCode}/{zipCode}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("places[0].state").ToString(), Is.EqualTo(expectedState));
        }

        /**
         * Do the same, but now using the [TestCaseSource] attribute. Refer to the ZipCodeData
         * method defined below.
         */
        [Test, TestCaseSource("ZipCodeData")]
        public async Task GetDataFor_CheckState_ShouldEqualExpectedPlace_UsingTestCaseSource
            (string countryCode, string zipCode, string expectedState)
        {
            RestRequest request = new RestRequest($"/{countryCode}/{zipCode}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("places[0].state").ToString(), Is.EqualTo(expectedState));
        }

        /**
         * Complete the body of this method to return the required test data:
         * | country code | zip code | expected state |
         * | ------------ | -------- | -------------- |
         * |           us |    90210 |     California |
         * |           it |    50123 |        Toscana |
         * |           ca |      Y1A |          Yukon |
         * Set the test name for each iteration using the .SetName() method.
         * Make sure to use a different test name compared to the previous exercise
         * to ensure that all iterations are seen as different tests!
         */
        private static IEnumerable<TestCaseData> ZipCodeData()
        {
            yield return new TestCaseData("us", "90210", "California").
                SetName("US zip code 90210 is in California - using TestCaseSource");
            yield return new TestCaseData("it", "50123", "Toscana").
                SetName("IT zip code 50123 is in Toscana - using TestCaseSource");
            yield return new TestCaseData("ca", "Y1A", "Yukon").
                SetName("CA zip code Y1A is in Yukon - using TestCaseSource");
        }
    }
}
