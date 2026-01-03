using Moodle.Domain.Common.Model;
using Moodle.Domain.Enumerations.Users;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Persistence.Users;
using System.Text.RegularExpressions;

namespace Moodle.Domain.Entities.Users
{
    public class User
    {
        public const int NameMaxLength = 32;
        public const int EmailMaxLength = 128;
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 128;
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private static readonly Regex PasswordRegex = new Regex("@\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z0-9]).+$");

        // Primary Key
        public Guid Id { get; init; } = Guid.NewGuid();
        
        // Attributes
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        
        public UserRole Role { get; set; }

        public async Task<Result<Guid?>> Create(IUserRepository userRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<Guid?>(null, validationResult);
            }

            await userRepository.InsertAsync(this);

            return new Result<Guid?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(FirstName))
                validationResult.AddValidationItem(ValidationItems.User.FirstNameRequired);

            if (FirstName.Length > NameMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.FirstNameMaxLength);

            if (string.IsNullOrWhiteSpace(LastName))
                validationResult.AddValidationItem(ValidationItems.User.LastNameRequired);

            if (LastName.Length > NameMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.LastNameMaxLength);

            if (BirthDate > DateTime.Today)
                validationResult.AddValidationItem(ValidationItems.User.BirthDateInFuture);

            if (Role != UserRole.Student && Role != UserRole.Professor && Role != UserRole.Admin)
                validationResult.AddValidationItem(ValidationItems.User.InvalidUserRole);

            if (string.IsNullOrWhiteSpace(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailRequired);

            if (Email.Length > EmailMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.EmailMaxLength);
            
            if (!string.IsNullOrWhiteSpace(Email) && !EmailRegex.IsMatch(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailInvalidFormat);

            if (string.IsNullOrWhiteSpace(Password))
                validationResult.AddValidationItem(ValidationItems.User.PasswordRequired);

            if (Password.Length < PasswordMinLength)
                validationResult.AddValidationItem(ValidationItems.User.PasswordMinLength);

            if (Password.Length > PasswordMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.PasswordMaxLength);

            if (!string.IsNullOrWhiteSpace(Password) && !PasswordRegex.IsMatch(Password))
                validationResult.AddValidationItem(ValidationItems.User.PasswordInvalidFormat);

            return validationResult;
        }

        public void ChangeEmail(string email, ValidationResult validationResult)
        {
            Email = email;

            if (string.IsNullOrWhiteSpace(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailRequired);

            if (Email.Length > EmailMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.EmailMaxLength);

            if (!string.IsNullOrWhiteSpace(Email) && !EmailRegex.IsMatch(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailInvalidFormat);

            if (Role != UserRole.Student && Role != UserRole.Professor)
                validationResult.AddValidationItem(ValidationItems.User.InvalidRoleForEmailChange);
        }

        public void ChangeRole(UserRole role, ValidationResult validationResult)
        {
            if (Role != UserRole.Student && Role != UserRole.Professor)
                validationResult.AddValidationItem(ValidationItems.User.InvalidUserRole);

            if (role != UserRole.Student && role != UserRole.Professor)
                validationResult.AddValidationItem(ValidationItems.User.InvalidRoleForRoleChange);

            if (Role == role)
                validationResult.AddValidationItem(ValidationItems.User.RoleUnchanged);

            Role = role;
        }
    }
}
