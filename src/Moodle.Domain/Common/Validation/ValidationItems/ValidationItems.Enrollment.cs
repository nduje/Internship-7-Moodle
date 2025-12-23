namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Enrollment
        {
            public static string CodePrefix = nameof(Enrollment);

            public static readonly ValidationItem EnrollmentStudentNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Student ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EnrollmentCourseNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = "Kolegij ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EnrollmentAlreadyExists = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = "Student je već upisan u ovi kolegij",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
};
