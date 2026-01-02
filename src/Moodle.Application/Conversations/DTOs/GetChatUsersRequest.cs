namespace Moodle.Application.Conversations.DTOs
{
    public class GetChatUsersRequest
    {
        public Guid UserId { get; init; }
        
        public GetChatUsersRequest(Guid user_id)
        {
            UserId = user_id;
        }
    }
}
