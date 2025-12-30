namespace Moodle.Application.Users.DTOs
{
    public class RegisterUserRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public DateOnly? BirthDate { get; init; }

        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
