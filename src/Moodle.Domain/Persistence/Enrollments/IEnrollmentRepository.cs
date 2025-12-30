using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Persistence.Enrollments
{
    public interface IEnrollmentRepository : IRepository<Enrollment, Guid>
    {
        Task<Enrollment?> GetById(Guid id);
        Task<bool> Exists(Guid student_id, Guid course_id);
        Task<IReadOnlyList<Course>> GetCoursesByStudentId(Guid student_id);
        Task<IReadOnlyList<User>> GetStudentsByCourseId(Guid course_id);
        Task DeleteByStudentId(Guid student_id);
    }
}
