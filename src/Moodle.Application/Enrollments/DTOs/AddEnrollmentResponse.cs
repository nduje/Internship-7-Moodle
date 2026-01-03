using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Users;

namespace Moodle.Application.Enrollments.DTOs
{
    public class AddEnrollmentResponse
    {
        public required Guid Id { get; init; }
        public required Guid StudentId { get; init; }
        public required Guid CourseId { get; init; }
        public DateTime EnrolledAt { get; init; }

        public required User Student { get; init; }
        public required Course Course { get; init; }
    }
}
