namespace Moodle.Application.Users.DTOs
{
    public class UpdateUserEmailRequest
    {
        public Guid Id { get; init; }
        public string Email { get; init; }

        public UpdateUserEmailRequest(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
