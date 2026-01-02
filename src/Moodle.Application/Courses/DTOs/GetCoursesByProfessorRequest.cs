namespace Moodle.Application.Courses.DTOs
{
    public class GetCoursesByProfessorRequest
    {
        public Guid ProfessorId { get; init; }

        public GetCoursesByProfessorRequest(Guid professor_id)
        {
            ProfessorId = professor_id;
        }
    }
}
