using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Persistence.Courses;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;

namespace Moodle.Infrastructure.Repositories.Courses
{
    internal sealed class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course?> GetById(Guid id)
        {
            return await _dbContext.Courses
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course?> GetByName(string name)
        {
            return await _dbContext.Courses
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IReadOnlyList<Course>> GetByProfessorId(Guid professor_id)
        {
            return await _dbContext.Courses
                .Where(c => c.ProfessorId == professor_id)
                .ToListAsync();
        }

        public async Task ClearProfessor(Guid professor_id)
        {
            var courses = await _dbContext.Courses
                .Where(c => c.ProfessorId == professor_id)
                .ToListAsync();

            foreach (var course in courses)
            {
                course.ProfessorId = null;
            }
        }
    }
}
