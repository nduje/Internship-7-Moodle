using Moodle.Domain.Entities.Users;

namespace Moodle.Application.Enrollments.DTOs
{
    public class GetCoursesByStudentResponse
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public User? Professor {  get; init; }
    }
}
