using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Persistence.Enrollments;

namespace Moodle.Domain.Entities.Enrollments
{
    public class Enrollment
    {
        // Primary Key
        public Guid Id { get; init; } = Guid.NewGuid();

        // Attributes
        public DateTime EnrolledAt { get; init; } = DateTime.Now;

        // Foreign Keys
        public required Guid StudentId { get; set; }
        public required Guid CourseId { get; set; }

        // Navigation Properties
        public required User Student { get; set; }
        public required Course Course { get; set; }

        public async Task<Result<Guid?>> Create(IEnrollmentRepository enrollmentRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<Guid?>(null, validationResult);
            }

            await enrollmentRepository.InsertAsync(this);

            return new Result<Guid?>(Id, validationResult);
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
