namespace Moodle.Application.Enrollments.DTOs
{
    public class GetStudentsByCourseRequest
    {
        public required Guid CourseId { get; init; }
    }
}
