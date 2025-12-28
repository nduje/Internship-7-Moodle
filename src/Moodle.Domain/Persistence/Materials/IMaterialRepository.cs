using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Materials;

namespace Moodle.Domain.Persistence.Materials
{
    public interface IMaterialRepository : IRepository<Material, int>
    {
        Task<Material?> GetById(Guid id);
        Task<Material?> GetByName(string name, Guid course_id);
        Task<IReadOnlyList<Material>> GetByCourseId(Guid course_id);
    }
}
