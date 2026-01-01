namespace Moodle.Application.Enrollments.DTOs
{
    public class AddEnrollmentRequest
    {
        public Guid StudentId { get; init; }
        public Guid CourseId { get; init; }

        public AddEnrollmentRequest(Guid student_id, Guid course_id)
        {
            StudentId = student_id;
            CourseId = course_id;
        }
    }
}
