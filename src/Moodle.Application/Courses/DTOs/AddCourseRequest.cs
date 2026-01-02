namespace Moodle.Application.Courses.DTOs
{
    public class AddCourseRequest
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public Guid? ProfessorId { get; init; }

        public AddCourseRequest(string name, string description, Guid professor_id)
        {
            Name = name;
            Description = description;
            ProfessorId = professor_id;
        }
    }
}
