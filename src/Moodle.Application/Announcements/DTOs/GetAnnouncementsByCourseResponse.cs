namespace Moodle.Application.Announcements.DTOs
{
    public class GetAnnouncementsByCourseResponse
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Content { get; init; }
        public required DateTime CreatedAt { get; init; }
    }
}
