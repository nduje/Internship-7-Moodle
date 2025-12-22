using Moodle.Domain.Entities.Users;
using Moodle.Domain.Entities.Courses;

namespace Moodle.Domain.Entities.Enrollments
{
    public class Enrollment
    {
        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public DateTime EnrolledAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public required int StudentId { get; set; }
        public required int CourseId { get; set; }

        // Navigation Properties
        public required User Student { get; set; }
        public required Course Course { get; set; }
    }
}
