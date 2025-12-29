namespace Moodle.Application.Messages.DTOs
{
    public class SendMessageResponse
    {
        public required Guid Id { get; init; }
        public required Guid ConversationId { get; init; }
        public required Guid SenderId { get; init; }
        public required string Text { get; init; }
        public required DateTime Timestamp { get; init; }
    }
}
