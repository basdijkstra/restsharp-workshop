using NUnit.Framework;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace RestSharpWorkshop
{
    public class TestBase
    {
        protected WireMockServer Server { get; private set; }

        

        private readonly string parameterizedQuery = @"query getRocketData($id: ID!)
            {
                rocket(id: $id) {
                    name
                    country
                }
            }";

        [SetUp]
        public void StartServer()
        {
            this.Server = WireMockServer.Start(9876);

            SetupMockAnswers();
        }

        [TearDown]
        public void StopServer()
        {
            this.Server?.Stop();
        }

        private void SetupMockAnswers()
        {
            AddMockResponseForCustomer12212();
            AddMockResponseForCustomer12345();
            AddMockResponseForCustomer12456();
            AddMockResponseForBasicAuth();
            AddMockResponseForOAuth2();
            AddMockResponseForPostAccount();
            AddMockResponseForGetAccount12345();
            AddMockResponseForSimpleGraphQLQuery();
            AddMockResponseForGraphQLQueryWithVariables();
        }

        private void AddMockResponseForCustomer12212()
        {
            var customer = new
            {
                firstName = "John",
                lastName = "Smith",
                address = new
                {
                    street = "Main Street 123",
                    city = "Beverly Hills"
                }
            };

            this.Server.Given(Request.Create().WithPath("/customer/12212").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithHeader("Server", "MockServer")
                .WithBodyAsJson(customer)
                .WithStatusCode(200));
        }

        private void AddMockResponseForCustomer12345()
        {
            var customer = new
            {
                firstName = "Susan",
                lastName = "Jones",
                address = new
                {
                    street = "Main Street 234",
                    city = "Beverly Hills"
                }
            };

            this.Server.Given(Request.Create().WithPath("/customer/12345").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(customer)
                .WithStatusCode(200));
        }

        private void AddMockResponseForCustomer12456()
        {
            var customer = new
            {
                firstName = "Anna",
                lastName = "Brown",
                address = new
                {
                    street = "Main Street 456",
                    city = "Beverly Hills"
                }
            };

            this.Server.Given(Request.Create().WithPath("/customer/12456").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(customer)
                .WithStatusCode(200));
        }

        private void AddMockResponseForBasicAuth()
        {
            var response = new
            {
                token = "this_is_your_oauth2_token"
            };

            this.Server.Given(Request.Create().WithPath("/token").UsingGet()
                .WithHeader("Authorization", new ExactMatcher("Basic am9objpkZW1v")))
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response)
                .WithStatusCode(200));
        }

        private void AddMockResponseForOAuth2()
        {
            this.Server?.Given(Request.Create().WithPath("/secure/customer/12212").UsingGet()
                .WithHeader("Authorization", new ExactMatcher("Bearer this_is_your_oauth2_token")))
                .RespondWith(Response.Create()
                .WithStatusCode(200));
        }

        private void AddMockResponseForPostAccount()
        {
            this.Server?.Given(Request.Create().WithPath("/customer/12212/accounts").UsingPost()
                .WithBody(new JsonMatcher("{\"type\": \"savings\", \"balance\": 0}")))
                .RespondWith(Response.Create()
                .WithStatusCode(201));
        }

        private void AddMockResponseForGetAccount12345()
        {
            var account = new
            {
                type = "savings",
                balance = 98765
            };

            this.Server.Given(Request.Create().WithPath("/customer/12212/account/12345").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(account)
                .WithStatusCode(200));
        }

        /// <summary>
        /// Creates the stub response for the simple GraphQL example.
        /// </summary>
        private void AddMockResponseForSimpleGraphQLQuery()
        {
            var expectedQuery = new
            {
                query = "{ company { name ceo } }"
            };

            var response = new
            {
                data = new
                {
                    company = new
                    {
                        name = "SpaceX",
                        ceo = "Elon Musk",
                    },
                },
            };

            this.Server?.Given(Request.Create().WithPath("/simple-graphql").UsingPost()
                .WithBody(new JsonMatcher(expectedQuery)))
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));
        }

        private void AddMockResponseForGraphQLQueryWithVariables()
        {
            var expectedQuery = new
            {
                query = this.parameterizedQuery,
                operationName = "getRocketData",
                variables = new
                {
                    id = "falcon1",
                },
            };

            var response = new
            {
                data = new
                {
                    rocket = new
                    {
                        name = "Falcon 1",
                        country = "Republic of the Marshall Islands",
                    },
                },
            };

            this.Server?.Given(Request.Create().WithPath("/graphql-with-variables").UsingPost()
                .WithHeader("Content-Type", "application/graphql+json; charset=utf-8")
                .WithBody(new JsonMatcher(expectedQuery)))
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));
        }
    }
}
