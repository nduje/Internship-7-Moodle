using Moodle.Domain.Entities.Announcements;
using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Entities.Materials;
using Moodle.Domain.Entities.Messages;
using Moodle.Domain.Entities.Users;
using Moodle.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;

namespace Moodle.Infrastructure.Database
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.HasDefaultSchema(Schemas.Default);

            DatabaseSeeder.SeedData(modelBuilder);
        }
    }
}
