using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Users;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Users;

namespace Moodle.Application.Users.Handlers
{
    public class LoginUserRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public LoginUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User?>> Login(LoginUserRequest request)
        {
            var validationResult = new ValidationResult();

            var user = await _userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                return Fail(ValidationItems.User.UserNotFound);
            }

            if (user.Password != request.Password)
            {
                return Fail(ValidationItems.User.InvalidCredentials);
            }

            return new Result<User?>(user, validationResult);
        }

        private Result<User?> Fail(ValidationItem item)
        {
            return new Result<User?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
