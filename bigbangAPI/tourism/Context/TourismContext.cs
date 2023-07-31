using tourismBigbang.Models;
using Microsoft.EntityFrameworkCore;
using tourismBigBang.Models;

namespace tourismBigbang.Context
{
    public class TourismContext : DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Place>Places { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DaySchedule> DaySchedules { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Owner>().ToTable("owners");

        }
    }
}
