using Moodle.Application.Messages.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Domain.Persistence.Messages;

namespace Moodle.Application.Messages.Handlers
{
    public class GetMessagesByConversationRequestHandler
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;

        public GetMessagesByConversationRequestHandler(IMessageRepository messageRepository, IConversationRepository conversationRepository)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
        }

        public async Task<Result<IReadOnlyList<GetMessagesByConversationResponse>?> GetMessages(GetMessagesByConversationRequest request)
        {
            var conversation = await _conversationRepository.GetById(request.ConversationId);

            if (conversation == null)
            {
                return Fail(ValidationItems.Message.MessageConversationNotFound);
            }

            if (request.UserId != conversation.User1Id && request.UserId != conversation.User2Id)
            {
                return Fail(ValidationItems.Conversation.UserNotInConversation);
            }

            var messages = await _messageRepository.GetByConversationId(request.ConversationId);

            var response = messages
                .OrderBy(message => message.Timestamp)
                .Select(message => new GetMessagesByConversationResponse
                {
                    Id = message.Id,
                    SenderId = message.UserId,
                    Text = message.Text,
                    Timestamp = message.Timestamp
                })
                .ToList();

            return new Result<IReadOnlyList<GetMessagesByConversationResponse>?>(response, new ValidationResult());
        }

        private Result<IReadOnlyList<GetMessagesByConversationResponse>?> Fail(ValidationItem item)
        {
            return new Result<IReadOnlyList<GetMessagesByConversationResponse>?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
