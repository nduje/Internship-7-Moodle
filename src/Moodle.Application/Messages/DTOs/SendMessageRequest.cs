namespace Moodle.Application.Messages.DTOs
{
    public class SendMessageRequest
    {
        public Guid ConversationId { get; init; }
        public Guid SenderId { get; init; }
        public string Text { get; init; }

        public SendMessageRequest(Guid conversation_id, Guid sender_id, string text)
        {
            ConversationId = conversation_id;
            SenderId = sender_id;
            Text = text;
        }
    }
}
