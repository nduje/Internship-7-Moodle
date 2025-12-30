using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Enumerations.Users;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Domain.Persistence.Courses;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Domain.Persistence.Messages;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Users.Handlers
{
    public class DeleteUserRequestHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IMessageRepository _messageRepository;

        public DeleteUserRequestHandler(
            IUserRepository userRepository, 
            IEnrollmentRepository enrollmentRepository, 
            ICourseRepository courseRepository, 
            IConversationRepository conversationRepository, 
            IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _conversationRepository = conversationRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Result<DeleteUserResponse?>> DeleteUser(DeleteUserRequest request)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                return Fail(ValidationItems.User.UserNotFound);
            }

            await _messageRepository.DeleteByUserId(request.Id);
            await _conversationRepository.DeleteByUserId(request.Id);

            if (user.Role == UserRole.Student)
            {
                await _enrollmentRepository.DeleteByStudentId(request.Id);
            }

            else if (user.Role == UserRole.Professor)
            {
                await _courseRepository.ClearProfessor(request.Id);
            }

            await _userRepository.DeleteById(user.Id);

            var response = new DeleteUserResponse
            {
                Id = user.Id
            };

            return new Result<DeleteUserResponse?>(response, new ValidationResult());
        }

        private Result<DeleteUserResponse?> Fail(ValidationItem item)
        {
            return new Result<DeleteUserResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
