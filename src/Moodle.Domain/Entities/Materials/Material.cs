using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Persistence.Materials;

namespace Moodle.Domain.Entities.Materials
{
    public class Material
    {
        public const int NameMaxLength = 128;
        public const int UrlMaxLength = 512;

        // Primary Key
        public Guid Id { get; init; } = Guid.NewGuid();

        // Attributes
        public required string Name { get; set; }
        public required string Url { get; set; }

        // Foreign Keys
        public required Guid CourseId { get; set; }

        // Navigation Properties
        public required Course Course { get; set; }

        public async Task<Result<Guid?>> Create(IMaterialRepository materialRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<Guid?>(null, validationResult);
            }

            await materialRepository.InsertAsync(this);

            return new Result<Guid?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Name))
                validationResult.AddValidationItem(ValidationItems.Material.MaterialNameRequired);

            if (Name.Length > NameMaxLength)
                validationResult.AddValidationItem(ValidationItems.Material.MaterialNameMaxLength);

            if (string.IsNullOrWhiteSpace(Url))
                validationResult.AddValidationItem(ValidationItems.Material.MaterialUrlRequired);

            if (Url.Length > UrlMaxLength)
                validationResult.AddValidationItem(ValidationItems.Material.MaterialUrlMaxLength);

            if (Course == null)
                validationResult.AddValidationItem(ValidationItems.Material.MaterialCourseNotFound);

            return validationResult;
        }
    }
}
