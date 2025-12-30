using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Courses;

namespace Moodle.Domain.Persistence.Courses
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {
        Task<Course?> GetById(Guid id);
        Task<Course?> GetByName(string name);
        Task<IReadOnlyList<Course>> GetByProfessorId(Guid professor_id);
        Task ClearProfessor(Guid professor_id);
    }
}
