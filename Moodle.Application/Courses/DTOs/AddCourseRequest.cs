namespace Moodle.Application.Courses.DTOs
{
    public class AddCourseRequest
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public Guid? ProfessorId { get; init; }
    }
}
