using Moodle.Domain.Entities.Announcements;
using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Entities.Materials;
using Moodle.Domain.Entities.Messages;
using Moodle.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Infrastructure.Database.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Users
            var admin_id = Guid.Parse("11111111-1111-1111-1111-111111111111");

            var professor1_id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var professor2_id = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var student1_id = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var student2_id = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var student3_id = Guid.Parse("66666666-6666-6666-6666-666666666666");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = admin_id,
                    FirstName = "Marko",
                    LastName = "Markić",
                    BirthDate = null,
                    Email = "admin@moodle.hr",
                    Password = "Admin@123!",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = professor1_id,
                    FirstName = "Sven",
                    LastName = "Gotovac",
                    BirthDate = null,
                    Email = "sven@moodle.hr",
                    Password = "Professor@123!",
                    Role = UserRole.Professor
                },
                new User
                {
                    Id = professor2_id,
                    FirstName = "Toni",
                    LastName = "Perković",
                    BirthDate = null,
                    Email = "toni@moodle.hr",
                    Password = "Professor@456!",
                    Role = UserRole.Professor
                },
                new User
                {
                    Id = student1_id,
                    FirstName = "Luka",
                    LastName = "Lukić",
                    BirthDate = null,
                    Email = "luka.lukic@moodle.hr",
                    Password = "Student@123!",
                    Role = UserRole.Student
                },
                new User
                {
                    Id = student2_id,
                    FirstName = "Mate",
                    LastName = "Matić",
                    BirthDate = null,
                    Email = "mate.matic@moodle.hr",
                    Password = "Student@456!",
                    Role = UserRole.Student
                },
                new User
                {
                    Id = student3_id,
                    FirstName = "Josipa",
                    LastName = "Josipović",
                    BirthDate = null,
                    Email = "josipa.josipovic@moodle.hr",
                    Password = "Student@789!",
                    Role = UserRole.Student
                }
            );

            // Courses
            var course1_id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var course2_id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = course1_id,
                    Name = "Arhitektura digitalnih računala",
                    Description = "Osnove arhitekture digitalnih sustava.",
                    ProfessorId = professor1_id
                },
                new Course
                {
                    Id = course2_id,
                    Name = "Računalna forenzika",
                    Description = "Uvod u digitalnu forenziku i analizu dokaza.",
                    ProfessorId = professor2_id
                }
            );

            // Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = student1_id,
                    CourseId = course1_id
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = student2_id,
                    CourseId = course1_id
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = student3_id,
                    CourseId = course2_id
                }
            );

            // Materials
            var material1_id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
            var material2_id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

            modelBuilder.Entity<Material>().HasData(
                new Material
                {
                    Id = material1_id,
                    Name = "Logički sklopovi i vrata",
                    Url = "https://example.com/logicki-sklopovi-i-vrata",
                    CourseId = course1_id
                },
                new Material
                {
                    Id = material2_id,
                    Name = "Memorijski sustavi",
                    Url = "https://example.com/memorijski-sustavi",
                    CourseId = course2_id
                }
            );

            // Announcements
            modelBuilder.Entity<Announcement>().HasData(
                new Announcement
                {
                    Id = Guid.NewGuid(),
                    Title = "Dobrodošli",
                    Content = "Dobrodošli na kolegij.",
                    CourseId = course1_id
                },
                new Announcement
                {
                    Id = Guid.NewGuid(),
                    Title = "Dobrodošli",
                    Content = "Dobrodošli na kolegij.",
                    CourseId = course2_id
                },
                new Announcement
                {
                    Id = Guid.NewGuid(),
                    Title = "Kolokvij najava",
                    Content = "Detalji o kolokviju bit će objavljeni.",
                    CourseId = course1_id
                },
                new Announcement
                {
                    Id = Guid.NewGuid(),
                    Title = "Kolokvij najava",
                    Content = "Kolokvij će se održati sredinom semestra.",
                    CourseId = course2_id
                }
            );

            // Conversations
            var conversation_id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

            modelBuilder.Entity<Conversation>().HasData(
                new Conversation
                {
                    Id = conversation_id,
                    User1Id = professor1_id,
                    User2Id = student1_id,
                }
            );

            // Messages
            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    Id = Guid.NewGuid(),
                    ConversationId = conversation_id,
                    UserId = student1_id,
                    Text = "Poštovani Sven, kako ste?"
                },
                new Message
                {
                    Id = Guid.NewGuid(),
                    ConversationId = conversation_id,
                    UserId = professor1_id,
                    Text = "Odlično."
                }
            );
        }
    }
}

