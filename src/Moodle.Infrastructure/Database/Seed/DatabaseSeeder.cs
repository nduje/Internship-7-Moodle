using Moodle.Domain.Entities.Announcements;
using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Entities.Materials;
using Moodle.Domain.Entities.Messages;
using Moodle.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Moodle.Infrastructure.Database.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData();

            modelBuilder.Entity<Course>().HasData();

            modelBuilder.Entity<Enrollment>().HasData();
            
            modelBuilder.Entity<Material>().HasData();
            
            modelBuilder.Entity<Announcement>().HasData();
            
            modelBuilder.Entity<Conversation>().HasData();
            
            modelBuilder.Entity<Message>().HasData();
        }
    }
}
