using Moodle.Application.Conversations.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Domain.Persistence.Users;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Conversations.Handlers
{
    public class GetNonChatUsersRequestHandler
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;

        public GetNonChatUsersRequestHandler(IConversationRepository conversationRepository, IUserRepository userRepository)
        {
            _conversationRepository = conversationRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<IReadOnlyList<GetNonChatUsersResponse>>> GetUsers(GetNonChatUsersRequest request)
        {
            var conversations = await _conversationRepository.GetByUserId(request.UserId);

            var users_with_conversation_ids = conversations
                .Select(conversation => conversation.User1Id == request.UserId ? conversation.User2Id : conversation.User1Id)
                .Distinct()
                .ToList();

            var all_users = await _userRepository.GetAllUsers();

            var response = all_users
                .Where(user => user.Id != request.UserId)
                .Where(user => !users_with_conversation_ids.Contains(user.Id))
                .Select(user => new GetNonChatUsersResponse
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Role = user.Role
                    })
                .ToList();

            return new Result<IReadOnlyList<GetNonChatUsersResponse>>(response, new ValidationResult());
        }
    }
}
