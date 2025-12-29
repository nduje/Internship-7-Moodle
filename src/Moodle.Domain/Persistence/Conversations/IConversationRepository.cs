using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Conversations;

namespace Moodle.Domain.Persistence.Conversations
{
    public interface IConversationRepository : IRepository<Conversation, int>
    {
        Task<Conversation?> GetById(int id);
        Task<bool> Exists(Guid user1_id, Guid user2_id);
    }
}
