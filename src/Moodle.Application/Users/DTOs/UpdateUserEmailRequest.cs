namespace Moodle.Application.Users.DTOs
{
    public class UpdateUserEmailRequest
    {
        public required Guid Id { get; init; }
        public required string Email { get; init; }
    }
}
