using Moodle.Application.Materials.DTOs;
using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Enumerations.Users;
using Moodle.Domain.Persistence.Materials;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Users.Handlers
{
    public class RegisterUserRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Guid?>> Register(RegisterUserRequest request)
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
                BirthDate = request.BirthDate,
                Email = request.Email,
                Password = request.Password,
                Role = UserRole.Student
            };

            var result = await user.Create(_userRepository);

            if (result.Value == null)
            {
                return new Result<Guid?>(Guid.Empty, result.ValidationResult);
            }

            await _userRepository.SaveAsync();

            return new Result<Guid?>(user.Id, new ValidationResult());
        }

        private Result<Guid?> Fail(ValidationItem item)
        {
            return new Result<Guid?>(Guid.Empty, new ValidationResult().AddValidationItem(item));
        }
    }
}
