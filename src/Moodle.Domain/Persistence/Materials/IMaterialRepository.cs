using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Materials;

namespace Moodle.Domain.Persistence.Materials
{
    public interface IMaterialRepository : IRepository<Material, int>
    {
        Task<Material?> GetById(int id);
    }
}
