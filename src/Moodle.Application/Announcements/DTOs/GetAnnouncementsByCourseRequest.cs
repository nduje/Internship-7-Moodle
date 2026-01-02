namespace Moodle.Application.Announcements.DTOs
{
    public class GetAnnouncementsByCourseRequest
    {
        public Guid CourseId { get; init; }

        public GetAnnouncementsByCourseRequest(Guid course_id)
        {
            CourseId = course_id;
        }
    }
}
