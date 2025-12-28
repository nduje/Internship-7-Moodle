namespace Moodle.Application.Announcements.DTOs
{
    public class AddAnnouncementResponse
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Content { get; init; }
        public required Guid CourseId { get; init; }
    }
}
