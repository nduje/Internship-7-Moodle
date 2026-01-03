using Moodle.Application.Conversations.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Domain.Persistence.Users;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Conversations.Handlers
{
    public class GetChatUsersRequestHandler
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;

        public GetChatUsersRequestHandler(IConversationRepository conversationRepository, IUserRepository userRepository)
        {
            _conversationRepository = conversationRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<IReadOnlyList<GetChatUsersResponse>>> GetUsers(GetChatUsersRequest request)
        {
            var conversations = await _conversationRepository.GetByUserId(request.UserId);

            var users_ids = conversations
                .Select(conversation => conversation.User1Id == request.UserId ? conversation.User2Id : conversation.User1Id)
                .Distinct()
                .ToList();

            var users = await _userRepository.GetByIds(users_ids);

            var response = users.Select(user => new GetChatUsersResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            }).ToList();

            return new Result<IReadOnlyList<GetChatUsersResponse>>(response, new ValidationResult());
        }
    }
}
