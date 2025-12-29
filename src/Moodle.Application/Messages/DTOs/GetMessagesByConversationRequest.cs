namespace Moodle.Application.Messages.DTOs
{
    public class GetMessagesByConversationRequest
    {
        public required Guid ConversationId { get; init; }
        public required Guid UserId { get; init; }
    }
}
