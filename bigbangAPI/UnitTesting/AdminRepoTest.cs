using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;
using tourismBigBang.Repository.AdminViewRepo;

namespace tourismBigBang.Tests
{
    [TestFixture]
    public class AdminViewRepoTests
    {
        private DbContextOptions<TourismContext> _options;
        private IWebHostEnvironment _hostEnvironment;

        [SetUp]
        public void SetUp()
        {
            // Set up the in-memory database
            _options = new DbContextOptionsBuilder<TourismContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Set up the IWebHostEnvironment mock for saving images
            var environmentMock = new Mock<IWebHostEnvironment>();
            environmentMock.Setup(e => e.ContentRootPath).Returns(Path.GetTempPath());
            _hostEnvironment = environmentMock.Object;
        }

        [Test]
        public async Task TestPostAgentApproval()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AdminViewRepo(context, _hostEnvironment);
              
                var userInfo = new UserInfo { /* Create a UserInfo object here */ };

                // Act
                var result = await repo.PostAgentApproval(userInfo);

                // Assert
                Assert.AreEqual(userInfo, result);
                Assert.NotNull(await context.UserInfos.FindAsync(userInfo.Id));
            }
        }

        [Test]
        public async Task TestGetAgentApproval()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AdminViewRepo(context, _hostEnvironment);
                var userInfo1 = new UserInfo { IsActive = false, Role = "Agent" };
                var userInfo2 = new UserInfo { IsActive = false, Role = "Customer" };
                await context.UserInfos.AddRangeAsync(userInfo1, userInfo2);
                await context.SaveChangesAsync();

                // Act
                var result = await repo.GetAgentApproval();

                // Assert
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(userInfo1.Id, result[0].Id);
            }
        }

        [Test]
        public async Task TestUpdateAgentApproval()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AdminViewRepo(context, _hostEnvironment);
                var userInfo = new UserInfo { IsActive = false, Role = "Agent" };
                await context.UserInfos.AddAsync(userInfo);
                await context.SaveChangesAsync();

                // Act
                var result = await repo.UpdateAgentApproval(userInfo.Id);

                // Assert
                Assert.AreEqual(userInfo.Id, result.Id);
                Assert.IsTrue(result.IsActive);
            }
        }

        [Test]
        public async Task TestDeleteApproval()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AdminViewRepo(context, _hostEnvironment);
                var userInfo = new UserInfo { IsActive = false, Role = "Agent" };
                await context.UserInfos.AddAsync(userInfo);
                await context.SaveChangesAsync();

                // Act
                var result = await repo.DeleteApproval(userInfo.Id);

                // Assert
                Assert.AreEqual(userInfo.Id, result.Id);
                Assert.IsNull(await context.UserInfos.FindAsync(userInfo.Id));
            }
        }

           }
}
