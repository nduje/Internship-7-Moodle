using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;

namespace Moodle.Infrastructure.Repositories.Conversations
{
    internal sealed class ConversationRepository : Repository<Conversation, Guid>, IConversationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConversationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Conversation?> GetById(Guid id)
        {
            return await _dbContext.Conversations
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Exists(Guid user1_id, Guid user2_id)
        {
            return await _dbContext.Conversations
                .AnyAsync(c =>
                    (c.User1Id == user1_id &&  c.User2Id == user2_id) ||
                    (c.User1Id == user2_id && c.User2Id == user1_id));
        }

        public async Task<IReadOnlyList<Conversation>> GetByUserId(Guid user_id)
        {
            return await _dbContext.Conversations
                .Where(c => c.User1Id == user_id || c.User2Id == user_id)
                .ToListAsync();
        }

        public async Task DeleteByUserId(Guid user_id)
        {
            var conversations = await _dbContext.Conversations
                .Where(c => c.User1Id == user_id || c.User2Id == user_id)
                .ToListAsync();

            _dbContext.Conversations.RemoveRange(conversations);
        }
    }
}
