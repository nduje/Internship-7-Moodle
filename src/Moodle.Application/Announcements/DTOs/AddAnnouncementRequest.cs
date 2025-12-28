namespace Moodle.Application.Announcements.DTOs
{
    public class AddAnnouncementRequest
    {
        public required string Title { get; init; }
        public required string Content { get; init; }
        public required Guid CourseId { get; init; }
    }
}
