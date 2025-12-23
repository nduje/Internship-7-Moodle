using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Entities.Messages
{
    public class Message
    {
        public const int ContentMaxLength = 2048;

        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public string Content { get; set; } = string.Empty;

        // Foreign Key
        public required int ConversationId { get; set; }
        public required int UserId { get; set; }

        // Navigation Properties
        public required Conversation Conversation { get; set; }
        public required User User { get; set; }
    }
}
