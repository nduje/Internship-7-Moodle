namespace Moodle.Application.Conversations.DTOs
{
    public class CreateConversationRequest
    {
        public Guid User1Id { get; init; }
        public Guid User2Id { get; init; }

        public CreateConversationRequest(Guid user1_id, Guid user2_id)
        {
            User1Id = user1_id;
            User2Id = user2_id;
        }
    }
}
