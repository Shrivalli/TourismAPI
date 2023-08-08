using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tourismBigbang.Context;
using tourismBigBang.Models;
using tourismBigBang.Repository.UserViewRepo;

namespace tourismBigbang.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserViewRepo userRepository;
        private DbContextOptions<TourismContext> dbContextOptions;

        [SetUp]
        public void Setup()
        {
            // Initialize DbContextOptions for in-memory database
            dbContextOptions = new DbContextOptionsBuilder<TourismContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Initialize UserRepository with the actual TourismContext instance
            var context = new TourismContext(dbContextOptions);
            userRepository = new UserViewRepo(context);
        }

        // Rest of the test cases using the actual context...

        [Test]
        public async Task GetPackage_ShouldReturnEmptyListIfPackagesAreNull()
        {
            // Arrange
            using (var dbContext = new TourismContext(dbContextOptions))
            {
                // No need to mock DbSet, as we are using the actual TourismContext instance
                // Add test data to the in-memory database
                dbContext.Packages.Add(new Package { Id = 1, PackageName = "Package 1" });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new TourismContext(dbContextOptions))
            {
                var userRepository = new UserViewRepo(dbContext);
                var result = await userRepository.GetPackage();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Package>>(result);
                Assert.AreEqual(1, result.Count);
            }
        }



    }

}
