using Moodle.Domain.Entities.Courses;

namespace Moodle.Application.Announcements.DTOs
{
    public class AddAnnouncementResponse
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Content { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required Guid CourseId { get; init; }
        public required Course Course { get; init; }
    }
}
