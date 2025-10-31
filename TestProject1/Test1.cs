using System.Collections.Generic;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestProject1

{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using POEPART2WebApplication;
    using POEPART2WebApplication.Controllers;
    using POEPART2WebApplication.Data;
    using POEPART2WebApplication.Models;

    [TestClass]
    public class DonationsControllerTests_Delete_InMemory
    {
        private AppDbContext _context;
        private DonationsController _controller;

        [TestInitialize]
        public void Setup()
        {
            // Use a unique database name per test run
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "DonationsTestDb")
                .Options;

            _context = new AppDbContext(options);

            // ✅ Seed test data
            var project = new Project { ProjectID = 1, ProjectName = "Test Project", Description="Description",Location="Location",Status="Pending"};
            var user = new User { UserID = 1, Email = "test@test.com",ContactNumber="12345",Password="Password",Role="User",Name="Name" };

            _context.Projects.Add(project);
            _context.Users.Add(user);
            _context.Donations.Add(new Donation
            {
                DonationID = 1,
                ProjectID = 1,
                UserID = 1,
                Project = project,
                User = user
            });

            _context.SaveChanges();

            _controller = new DonationsController(_context);
        }

        [TestMethod]
        public async Task Delete_IdIsNull_ReturnsNotFound()
        {
            // Act
            var result = await _controller.Delete(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Delete_DonationNotFound_ReturnsNotFound()
        {
            // Act
            var result = await _controller.Delete(999); // non-existing ID

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Delete_ValidId_ReturnsViewWithDonation()
        {
            // Act
            var result = await _controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Donation));

            var donation = result.Model as Donation;
            Assert.AreEqual(1, donation.DonationID);
            Assert.AreEqual("Test Project", donation.Project.ProjectName);
            Assert.AreEqual("test@test.com", donation.User.Email);
        }
    }
}
