using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Entities.Courses
{
    public class Course
    {
        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Foreign Keys
        public int? ProfessorId { get; set; }

        // Navigation Properties
        public User? Professor { get; set; }
    }
}
