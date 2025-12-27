namespace Moodle.Application.Users.DTOs
{
    public class LoginUserRequest
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
