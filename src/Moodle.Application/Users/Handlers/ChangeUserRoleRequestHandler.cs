using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Users.Handlers
{
    public class ChangeUserRoleRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserRoleRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<ChangeUserRoleResponse?>> UpdateRole(ChangeUserRoleRequest request)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                return Fail(ValidationItems.User.UserNotFound);
            }

            var validationResult = new ValidationResult();

            user.ChangeRole(request.Role, validationResult);

            if (validationResult.HasError)
            {
                return new Result<ChangeUserRoleResponse?>(null, validationResult);
            }

            _userRepository.Update(user);

            var response = new ChangeUserRoleResponse
            {
                Id = user.Id,
                Role = user.Role,
            };

            return new Result<ChangeUserRoleResponse?>(response, validationResult);
        }

        private Result<ChangeUserRoleResponse?> Fail(ValidationItem item)
        {
            return new Result<ChangeUserRoleResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
