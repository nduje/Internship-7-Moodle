using Moodle.Domain.Enumerations.Users;

namespace Moodle.Application.Users.DTOs
{
    public class ChangeUserRoleRequest
    {
        public Guid Id { get; init; }
        public UserRole Role { get; init; }

        public ChangeUserRoleRequest(Guid id, UserRole role)
        {
            Id = id;
            Role = role;
        }
    }
}
