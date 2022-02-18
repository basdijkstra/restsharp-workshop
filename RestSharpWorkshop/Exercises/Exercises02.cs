using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises02
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
        [Test]
        public async Task GetDataForUsZipCode90210_CheckState_ShouldBeCalifornia()
        {
            RestRequest request = new RestRequest($"/us/90210", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("places[0].state").ToString(), Is.EqualTo("California"));
        }

        [Test]
        public async Task GetDataForItZipCode50123_CheckState_ShouldBeToscana()
        {
            RestRequest request = new RestRequest($"/it/50123", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("places[0].state").ToString(), Is.EqualTo("Toscana"));
        }

        [Test]
        public async Task GetDataForCaZipCodeY1A_CheckState_ShouldBeYukon()
        {
            RestRequest request = new RestRequest($"/ca/Y1A", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);

            Assert.That(responseData.SelectToken("places[0].state").ToString(), Is.EqualTo("Yukon"));
        }

        /**
         * Do the same, but now using the [TestCaseSource] attribute. Refer to the ZipCodeData
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
            return null;
        }
    }
}
