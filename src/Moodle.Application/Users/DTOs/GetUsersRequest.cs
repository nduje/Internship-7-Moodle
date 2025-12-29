using Moodle.Domain.Enumerations.Users;

namespace Moodle.Application.Users.DTOs
{
    public class GetUsersRequest
    {
        public UserRole? Role { get; init; }
    }
}
