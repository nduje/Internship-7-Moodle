namespace Moodle.Application.Enrollments.DTOs
{
    public class GetCoursesByStudentRequest
    {
        public Guid StudentId { get; init; }

        public GetCoursesByStudentRequest(Guid student_id)
        {
            StudentId = student_id;
        }
    }
}
