namespace Moodle.Application.Courses.DTOs
{
    public class GetProfessorCoursesResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
