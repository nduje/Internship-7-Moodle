using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Persistence.Courses;

namespace Moodle.Domain.Entities.Courses
{
    public class Course
    {
        public const int NameMaxLength = 64;
        public const int DescriptionMaxLength = 1024;

        // Primary Key
        public Guid Id { get; init; } = Guid.NewGuid();

        // Attributes
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Foreign Keys
        public Guid? ProfessorId { get; set; }

        // Navigation Properties
        public User? Professor { get; set; }

        public async Task<Result<Guid?>> Create(ICourseRepository courseRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<Guid?>(null, validationResult);
            }

            await courseRepository.InsertAsync(this);

            return new Result<Guid?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Name))
                validationResult.AddValidationItem(ValidationItems.Course.CourseNameRequired);

            if (Name.Length > NameMaxLength)
                validationResult.AddValidationItem(ValidationItems.Course.CourseNameMaxLength);

            if (Description?.Length > DescriptionMaxLength)
                validationResult.AddValidationItem(ValidationItems.Course.CourseDescriptionMaxLength);

            return validationResult;
        }
    }
}
