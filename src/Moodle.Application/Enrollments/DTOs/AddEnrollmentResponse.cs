namespace Moodle.Application.Enrollments.DTOs
{
    public class AddEnrollmentResponse
    {
        public required Guid Id { get; init; }
        public required Guid StudentId { get; init; }
        public required Guid CourseId { get; init; }
        public DateTime EnrolledAt { get; init; }
    }
}
