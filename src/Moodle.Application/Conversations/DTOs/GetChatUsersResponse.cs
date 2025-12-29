namespace Moodle.Application.Conversations.DTOs
{
    public class GetChatUsersResponse
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
    }
}
