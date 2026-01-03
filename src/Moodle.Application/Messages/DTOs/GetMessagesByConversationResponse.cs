using Moodle.Domain.Entities.Users;

namespace Moodle.Application.Messages.DTOs
{
    public class GetMessagesByConversationResponse
    {
        public required Guid Id { get; init; }
        public required Guid SenderId { get; init; }
        public User? Sender { get; init; }
        public required string Text { get; init; }
        public required DateTime Timestamp { get; init; }
    }
}
