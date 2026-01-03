using Moodle.Application.Messages.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Messages;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Domain.Persistence.Messages;

namespace Moodle.Application.Messages.Handlers
{
    public class SendMessageRequestHandler
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;

        public SendMessageRequestHandler(IMessageRepository messageRepository, IConversationRepository conversationRepository)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
        }

        public async Task<Result<SendMessageResponse?>> SendMessage(SendMessageRequest request)
        {
            var conversation = await _conversationRepository.GetById(request.ConversationId);

            if (conversation == null)
            {
                return Fail(ValidationItems.Conversation.ConversationNotFound);
            }

            if (request.SenderId != conversation.User1Id && request.SenderId != conversation.User2Id)
            {
                return Fail(ValidationItems.Conversation.UserNotInConversation);
            }

            var message = new Message
            {
                ConversationId = conversation.Id,
                UserId = request.SenderId,
                Text = request.Text,
                Timestamp = DateTime.UtcNow
            };

            var result = await message.Create(_messageRepository);

            if (result.Value == null)
            {
                return new Result<SendMessageResponse?>(null, result.ValidationResult);
            }

            var response = new SendMessageResponse
            {
                Id = message.Id,
                ConversationId = message.ConversationId,
                SenderId = message.UserId,
                Text = message.Text,
                Timestamp = message.Timestamp
            };

            return new Result<SendMessageResponse?>(response, result.ValidationResult);
        }

        private Result<SendMessageResponse?> Fail(ValidationItem item)
        {
            return new Result<SendMessageResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
