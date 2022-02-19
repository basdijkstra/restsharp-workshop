using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpWorkshop.Exercises.Models;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises04
    {
        // The base URL for our tests
        private const string BASE_URL = "https://api.spacex.land/graphql/";

        // The RestSharp client we'll use to make our requests
        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /*******************************************************
         * Create a new GraphQL query as a string with value
         * { company { name ceo coo } }
         * 
         * Create a new GraphQLQuery object and use the query as
         * the value for the Query property
         *
         * POST this object to https://api.spacex.land/graphql/
         * (that's the base URL, so '/' suffices as an endpoint)
         *
         * Assert that the name of the CEO is Elon Musk
         *
         * Use "data.company.ceo" as the argument to SelectToken()
         * to extract the required value from the response
         */
        [Test]
        public async Task GetCompanyData_checkCeo_shouldBeElonMusk()
        {
        }

        /*******************************************************
         * Create a data driven test with three TestCase iterations:
         * ------------------------------------
         * rocket id   | rocket name  | country
         * ------------------------------------
         * falcon1     | Falcon 1     | Republic of the Marshall Islands
         * falconheavy | Falcon Heavy | United States
         * starship    | Starship     | United States
         *
         * Parameterize the test
         *
         * Create a new GraphQL query from the given query string
         * Pass in the rocket id as a variable value
         *
         * POST this object to https://api.spacex.land/graphql/
         * (that's the base URL, so '/' suffices as an endpoint)
         *
         * Assert that the name of the rocket is equal to the value in the TestCase
         * Use "data.rocket.name" as the argument to SelectToken()
         * to extract the required value from the response
         *
         * Also, assert that the country of the rocket is equal to the value in the TestCase
         * Use "data.rocket.country" as the argument to SelectToken()
         * to extract the required value from the response
         */
        [Test]
        public async Task getRocketDataById_checkNameAndCountry()
        {
            string query = @"
                query getRocketData($id: ID!)
                {
                    rocket(id: $id) {
                        name
                        country
                    }
                }
            ";
        }
    }
}
