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
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ApplicantParent> ApplicantParents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // override to define many to many relationship with extra fields 
            base.OnModelCreating(builder);
            // define a new primary key for the ApplicantParent table
            builder.Entity<ApplicantParent>(
                x => x.HasKey(ap => new { ap.StudentId, ap.ParentId })
            );

            // realationship with Student
            builder.Entity<ApplicantParent>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Parents)
                .HasForeignKey(ap => ap.StudentId);

            // relationship with Parent
            builder.Entity<ApplicantParent>()
                .HasOne(ap => ap.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(ap => ap.ParentId);     

            builder.Entity<Application>()
                .HasOne(a => a.SchoolYear)
                .WithMany(sy => sy.Applications)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}