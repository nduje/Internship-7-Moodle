using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Announcements;

namespace Moodle.Domain.Persistence.Announcements
{
    public interface IAnnouncementRepository : IRepository<Announcement, int>
    {
        Task<Announcement?> GetById(int id);
    }
}
