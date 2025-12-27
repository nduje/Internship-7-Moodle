namespace Moodle.Application.Courses.DTOs
{
    public class AddCourseRequest
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
        public Guid? ProfessorId { get; init; }
    }
}
