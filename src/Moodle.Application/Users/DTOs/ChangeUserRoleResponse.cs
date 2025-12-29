using Moodle.Domain.Enumerations.Users;

namespace Moodle.Application.Users.DTOs
{
    public class ChangeUserRoleResponse
    {
        public required Guid Id { get; init; }
        public required UserRole Role { get; init; }
    }
}
