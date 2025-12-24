using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
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

        public async Task<Result<int?>> Create(/* Repository */)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<int?>(null, validationResult);
            }

            // TODO: InsertAsync

            return new Result<int?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (User1 == null)
                validationResult.AddValidationItem(ValidationItems.Conversation.ConversationUser1NotFound);

            if (User2 == null)
                validationResult.AddValidationItem(ValidationItems.Conversation.ConversationUser2NotFound);

            if (User1Id == User2Id)
                validationResult.AddValidationItem(ValidationItems.Conversation.ConversationSameUsers);

            return validationResult;
        }
    }
}
