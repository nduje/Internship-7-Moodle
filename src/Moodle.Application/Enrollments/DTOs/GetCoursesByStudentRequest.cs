namespace Moodle.Application.Enrollments.DTOs
{
    public class GetCoursesByStudentRequest
    {
        public required Guid StudentId { get; init; }
    }
}
