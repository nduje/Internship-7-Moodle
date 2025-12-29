namespace Moodle.Application.Users.DTOs
{
    public class UpdateUserEmailResponse
    {
        public required Guid Id { get; init; }
        public required string Email { get; init; }
    }
}
