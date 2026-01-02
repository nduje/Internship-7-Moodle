namespace Moodle.Application.Conversations.DTOs
{
    public class GetNonChatUsersRequest
    {
        public Guid UserId { get; init; }

        public GetNonChatUsersRequest(Guid user_id)
        {
            UserId = user_id;
        }
    }
}
