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
        public required int Id { get; set; }

        // Attributes
        public string Content { get; set; } = string.Empty;

        // Foreign Key
        public required int ConversationId { get; set; }
        public required int UserId { get; set; }

        // Navigation Properties
        public required Conversation Conversation { get; set; }
        public required User User { get; set; }

        public async Task<Result<int?>> Create(IMessageRepository messageRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<int?>(null, validationResult);
            }

            await messageRepository.InsertAsync(this);

            return new Result<int?>(Id, validationResult);
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
