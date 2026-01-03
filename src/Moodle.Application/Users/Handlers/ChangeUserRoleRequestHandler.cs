using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Enumerations.Users;
using Moodle.Domain.Persistence.Courses;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Users.Handlers
{
    public class ChangeUserRoleRequestHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public ChangeUserRoleRequestHandler(IUserRepository userRepository, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
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

            if (user.Role == UserRole.Student)
            {
                await _enrollmentRepository.DeleteByStudentId(request.Id);
            }

            else if (user.Role == UserRole.Professor)
            {
                await _courseRepository.ClearProfessor(request.Id);
            }

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

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
