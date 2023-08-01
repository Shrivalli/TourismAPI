using tourismBigbang.Models;
using Microsoft.EntityFrameworkCore;
using tourismBigBang.Models;

namespace tourismBigbang.Context
{
    public class TourismContext : DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<AgentApproval> AgentApprovals { get; set; }
        public DbSet<Place>Places { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DaySchedule> DaySchedules { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
