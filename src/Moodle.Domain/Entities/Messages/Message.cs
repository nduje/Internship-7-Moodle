using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Persistence.Messages;

namespace Moodle.Domain.Entities.Messages
{
    public class Message
    {
        public const int TextMaxLength = 2048;

        // Primary Key
        public Guid Id { get; set; } = Guid.NewGuid();

        // Attributes
        public required string Text { get; init; }
        public DateTime Timestamp { get; init; } = DateTime.UtcNow;

        // Foreign Key
        public required Guid ConversationId { get; set; }
        public required Guid UserId { get; set; }

        // Navigation Properties
        public Conversation? Conversation { get; set; }
        public User? User { get; set; }

        public async Task<Result<Guid?>> Create(IMessageRepository messageRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<Guid?>(null, validationResult);
            }

            await messageRepository.InsertAsync(this);

            return new Result<Guid?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Text))
                validationResult.AddValidationItem(ValidationItems.Message.MessageTextRequired);

            if (Text.Length > TextMaxLength)
                validationResult.AddValidationItem(ValidationItems.Message.MessageTextMaxLength);

            if (Conversation == null)
                validationResult.AddValidationItem(ValidationItems.Message.MessageConversationNotFound);

            if (User == null)
                validationResult.AddValidationItem(ValidationItems.Message.MessageUserNotFound);

            return validationResult;
        }
    }
}
