namespace Moodle.Application.Conversations.DTOs
{
    public class CreateConversationRequest
    {
        public required Guid User1Id { get; init; }
        public required Guid User2Id { get; init; }
    }
}
