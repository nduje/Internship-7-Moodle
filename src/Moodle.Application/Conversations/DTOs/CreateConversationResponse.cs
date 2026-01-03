using Moodle.Domain.Entities.Users;

namespace Moodle.Application.Conversations.DTOs
{
    public class CreateConversationResponse
    {
        public required Guid Id { get; init; }
        public required Guid User1Id { get; init; }
        public required Guid User2Id { get; init; }
        public required User User1 { get; init; }
        public required User User2 { get; init; }
    }
}
