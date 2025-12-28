namespace Moodle.Application.Courses.DTOs
{
    public class GetCoursesByProfessorResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
