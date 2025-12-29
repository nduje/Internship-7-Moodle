using Moodle.Application.Users.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Users;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Users.Handlers
{
    public class GetUsersRequestHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUsersRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IReadOnlyList<GetUsersResponse>>> GetUsers(GetUsersRequest request)
        {
            var users = await _userRepository.GetByRole(request.Role);

            var response = users.Select(user => new GetUsersResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            }).ToList();

            return new Result<IReadOnlyList<GetUsersResponse>>(response, new ValidationResult());
        }
    }
}
