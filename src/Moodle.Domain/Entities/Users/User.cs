using Moodle.Domain.Enumerations.Users;

namespace Moodle.Domain.Entities.Users
{
    public class User
    {
        public const int NameMaxLength = 32;
        public const int EmailMaxLength = 128;
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 128;

        // Primary Key
        public required int Id { get; set; }
        
        // Attributes
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        
        public UserRole Role { get; set; }
    }
}
