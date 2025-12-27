using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Enumerations.Users;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Users.Requests
{
    public class RegisterUserRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Guid?>> RegisterUser(RegisterUserRequest request)
        {
            var validationResult = new ValidationResult();

            if (await _userRepository.GetByEmail(request.Email) != null)
            {
                return Fail(ValidationItems.User.EmailAlreadyExists);   
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Password = request.Password,
                Role = UserRole.Student
            };

            return await user.Create(_userRepository);
        }

        Result<Guid?> Fail(ValidationItem item)
        {
            return new Result<Guid?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
