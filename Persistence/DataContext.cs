using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Lottery> Lotteries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);               

            builder.Entity<Application>()
                .HasOne(a => a.SchoolYear)
                .WithMany(sy => sy.Applications)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Application>()
                .HasOne(a => a.School)
                .WithMany(s => s.Applications)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Application>()
                .HasOne(a => a.Lottery)
                .WithMany(l => l.Applications)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Lottery>()
                .HasOne(l => l.SchoolYear)
                .WithMany(sy => sy.Lotteries)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Lottery>()
                .HasOne(l => l.School)
                .WithMany(s => s.Lotteries)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}