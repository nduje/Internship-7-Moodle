using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Courses;

namespace Moodle.Domain.Persistence.Courses
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        Task<Course?> GetById(int id);
        Task<Course?> GetByName(string name);
    }
}
