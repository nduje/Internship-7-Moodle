using Moodle.Domain.Entities.Courses;

namespace Moodle.Domain.Entities.Materials
{
    public class Material
    {
        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        // Foreign Keys
        public required int CourseId { get; set; }

        // Navigation Properties
        public required Course Course { get; set; }
    }
}
