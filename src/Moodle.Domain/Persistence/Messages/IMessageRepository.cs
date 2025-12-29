using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Messages;

namespace Moodle.Domain.Persistence.Messages
{
    public interface IMessageRepository : IRepository<Message, int>
    {
        Task<Message?> GetById(Guid id);
        Task<IReadOnlyList<Message>> GetByConversationId(Guid conversation_id);
        Task DeleteByUserId(Guid user_id);
    }
}
