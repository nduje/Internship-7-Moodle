using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Announcements;

namespace Moodle.Domain.Persistence.Announcements
{
    public interface IAnnouncementRepository : IRepository<Announcement, Guid>
    {
        Task<Announcement?> GetById(Guid id);
        Task<Announcement?> GetByTitle(string title, Guid course_id);
        Task<IReadOnlyList<Announcement>> GetByCourseId(Guid course_id);
    }
}
