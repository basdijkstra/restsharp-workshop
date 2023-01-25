using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace RestSharpWorkshop
{
    public class TestBase
    {
        protected WireMockServer Server { get; private set; }

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
            AddMockAnswerForCustomer12212();
        }

        private void AddMockAnswerForCustomer12212()
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
    }
}
