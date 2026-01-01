namespace Moodle.Application.Messages.DTOs
{
    public class GetMessagesByConversationRequest
    {
        public Guid ConversationId { get; init; }
        public Guid UserId { get; init; }

        public GetMessagesByConversationRequest(Guid conversation_id, Guid user_id)
        {
            ConversationId = conversation_id;
            UserId = user_id;
        }

    }
}
