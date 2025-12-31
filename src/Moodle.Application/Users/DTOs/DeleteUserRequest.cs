namespace Moodle.Application.Users.DTOs
{
    public class DeleteUserRequest
    {
        public Guid Id { get; init; }

        public DeleteUserRequest(Guid id)
        {
            Id = id;
        }
    }
}
