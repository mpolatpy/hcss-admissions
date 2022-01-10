using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<WaitList> WaitLists { get; set; }
        public DbSet<StudentWaitLists> StudentWaitLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);               
            
            builder.Entity<AppUser>(x => 
            {
                x.HasMany(x => x.UserRoles)
                    .WithOne()
                    .HasForeignKey(x => x.UserId);
            });

            builder.Entity<StudentWaitLists>(x => x.HasKey(sw => new {sw.WaitListId, sw.StudentId}));

            builder.Entity<StudentWaitLists>()
                .HasOne(sw => sw.Student)
                .WithMany(s => s.WaitLists)
                .HasForeignKey(sw => sw.StudentId);

            builder.Entity<StudentWaitLists>()
                .HasOne(sw => sw.WaitList)
                .WithMany(s => s.Students)
                .HasForeignKey(sw => sw.WaitListId);

            builder.Entity<Application>()
                .HasOne(a => a.SchoolYear)
                .WithMany(sy => sy.Applications)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Application>()
                .HasOne(a => a.School)
                .WithMany(s => s.Applications)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Application>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Applications)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Application>()
                .HasOne(a => a.AppUser)
                .WithMany(s => s.Applications)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<WaitList>()
                .HasOne(l => l.SchoolYear)
                .WithMany(sy => sy.WaitLists)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<WaitList>()
                .HasOne(l => l.School)
                .WithMany(s => s.WaitLists)
                .OnDelete(DeleteBehavior.NoAction);   
        }
    }
}