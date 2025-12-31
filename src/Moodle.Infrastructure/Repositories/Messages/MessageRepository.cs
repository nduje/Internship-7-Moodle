using Moodle.Domain.Entities.Messages;
using Moodle.Domain.Persistence.Messages;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;

namespace Moodle.Infrastructure.Repositories.Messages
{
    internal sealed class MessageRepository : Repository<Message, Guid>, IMessageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Message?> GetById(Guid id)
        {
            return await _dbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IReadOnlyList<Message>> GetByConversationId(Guid conversation_id)
        {
            return await _dbContext.Messages
                .Where(m => m.ConversationId == conversation_id)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task DeleteByUserId(Guid user_id)
        {
            var messages = await _dbContext.Messages
                .Where(m => m.UserId == user_id)
                .ToListAsync();

            _dbContext.Messages.RemoveRange(messages);
        }
    }
}
