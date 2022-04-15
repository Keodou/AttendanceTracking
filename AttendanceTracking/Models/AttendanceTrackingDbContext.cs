using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Models
{
    public class AttendanceTrackingDbContext : IdentityDbContext<IdentityUser>
    {
        public AttendanceTrackingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>().HasData(new Student
            {
                Id = new Guid("716C2E99-6F6C-4472-81A5-43C56E11637C"),
                Name = "Кирилл Володько",
                Group = "90001997",
            });
        }
    }
}
