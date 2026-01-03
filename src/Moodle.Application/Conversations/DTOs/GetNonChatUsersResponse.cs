using Moodle.Domain.Enumerations.Users;

namespace Moodle.Application.Conversations.DTOs
{
    public class GetNonChatUsersResponse
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required UserRole Role { get; init; }
    }
}
