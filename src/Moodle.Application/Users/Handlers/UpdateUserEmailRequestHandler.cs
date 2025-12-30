using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Users.Handlers
{
    public class UpdateUserEmailRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserEmailRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UpdateUserEmailResponse?>> UpdateEmail(UpdateUserEmailRequest request)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                return Fail(ValidationItems.User.UserNotFound);
            }

            if (await _userRepository.GetByEmail(request.Email) != null)
            {
                return Fail(ValidationItems.User.EmailAlreadyExists);
            }

            var validationResult = new ValidationResult();

            user.ChangeEmail(request.Email, validationResult);

            if (validationResult.HasError)
            {
                return new Result<UpdateUserEmailResponse?>(null, validationResult);
            }

            await _userRepository.Update(user);

            var response = new UpdateUserEmailResponse
            {
                Id = user.Id,
                Email = user.Email
            };

            return new Result<UpdateUserEmailResponse?>(response, validationResult);
        }

        private Result<UpdateUserEmailResponse?> Fail(ValidationItem item)
        {
            return new Result<UpdateUserEmailResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
