using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Messages;

namespace Moodle.Domain.Persistence.Messages
{
    public interface IMessageRepository : IRepository<Message, int>
    {
        Task<Message?> GetById(int id);
    }
}
