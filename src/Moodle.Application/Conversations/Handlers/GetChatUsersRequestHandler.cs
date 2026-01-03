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

            var filter = conversations
                .Select(c => (
                    UserId: c.User1Id == request.UserId ? c.User2Id : c.User1Id,
                    ConversationId: c.Id
                ))
                .Distinct()
                .ToList();

            var users_ids = filter.Select(x => x.UserId).ToList();
            var users = await _userRepository.GetByIds(users_ids);

            var response = users.Select(user =>
            {
                var conversation_id = filter.FirstOrDefault(f => f.UserId == user.Id).ConversationId;
                return new GetChatUsersResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = user.Role,
                    ConversationId = conversation_id
                };
            }).ToList();

            return new Result<IReadOnlyList<GetChatUsersResponse>>(response, new ValidationResult());
        }
    }
}
