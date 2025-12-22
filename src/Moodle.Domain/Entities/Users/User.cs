using Moodle.Domain.Enumerations.Users;

namespace Moodle.Domain.Entities.Users
{
    public class User
    {
        public const int NameMaxLength = 32;

        // Primary Key
        public required int Id { get; set; }
        
        // Attributes
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public UserRole Role { get; set; }
    }
}
