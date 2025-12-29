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
        public const int ContentMaxLength = 2048;

        // Primary Key
        public required Guid Id { get; set; } = Guid.NewGuid();

        // Attributes
        public string Text { get; set; } = string.Empty;
        public DateTime Timestamp { get; init; } = DateTime.Now;

        // Foreign Key
        public required Guid ConversationId { get; set; }
        public required Guid UserId { get; set; }

        // Navigation Properties
        public required Conversation Conversation { get; set; }
        public required User User { get; set; }

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

            if (string.IsNullOrWhiteSpace(Content))
                validationResult.AddValidationItem(ValidationItems.Message.MessageContentRequired);

            if (Content.Length > ContentMaxLength)
                validationResult.AddValidationItem(ValidationItems.Message.MessageContentMaxLength);

            if (Conversation == null)
                validationResult.AddValidationItem(ValidationItems.Message.MessageConversationNotFound);

            if (User == null)
                validationResult.AddValidationItem(ValidationItems.Message.MessageUserNotFound);

            return validationResult;
        }
    }
}
