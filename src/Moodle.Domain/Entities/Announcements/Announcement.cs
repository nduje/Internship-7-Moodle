using Moodle.Domain.Entities.Courses;

namespace Moodle.Domain.Entities.Announcements
{
    public class Announcement
    {
        public const int TitleMaxLength = 128;
        public const int ContentMaxLength = 1024;

        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        // Foreign Keys
        public required int CourseId { get; set; }

        // Navigation Properties
        public required Course Course { get; set; }

    }
}
