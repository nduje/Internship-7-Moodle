namespace Moodle.Application.Messages.DTOs
{
    public class SendMessageRequest
    {
        public required Guid ConversationId { get; init; }
        public required Guid SenderId { get; init; }
        public required string Text { get; init; }
    }
}
