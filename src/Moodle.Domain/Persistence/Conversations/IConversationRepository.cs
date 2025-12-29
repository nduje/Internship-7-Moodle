using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Conversations;

namespace Moodle.Domain.Persistence.Conversations
{
    public interface IConversationRepository : IRepository<Conversation, int>
    {
        Task<Conversation?> GetById(Guid id);
        Task<bool> Exists(Guid user1_id, Guid user2_id);
        Task<IReadOnlyList<Conversation>> GetByUserId(Guid user_id);
        Task DeleteByUserId(Guid user_id);
    }
}
