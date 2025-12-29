using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Entities.Courses;

namespace Moodle.Domain.Persistence.Enrollments
{
    public interface IEnrollmentRepository : IRepository<Enrollment, int>
    {
        Task<Enrollment?> GetById(int id);
        Task<bool> Exists(Guid student_id, Guid course_id);
        Task<IReadOnlyList<Course>> GetCoursesByStudentId(Guid student_id);
    }
}
