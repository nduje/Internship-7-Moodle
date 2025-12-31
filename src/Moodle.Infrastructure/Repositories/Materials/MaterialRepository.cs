using Moodle.Domain.Entities.Materials;
using Moodle.Domain.Persistence.Materials;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;

namespace Moodle.Infrastructure.Repositories.Materials
{
    internal sealed class MaterialRepository : Repository<Material, Guid>, IMaterialRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MaterialRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Material?> GetById(Guid id)
        {
            return await _dbContext.Materials
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Material?> GetByName(string name, Guid course_id)
        {
            return await _dbContext.Materials
                .FirstOrDefaultAsync(m => m.Name == name && m.CourseId == course_id);
        }

        public async Task<IReadOnlyList<Material>> GetMaterialsByCourseId(Guid course_id)
        {
            return await _dbContext.Materials
                .Where(m => m.CourseId == course_id)
                .ToListAsync();
        }
    }
}
