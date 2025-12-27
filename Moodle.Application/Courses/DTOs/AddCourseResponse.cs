namespace Moodle.Application.Courses.DTOs
{
    public class AddCourseResponse
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public Guid? ProfessorId { get; init; }
    }
}
