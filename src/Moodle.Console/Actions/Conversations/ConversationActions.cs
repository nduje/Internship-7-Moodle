using Moodle.Application.Conversations.DTOs;
using Moodle.Application.Conversations.Handlers;
using System.Threading.Tasks.Dataflow;

namespace Moodle.Console.Actions.Conversations
{
    public class ConversationActions
    {
        private readonly CreateConversationRequestHandler _createConversationRequestHandler;
        private readonly GetChatUsersRequestHandler _getChatUsersRequestHandler;
        private readonly GetNonChatUsersRequestHandler _getNonChatUsersRequestHandler;

        public ConversationActions(
            CreateConversationRequestHandler createConversationRequestHandler,
            GetChatUsersRequestHandler getChatUsersRequestHandler,
            GetNonChatUsersRequestHandler getNonChatUsersRequestHandler)
        {
            _createConversationRequestHandler = createConversationRequestHandler;
            _getChatUsersRequestHandler = getChatUsersRequestHandler;
            _getNonChatUsersRequestHandler = getNonChatUsersRequestHandler;
        }

        public async Task<CreateConversationResponse?> CreateConversationAsync(Guid user_1, Guid user_2)
        {
            var result = await _createConversationRequestHandler.CreateConversation(new CreateConversationRequest(user_1, user_2));

            if (result.Value == null)
            {
                return null;
            }

            return new CreateConversationResponse
            {
                Id = result.Value.Id,
                User1Id = result.Value.User1Id,
                User2Id = result.Value.User2Id
            };
        }

        public async Task <IReadOnlyList<GetChatUsersResponse>> GetChatUsersAsync(Guid user_id)
        {
            var result = await _getChatUsersRequestHandler.GetUsers(new GetChatUsersRequest(user_id));

            if (result.Value == null)
            {
                return Array.Empty<GetChatUsersResponse>();
            }

            return result.Value.Select(c => new GetChatUsersResponse
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Role = c.Role
            }).ToList();
        }

        public async Task<IReadOnlyList<GetNonChatUsersResponse>> GetNonChatUsersAsync(Guid user_id)
        {
            var result = await _getNonChatUsersRequestHandler.GetUsers(new GetNonChatUsersRequest(user_id));

            if (result.Value == null)
            {
                return Array.Empty<GetNonChatUsersResponse>();
            }

            return result.Value.Select(c => new GetNonChatUsersResponse
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Role = c.Role
            }).ToList();
        }
    }
}
