using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POEPART2WebApplication; // Namespace of your web app
using System.Net;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class IntegrationUITests
    {
        private WebApplicationFactory<Program> _factory;

        [TestInitialize]
        public void Setup()
        {
            // Ensure ASP.NET Core knows the HTTPS port for redirection
            Environment.SetEnvironmentVariable("ASPNETCORE_HTTPS_PORT", "7180");

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("https_port", "7180"); // tells middleware what port to use
                });
        }



        [TestMethod]
        public async Task Test_HomePage_ReturnsSuccessAndCorrectContent()
        {
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Home page failed to load.");

            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Contains("Welcome") || content.Contains("Home"),
                "Home page content is missing expected text.");
        }

        [TestMethod]
        public async Task Test_DonationsPage_LoadsSuccessfully()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Donations/Create");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Donations form page failed to load.");
        }

        

        [TestCleanup]
        public void Cleanup()
        {
            _factory.Dispose();
        }
    }
}
