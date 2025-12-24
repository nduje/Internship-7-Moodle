using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Entities.Enrollments
{
    public class Enrollment
    {
        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public DateTime EnrolledAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public required int StudentId { get; set; }
        public required int CourseId { get; set; }

        // Navigation Properties
        public required User Student { get; set; }
        public required Course Course { get; set; }

        public async Task<Result<int?>> Create(/* Repository */)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<int?>(null, validationResult);
            }

            // TODO: InsertAsync

            return new Result<int?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (Student == null)
                validationResult.AddValidationItem(ValidationItems.Enrollment.EnrollmentStudentNotFound);

            if (Course == null)
                validationResult.AddValidationItem(ValidationItems.Enrollment.EnrollmentCourseNotFound);

            return validationResult;
        }
    }
}
