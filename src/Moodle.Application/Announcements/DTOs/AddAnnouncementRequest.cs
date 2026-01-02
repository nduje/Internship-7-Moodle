namespace Moodle.Application.Announcements.DTOs
{
    public class AddAnnouncementRequest
    {
        public string Title { get; init; }
        public string Content { get; init; }
        public Guid CourseId { get; init; }

        public AddAnnouncementRequest(string title, string content, Guid course_id)
        {
            Title = title;
            Content = content;
            CourseId = course_id;
        }
    }
}
