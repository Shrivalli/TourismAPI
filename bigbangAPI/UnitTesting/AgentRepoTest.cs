using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Moq;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;
using tourismBigBang.Repository.AgentViewRepo;

namespace tourismBigBang.Tests
{
    [TestFixture]
    public class AgentRepoTest
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
        public async Task TestGetSpot()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);
                var placeId = 1;

                // Create test Spot objects with valid 'SpotName' properties
                var spot1 = new Spot { SpotName = "Spot 1", PlaceId = placeId };
                var spot2 = new Spot { SpotName = "Spot 2", PlaceId = placeId };

                // Add the Spot objects to the context
                context.Spots.AddRange(spot1, spot2);
                await context.SaveChangesAsync();

                // Act
                var result = await repo.GetSpot(placeId);

                // Assert
                Assert.AreEqual(2, result.Count); // Expecting 2 spots with the same PlaceId
                CollectionAssert.AreEquivalent(new List<int> { spot1.Id, spot2.Id }, result.Select(s => s.Id));
            }
        }


        [Test]
        public async Task TestGetHotel()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);
                var spotId = 1;

                // Create a test Spot object and add it to the context
                var spot = new Spot { SpotName = "TestSpot", PlaceId = spotId };
                context.Spots.Add(spot);

                // Create test Hotel objects with required properties
                var hotel1 = new Hotel { HotelName = "Hotel 1", SpotId = spotId };
                var hotel2 = new Hotel { HotelName = "Hotel 2", SpotId = 2 };

                context.Hotels.AddRange(hotel1, hotel2);
                await context.SaveChangesAsync();

                // Act
                var result = await repo.GetHotel(spotId);

                // Assert
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(hotel1.Id, result[0].Id);
            }
        }


        [Test]
        public async Task TestPostDaySchedule()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);
                var daySchedule = new DaySchedule {};

                // Act
                var result = await repo.PostDaySchedule(daySchedule);

                // Assert
                Assert.AreEqual(daySchedule, result);
                Assert.NotNull(await context.DaySchedules.FindAsync(daySchedule.Id));
            }
        }

        [Test]
        public async Task TestGetAllPackages()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);
                var packages = new List<Package>
                {
                    new Package { /* Create a Package object here */ },
                    new Package { /* Create another Package object here */ }
                };
                await context.Packages.AddRangeAsync(packages);
                await context.SaveChangesAsync();

                // Act
                var result = await repo.GetAllPackages();

                // Assert
                Assert.AreEqual(packages.Count, result.Count);
                CollectionAssert.AreEquivalent(packages.Select(p => p.Id), result.Select(p => p.Id));
            }
        }

   

        [Test]
        public async Task TestPostDaySchedule_NullDaySchedule()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);

                // Act and Assert
                var ex = Assert.ThrowsAsync<Exception>(async () => await repo.PostDaySchedule(null));
                Assert.AreEqual(CustomException.ExceptionMessages["Empty"], ex.Message);
            }
        }

        [Test]
        public async Task TestPostDaySchedule_ValidDaySchedule()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);

                // Create a test DaySchedule object
                var daySchedule = new DaySchedule
                {
                    /* Initialize other required properties for the daySchedule */
                };

                // Act
                var result = await repo.PostDaySchedule(daySchedule);

                // Assert
                Assert.AreEqual(daySchedule, result);
                Assert.NotNull(await context.DaySchedules.FindAsync(daySchedule.Id));
            }
        }

        [Test]
        public async Task TestGetAllPackages_NoPackagesFound()
        {
            // Arrange
            using (var context = new TourismContext(_options))
            {
                var repo = new AgentViewRepo(context, _hostEnvironment);

                // Act and Assert
                var ex = Assert.ThrowsAsync<Exception>(async () => await repo.GetAllPackages());
                Assert.AreEqual(CustomException.ExceptionMessages["NoId"], ex.Message);
            }
        }
    }
}
