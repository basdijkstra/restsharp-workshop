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
            AddMockAnswerForCustomer12345();
            AddMockAnswerForCustomer12456();
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

        private void AddMockAnswerForCustomer12345()
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

        private void AddMockAnswerForCustomer12456()
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
    }
}
