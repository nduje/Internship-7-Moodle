using Moodle.Application.Conversations.DTOs;
using Moodle.Application.Materials.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Conversations;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Conversations.Handlers
{
    public class CreateConversationRequestHandler
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;

        public CreateConversationRequestHandler(IConversationRepository conversationRepository, IUserRepository userRepository)
        {
            _conversationRepository = conversationRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<CreateConversationResponse?>> CreateConversation(CreateConversationRequest request)
        {
            if (request.User1Id == request.User2Id)
            {
                return Fail(ValidationItems.Conversation.ConversationSameUsers);
            }

            var user1 = await _userRepository.GetById(request.User1Id);
            var user2 = await _userRepository.GetById(request.User2Id);

            if (user1 == null)
            {
                return Fail(ValidationItems.Conversation.ConversationUser1NotFound);
            }

            if (user2 == null)
            {
                return Fail(ValidationItems.Conversation.ConversationUser2NotFound);
            }

            if (await _conversationRepository.Exists(request.User1Id, request.User2Id))
            {
                return Fail(ValidationItems.Conversation.ConversationAlreadyExists);
            }

            var conversation = new Conversation
            {
                User1Id = request.User1Id,
                User2Id = request.User2Id,
                User1 = user1,
                User2 = user2
            };

            var result = await conversation.Create(_conversationRepository);

            if (result.Value == null)
            {
                return new Result<CreateConversationResponse?>(null, result.ValidationResult);
            }

            var response = new CreateConversationResponse
            {
                Id = conversation.Id,
                User1Id = user1.Id,
                User2Id = user2.Id
            };

            return new Result<CreateConversationResponse?>(response, result.ValidationResult);
        }

        private Result<CreateConversationResponse?> Fail(ValidationItem item)
        {
            return new Result<CreateConversationResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
