namespace Moodle.Application.Users.DTOs
{
    public class RegisterUserRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime? BirthDate { get; init; }

        public string Email { get; init; }
        public string Password { get; init; }

        public RegisterUserRequest(string firstName, string lastName, DateTime? birthDate, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }
    }
}
