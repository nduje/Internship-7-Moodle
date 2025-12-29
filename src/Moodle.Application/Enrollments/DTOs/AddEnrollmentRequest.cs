namespace Moodle.Application.Enrollments.DTOs
{
    public class AddEnrollmentRequest
    {
        public required Guid StudentId { get; init; }
        public required Guid CourseId { get; init; }
    }
}
