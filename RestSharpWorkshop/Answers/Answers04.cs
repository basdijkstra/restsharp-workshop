using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Answers.Models;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Answers
{
    [TestFixture]
    public class Exercises04 : TestBase
    {
        // The base URL for our tests
        private const string BASE_URL = "http://localhost:9876";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * Create a new Account object with 'savings' as the account type and balance 0
         * 
         * POST this object to /customer/12212/accounts
         * 
         * Verify that the response HTTP status code is equal to 201 (Created)
         */
        [Test]
        public async Task PostSavingsAccount_CheckStatusCode_ShouldEqual201()
        {
            Account account = new Account
            {
                Type = "savings",
                Balance = 0
            };

            RestRequest request = new RestRequest($"/customer/12212/accounts", Method.Post);

            request.AddJsonBody(account);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        /**
         * Perform an HTTP GET to /customer/12212/account/12345
         * 
         * Deserialize the response into an object of type Account
         * 
         * Check that the value of the Balance property of this account is equal to 98765
         */
        [Test]
        public async Task GetAccount_CheckBalance_ShouldEqual98765()
        {
            RestRequest request = new RestRequest($"/customer/12212/account/12345", Method.Get);

            RestResponse<Account> response = await client.ExecuteAsync<Account>(request);

            Account account = response.Data;

            Assert.That(account.Balance, Is.EqualTo(98765));
        }
    }
}
