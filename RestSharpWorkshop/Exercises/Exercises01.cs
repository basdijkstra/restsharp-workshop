﻿using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpWorkshop.Exercises
{
    [TestFixture]
    public class Exercises01
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
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the HTTP response code is equal to HttpStatusCode.OK.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckStatusCode_ShouldBeHttpOK()
        {
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the response content type contains 'application/json'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckContentType_ShouldContainApplicationJson()
        {
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the response contains a header 'charset' with value 'UTF-8'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckCharsetHeader_ShouldBeUTF8()
        {
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the response body contains a JSON field 'country' with value 'United States'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckCountry_ShouldBeUnitedStates()
        {
        }

        /**
         * Send a new GET request to /us/90210 using the client defined above.
         * Check that the first place in the response body contains a JSON field 'state' with value 'California'.
         */
        [Test]
        public async Task GetDataForUsZipCode90210_CheckStateForFirstPlace_ShouldBeCalifornia()
        {
        }
    }
}
