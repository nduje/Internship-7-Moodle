using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Users;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;

namespace Moodle.Application.Users.Requests
{
    public class LoginUserRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public LoginUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Guid?>> Login(LoginUserRequest request)
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

            return new Result<Guid?>(user.Id, validationResult);
        }

        private Result<Guid?> Fail(ValidationItem item)
        {
            return new Result<Guid?>(Guid.Empty, new ValidationResult().AddValidationItem(item));
        }
    }
}
