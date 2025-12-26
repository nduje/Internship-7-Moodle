using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Enrollments;

namespace Moodle.Domain.Persistence.Enrollments
{
    public interface IEnrollmentRepository : IRepository<Enrollment, int>
    {
        Task<Enrollment?> GetById(int id);
    }
}
