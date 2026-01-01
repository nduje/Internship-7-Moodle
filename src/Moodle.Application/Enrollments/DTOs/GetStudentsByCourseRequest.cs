namespace Moodle.Application.Enrollments.DTOs
{
    public class GetStudentsByCourseRequest
    {
        public Guid CourseId { get; init; }

        public GetStudentsByCourseRequest(Guid course_id)
        {
            CourseId = course_id;
        }
    }
}
