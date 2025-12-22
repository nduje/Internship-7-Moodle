using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Entities.Conversations
{
    public class Conversation
    {
        // Primary Key
        public required int Id { get; set; }

        // Foreign Keys
        public required int User1Id { get; set; }
        public required int User2Id { get; set; }

        // Navigation Properties
        public required User User1 { get; set; }
        public required User User2 { get; set; }
    }
}
