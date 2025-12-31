using Moodle.Domain.Entities.Announcements;
using Moodle.Domain.Persistence.Announcements;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;

namespace Moodle.Infrastructure.Repositories.Announcements
{
    internal sealed class AnnouncementRepository : Repository<Announcement, Guid>, IAnnouncementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AnnouncementRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Announcement?> GetById(Guid id)
        {
            return await _dbContext.Announcements
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Announcement?> GetByTitle(string title, Guid course_id)
        {
            return await _dbContext.Announcements
                .FirstOrDefaultAsync(a => a.Title == title && a.CourseId == course_id);
        }

        public async Task<IReadOnlyList<Announcement>> GetByCourseId(Guid course_id)
        {
            return await _dbContext.Announcements
                .Where(a => a.CourseId == course_id)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }
    }
}
