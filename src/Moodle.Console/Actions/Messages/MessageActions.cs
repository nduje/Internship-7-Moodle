using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moodle.Application.Messages.DTOs;
using Moodle.Application.Messages.Handlers;
using Moodle.Domain.Entities.Messages;

namespace Moodle.Console.Actions.Messages
{
    public  class MessageActions
    {
        private readonly GetMessagesByConversationRequestHandler _getMessagesByConversationRequestHandler;
        private readonly SendMessageRequestHandler _sendMessageRequestHandler;

        public MessageActions(
            GetMessagesByConversationRequestHandler getMessagesByConversationRequestHandler,
            SendMessageRequestHandler sendMessageRequestHandler)
        {
            _getMessagesByConversationRequestHandler = getMessagesByConversationRequestHandler;
            _sendMessageRequestHandler = sendMessageRequestHandler;
        }

        public async Task<IReadOnlyList<GetMessagesByConversationResponse>?> GetMessagesByConversationAsync(Guid conversation_id, Guid user_id)
        {
            var result = await _getMessagesByConversationRequestHandler.GetMessages(new GetMessagesByConversationRequest(conversation_id, user_id));

            if (result.Value == null)
            {
                return null;
            }

            return result.Value.Select(m => new GetMessagesByConversationResponse
            {
                Id = m.Id,
                SenderId = m.SenderId,
                Text = m.Text,
                Timestamp = m.Timestamp
            }).ToList();
        }

        public async Task<SendMessageResponse?> SendMessageAsync(Guid conversation_id, Guid sender_id, string text)
        {
            var result = await _sendMessageRequestHandler.SendMessage(new SendMessageRequest(conversation_id, sender_id, text));

            if (result.Value == null)
            {
                return null;
            }

            return new SendMessageResponse
            {
                Id = result.Value.Id,
                ConversationId = result.Value.ConversationId,
                SenderId = result.Value.SenderId,
                Text = result.Value.Text,
                Timestamp = result.Value.Timestamp
            };
        }
    }
}
